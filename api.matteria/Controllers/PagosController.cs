using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.PagosPayu;
using api.matteria.Models.paypalPago;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Repository.CompraPaquetes;
using biz.matteria.Repository.Creditos;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using biz.matteria.Repository.Pagos;
using biz.matteria.Repository.PagosPayPal;
using biz.matteria.Repository.PagosPayu;
using biz.matteria.Repository.User;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {

        enum statusGenerales : int
        {
            
            pago_sin_procesar = 1,
            pago_rechazado = 2,
            pagado = 3


        }


        
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICreditos _creditos;
        public readonly ICompraPaquetes _compra;
        private readonly IPagosPayPal _paypal;
        private readonly IPagosPayu _payu;
        private readonly IPagos _pagos;
        private readonly IUserRepository _userRepository;
        private readonly IFrontContentVacantesPaquetes _paquetes;


        public PagosController(IMapper mapper,
            ILoggerManager logger,
            ICreditos creditos,
            ICompraPaquetes compra,
            IPagosPayPal paypal,
            IPagosPayu payu,
            IPagos pago,
            IUserRepository user,
            IFrontContentVacantesPaquetes paquetes)
        {
            _pagos = pago;
            _mapper = mapper;
            _logger = logger;
            _creditos = creditos;
            _compra = compra;
            _paypal = paypal;
            _payu = payu;
            _userRepository = user;
            _paquetes = paquetes;

        }


        [HttpPost("RegistraPagoPayu", Name = "RegistraPagoPayu")]
        public ActionResult<ApiResponse<PagosPeyu>> RegistraPagoPayu(modelPagoPayu request)
        {
            PagosPeyu modelPayu = new PagosPeyu();
            var response = new ApiResponse<PagosPeyu>();

            try
            {
                modelPayu.Amount = request.Amount;
                modelPayu.AuthorizationCode = request.AuthorizationCode;
                modelPayu.CompraId = request.CompraId;
                modelPayu.Id = request.Id;
                modelPayu.OrderId = request.OrderId;
                modelPayu.PendingReason = request.PendingReason;
                modelPayu.RegistrationDate = DateTime.Now;
                modelPayu.ResponseCode = request.ResponseCode;
                modelPayu.State = request.State;
                modelPayu.TransactionDate = request.TransactionDate;
                modelPayu.TransactionId = request.TransactionId;



                var resultado = _payu.Add(_mapper.Map<PagosPeyu>(modelPayu));

                if (resultado != null)
                {
                    if (resultado.State == "COMPLETED ")
                    {
                        var compra = _compra.Find(x => x.Id == resultado.CompraId);


                        if (compra != null)
                        {

                            compra.IdStatus = (int)statusGenerales.pagado;

                            var responseCompra = _compra.Add(_mapper.Map<ComprasPaquete>(compra));

                        }




                    }

                }
            }
            catch (Exception ex)
            {

                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);


        }

        [HttpPost("RegistraPagoPayPal", Name = "RegistraPagoPayPal")]
        public ActionResult<ApiResponse<PagosPayPal>> RegistraPagoPayPal(modelPagoPayPal request)
        {
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            PagosPayPal modelPayPal = new PagosPayPal();
            var response = new ApiResponse<PagosPayPal>();


            try
            {

                modelPayPal.Amount = request.Amount;
                modelPayPal.CompraId = request.CompraId;
                modelPayPal.CreateTime = request.CreateTime;
                modelPayPal.CurrencyCode = request.CurrencyCode;
                modelPayPal.EmailAddress = request.EmailAddress;
                modelPayPal.Id = request.Id;
                modelPayPal.MerchantId = request.MerchantId;
                modelPayPal.PaypalId = request.PaypalId;
                modelPayPal.Quantity = request.Quantity;
                modelPayPal.RegistrationDate = DateTime.Now;
                modelPayPal.Status = request.Status;
                




                var resultado = _paypal.Add(_mapper.Map<PagosPayPal>(modelPayPal));

                if(resultado != null)
                {
                    if(resultado.Status == "COMPLETED")
                    {
                        var compra = _compra.Find(x => x.Id == resultado.CompraId);


                        if(compra != null)
                        {

                            compra.IdStatus = (int)statusGenerales.pagado;

                            var responseCompra = _compra.Update(_mapper.Map<ComprasPaquete>(compra),compra.Id);


                            var user = _userRepository.Find(y => y.Id == responseCompra.UserId);


                            var paquete = _paquetes.Find(j => j.Id == responseCompra.IdProducto);


                            modelEmail.To = user.Email;
                            modelEmail.Subject = " ¡Gracias por tu compra!";
                            modelEmail.IsBodyHtml = true;
                            modelEmail.Body = "<b>Adquiriste el paquete</b>: " + paquete.Title + "<br>" + "con " + paquete.NumberCredits + "creditos" + "<br><b>El monto de tu compra es:</b> " + "$ " + paquete.RealPrice + " USD" + "<br><b>¡Comienza a agregar tus vacantes!</b>";



                            _serviceEmail.SendEmail(modelEmail);



                        }




                    }

                }

                response.Success = true;
                response.Result = resultado;


                
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);

        }


        [HttpPost("RegistraMercadoPago", Name = "RegistraMercadoPago")]
        public void RegistraMercadoPago(Hashtable collection)
        {
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            string palabraClave = Guid.NewGuid().ToString();

            try
            {
                var modelCompra1 = _compra.Find(x => x.Id == 1);

                _logger.LogError("Entro a procesar mercado pago");

                var pago = _pagos.Find(x => x.IdMercadoPago == collection["id"].ToString());

                var eMercadoPago = new biz.matteria.Entities.Pago
                {
                    ExternalReference = collection["external_reference"].ToString(),
                    TransactionOrderId = int.Parse(collection["transaction_order_id"] != null ? collection["external_reference"].ToString() : "0"),
                    MerchantOrderId = collection["merchant_order_id"] != null ? collection["merchant_order_id"].ToString() : "0",
                    IdMercadoPago = collection["id"] != null ? collection["id"].ToString() : "0",
                    Status = collection["status"] != null ? collection["status"].ToString() : "",
                    Reason = collection["reason"] != null ? collection["reason"].ToString() : "",
                    RegistrationDate = DateTime.Now,
                    DateApproved = Convert.ToDateTime(collection["date_approved"]),
                    NetReceivedAmount = collection["net_received_amount"] != null ? Convert.ToDecimal(collection["net_received_amount"].ToString()) : 0,
                    TotalPaidAmount = collection["total_paid_amount"] != null ? Convert.ToDecimal(collection["total_paid_amount"].ToString()) : 0,
                    CurrencyId = collection["currency_id"] != null ? collection["currency_id"].ToString() : "",
                    CompraId = pago.CompraId,
                    Id = pago.Id
                };



                if (pago != null)
                {



                    _logger.LogError("Inicia la actualizacion del pago");

                    var Objetopago = _pagos.Update(_mapper.Map<Pago>(eMercadoPago), pago.Id);



                }
                else
                {

                    _logger.LogError("Inicia el registro del pago");

                    var Objetopago = _pagos.Add(_mapper.Map<Pago>(eMercadoPago));


                }




                var modelCompra = _compra.Find(x => x.Id == 1);

                if (modelCompra != null)
                {

                    if (eMercadoPago.Status == "rejected")
                    {
                        modelCompra.IdStatus = (int)statusGenerales.pago_rechazado;
                        var compra = _compra.Update(_mapper.Map<ComprasPaquete>(modelCompra), modelCompra.Id);
                    }
                    else if (eMercadoPago.Status == "approved")
                    {
                        modelCompra.IdStatus = (int)statusGenerales.pagado;
                        var compra = _compra.Update(_mapper.Map<ComprasPaquete>(modelCompra), modelCompra.Id);



                        var user = _userRepository.Find(y => y.Id == compra.UserId);


                        var paquete = _paquetes.Find(j => j.Id == compra.IdProducto);



                        modelEmail.To = user.Email;
                        modelEmail.Subject = " ¡Gracias por tu compra!";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "<b>Adquiriste el paquete</b>: " + paquete.Title + "<br>" + "con " + paquete.NumberCredits + "creditos" + "<br><b>El monto de tu compra es:</b> " + "$ " + paquete.RealPrice + " USD" + "<br><b>¡Comienza a agregar tus vacantes!</b>";



                        _serviceEmail.SendEmail(modelEmail);
                    }
                }



            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");

            }

        }

        [HttpGet("AddNewMercadoPago", Name = "AddNewMercadoPago")]
        public  void AddNewMercadoPago(int compraId,string token,string issuer_id,int installments,string payment_method_id)
        {
            var client = new PaymentClient();
            Pago eMercadoPago = new Pago();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();

            try
            {
                var modelCompras = _compra.Find(x => x.Id == compraId);

                

                MercadoPagoConfig.AccessToken = "TEST-855969825385798-040822-73d98d23563dcf5c3a5bb8b361944c57-294798985";


                var paymentRequest = new PaymentCreateRequest
                {
                    TransactionAmount = 100,
                    Token = token,
                    Description = "Blue shirt",
                    Installments = installments,
                    PaymentMethodId = payment_method_id,
                    IssuerId = issuer_id,
                    Payer = new PaymentPayerRequest
                    {
                        Email = "john@yourdomain.com",
                    },
                };

                

                
                Payment payment = client.Create(paymentRequest);



                

                eMercadoPago.ExternalReference = payment.ExternalReference != null ? payment.ExternalReference : "0";
                eMercadoPago.TransactionOrderId = null;
                eMercadoPago.MerchantOrderId = payment.MerchantAccountId != null ? payment.MerchantAccountId.ToString() : "0";
                eMercadoPago.IdMercadoPago = payment.Id != null ? payment.Id.ToString() : "0";
                eMercadoPago.Status = payment.Status != null ? payment.Status : "";
                eMercadoPago.Reason = payment.Description != null ? payment.Description : "";
                eMercadoPago.RegistrationDate = DateTime.Now;
                eMercadoPago.DateApproved = payment.DateApproved;
                eMercadoPago.NetReceivedAmount = payment.TransactionAmount;
                eMercadoPago.TotalPaidAmount = payment.TransactionAmount;
                eMercadoPago.CurrencyId = payment.CurrencyId;
                eMercadoPago.CompraId = compraId;
                eMercadoPago.Id = 0;

                var Objetopago = _pagos.Add(_mapper.Map<Pago>(eMercadoPago));


                var modelCompra = _compra.Find(x => x.Id == compraId);

                if (modelCompra != null)
                {

                    if (payment.Status == "rejected")
                    {
                        modelCompra.IdStatus = (int)statusGenerales.pago_rechazado;
                        var compra = _compra.Update(_mapper.Map<ComprasPaquete>(modelCompra), modelCompra.Id);
                    }
                    else if (payment.Status == "approved")
                    {
                        modelCompra.IdStatus = (int)statusGenerales.pagado;
                        var compra = _compra.Update(_mapper.Map<ComprasPaquete>(modelCompra), modelCompra.Id);


                        //Envia email de la compra
                        var user = _userRepository.Find(y => y.Id == compra.UserId);


                        var paquete = _paquetes.Find(j => j.Id == compra.IdProducto);



                        modelEmail.To = user.Email;
                        modelEmail.Subject = " ¡Gracias por tu compra!";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "<b>Adquiriste el paquete</b>: " + paquete.Title + "<br>" + "con " + paquete.NumberCredits + "creditos" + "<br><b>El monto de tu compra es:</b> " + "$ " + paquete.RealPrice + " USD" + "<br><b>¡Comienza a agregar tus vacantes!</b>";



                        _serviceEmail.SendEmail(modelEmail);

                    }

                    var creditos = _mapper.Map<List<Credito>>(_creditos.GetCreditosByCompraId(modelCompra.Id));

                    if (creditos != null)
                    {
                        foreach (var item in creditos)
                        {

                            if (payment.Status == "rejected")
                            {
                                item.IdEstatus = (int)statusGenerales.pago_rechazado;
                                var credito = _creditos.Update(_mapper.Map<Credito>(item), item.Id);
                            }
                            else if (payment.Status == "approved")
                            {
                                item.IdEstatus = (int)statusGenerales.pagado;
                                var credito = _creditos.Update(_mapper.Map<Credito>(item), item.Id);
                            }

                        }


                    }
                }



            }
            catch (Exception ex)
            {
                
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                

            }
        }

    }
}
