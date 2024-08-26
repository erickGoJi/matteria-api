using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Repository.ContactsCompany;
using biz.matteria.Repository.ContactsContact;
using biz.matteria.Repository.ContactsGeneral;
using biz.matteria.Repository.ContactsMAI;
using biz.matteria.Repository.User;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IContactsContact _contact;
        private readonly IContactsCompany _contactscompany;
        private readonly IContactsGeneral _contactGeneral;
        private readonly IWebHostEnvironment _env;
        private readonly IContactsMAI _mai;
        public ContactsController(IMapper mapper,
            ILoggerManager logger,
            IContactsContact contact,
            IContactsCompany contactscompany,
            IContactsGeneral contactGeneral,
            IWebHostEnvironment env,
            IContactsMAI mai)
        {
            _mapper = mapper;
            _logger = logger;
            _contact = contact;
            _contactscompany = contactscompany;
            _contactGeneral = contactGeneral;
            _env = env;
            _mai = mai;

        }


        [HttpGet("GetContactoGeneralConfiguracion", Name = "GetContactoGeneralConfiguracion")]
        public ActionResult<ApiResponse<ContactoGeneralConfiguracion>> GetContactoGeneralConfiguracion(int languaje)
        {

            var response = new ApiResponse<ContactoGeneralConfiguracion>();


            try
            {
                var result = _mapper.Map<ContactoGeneralConfiguracion>(_contactGeneral.GetContactoGeneralConfiguracion(languaje));
                response.Success = true;
                response.Result = result;

            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);




        }

        [HttpPost("UpdateContactCompany", Name = "UpdateContactCompany")]
        public ActionResult<ApiResponse<ContactsCompany>> UpdateContactCompany([FromBody] ContactsCompany request)
        {
            Email modelEmail = new Email();
            var response = new ApiResponse<ContactsCompany>();
            EmailService _serviceEmail = new EmailService();

            try
            {

                var ccompany = _contactscompany.Find(i => i.Id == request.Id);

                if(ccompany != null)
                {

                    ccompany.Respuesta = request.Respuesta;

                    var result = _contactscompany.Update(_mapper.Map<ContactsCompany>(ccompany),ccompany.Id);

                    response.Success = true;
                    response.Result = result;


                    modelEmail.To = result.Email;
                    modelEmail.Subject = "Contacto Matteria";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = result.Respuesta;


                    _serviceEmail.SendEmail(modelEmail);



                }
                else
                {

                    response.Success = true;
                    response.Message = "No se encontro la información";

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





        [HttpPost("UpdateContact", Name = "UpdateContact")]
        public ActionResult<ApiResponse<ContactsContact>> UpdateContact([FromBody] ContactsContact request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            var response = new ApiResponse<ContactsContact>();

            try
            {

                var ccontacts = _contact.Find(i => i.Id == request.Id);

                if (ccontacts != null)
                {
                    ccontacts.Respuesta = request.Respuesta;

                    var result = _contact.Update(_mapper.Map<ContactsContact>(ccontacts),ccontacts.Id);

                    response.Success = true;
                    response.Result = result;


                    modelEmail.To = result.Email;
                    modelEmail.Subject = "Contacto Matteria";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = result.Respuesta;


                    _serviceEmail.SendEmail(modelEmail);
                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro información";

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



        [HttpPost("UpdateContactGeneral", Name = "UpdateContactGeneral")]
        public ActionResult<ApiResponse<ContactsGeneral>> UpdateContactGeneral([FromBody] ContactsGeneral request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            //type=1 postulante type=2 organizacion
            var response = new ApiResponse<ContactsGeneral>();

            try
            {

                var cgeneral = _contactGeneral.Find(i => i.Id == request.Id);

                if(cgeneral != null)
                {

                    cgeneral.Respuesta = request.Respuesta;

                    var result = _contactGeneral.Update(_mapper.Map<ContactsGeneral>(request),cgeneral.Id);

                    response.Success = true;
                    response.Result = result;


                    modelEmail.To = result.Email;
                    modelEmail.Subject = "Contacto Matteria";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = result.Respuesta;


                    _serviceEmail.SendEmail(modelEmail);

                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro información";


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





        [HttpPost("UpdateContactMAI", Name = "UpdateContactMAI")]
        public ActionResult<ApiResponse<ContactsMai>> UpdateContactMAI([FromBody] ContactsMai request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            //type=1 postulante type=2 organizacion
            var response = new ApiResponse<ContactsMai>();

            try
            {
                var cMAI = _mai.Find(i => i.Id == request.Id);

                if(cMAI != null)
                {
                    cMAI.Respuesta = request.Respuesta;


                    var result = _mai.Update(_mapper.Map<ContactsMai>(cMAI), cMAI.Id);

                    response.Success = true;
                    response.Result = result;

                    modelEmail.To = result.Email;
                    modelEmail.Subject = "Contacto Matteria";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = result.Respuesta;


                    _serviceEmail.SendEmail(modelEmail);


                }
                else
                {

                    response.Success = true;
                    response.Message = "No se encontro información";

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














        [HttpPost("AddNewContactMAI", Name = "AddNewContactMAI")]
        public ActionResult<ApiResponse<ContactsMai>> AddNewContactMAI([FromBody] ContactsMai request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            //type=1 postulante type=2 organizacion
            var response = new ApiResponse<ContactsMai>();

            try
            {
                var contact = _mai.Add(_mapper.Map<ContactsMai>(request));

                if (Convert.ToBoolean(request.ActivePdf))
                {
                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "Matteria PDF";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos. Te enviamos un arhcivo PDF adjunto a este correo";


                    var file = Path.Combine(_env.ContentRootPath, "pdf", "ejemplo.pdf");
                    _serviceEmail.SendEmailMailingPDF(modelEmail, file);


                    var url = "http://34.237.214.147/front/webmatteriaprincipal/organizacion/nuestrosServicios";

                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "¡Hola" + " " + contact.Name + ", gracias por tu interés en matteria!";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos. Te enviamos un arhcivo PDF adjunto a este correo";

                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_respuesta_formulario_MAI_postulante.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, contact.Name, url);

                }

                response.Success = true;
                response.Result = contact;


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





        [HttpPost("AddNewContactGeneral", Name = "AddNewContactGeneral")]
        public ActionResult<ApiResponse<ContactsGeneral>> AddNewContactGeneral([FromBody] ContactsGeneral request)
        {
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();

            //type=1 postulante type=2 organizacion
            var response = new ApiResponse<ContactsGeneral>();

            try
            {
                var contact = _contactGeneral.Add(_mapper.Map<ContactsGeneral>(request));

                response.Success = true;
                response.Result = contact;

                if(request.Type == 2)
                {

                    

                    var url = "http://34.237.214.147/front/webmatteriaprincipal/organizacion/nuestrosServicios";

                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "¡Hola " + contact.Name + ", gracias por tu interés en matteria!";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos.";

                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_respuesta_formulario_contacto_org.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, contact.Name, url);

                }
                else if(request.Type == 1)
                {
                    var url = "http://34.237.214.147/front/webmatteriaprincipal/postulante/programaMAI";

                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "¡Hola " + contact.Name + ", gracias por tu interés en matteria!";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos.";

                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_respuesta_formulario_contacto_postulante.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, contact.Name, url);

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


        [HttpPost("AddNewContactCompany", Name = "AddNewContactCompany")]
        public ActionResult<ApiResponse<ContactsCompany>> AddNewContactCompany([FromBody] ContactsCompany request, bool sendemail)
        {
            Email modelEmail = new Email();
            var response = new ApiResponse<ContactsCompany>();
            EmailService _serviceEmail = new EmailService();

            try
            {
                var contact = _contactscompany.Add(_mapper.Map<ContactsCompany>(request));

                if (sendemail)
                {

                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "Matteria PDF";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos. Te enviamos un arhcivo PDF adjunto a este correo";


                    var file = Path.Combine(_env.ContentRootPath, "pdf", "ejemplo.pdf");
                    _serviceEmail.SendEmailMailingPDF(modelEmail, file);


                    var url = "http://34.237.214.147/front/webmatteriaprincipal/organizacion/nuestrosServicios";

                    modelEmail.To = contact.Email;
                    modelEmail.Subject = "¡Hola" + contact.Name +", gracias por tu interés en matteria!";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "Gracias por contactarnos. Te enviamos un arhcivo PDF adjunto a este correo";

                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_respuesta_formulario_contacto_org.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, contact.Name,url);


                }


                response.Success = true;
                response.Result = contact;


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






        [HttpPost("AddNewContact", Name = "AddNewContact")]
        public ActionResult<ApiResponse<ContactsContact>> AddNewContact([FromBody] ContactsContact request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            var response = new ApiResponse<ContactsContact>();

            try
            {
                var contact = _contact.Add(_mapper.Map<ContactsContact>(request));



                var url = "http://34.237.214.147/front/webmatteriaprincipal/organizacion/nuestrosServicios";

                modelEmail.To = contact.Email;
                modelEmail.Subject = "¡Hola" + contact.Name + ", gracias por tu interés en matteria!";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "Gracias por contactarnos. Te enviamos un arhcivo PDF adjunto a este correo";

                var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_respuesta_formulario_contacto_postulante.html");
                _serviceEmail.SendEmailMailing(html, modelEmail, contact.Name, url);


                response.Success = true;
                response.Result = contact;

            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);

        }


    }
}
