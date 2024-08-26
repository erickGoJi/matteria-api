using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.matteria.Models.company;
using api.matteria.Models.contactos;
using api.matteria.Models.OpeningCandidate;
using api.matteria.Models.OpeningSearch;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models.AuthUser;
using biz.matteria.Models.candidate;
using biz.matteria.Models.CatalogsCountry;
using biz.matteria.Models.Company;
using biz.matteria.Models.comprasadmin;
using biz.matteria.Models.ddlCompanys;
using biz.matteria.Models.OpeningPostulatios;
using biz.matteria.Models.Openings;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CatalogsCountry;
using biz.matteria.Repository.CompaniesCompany;
using biz.matteria.Repository.CompraPaquetes;
using biz.matteria.Repository.ContactsCompany;
using biz.matteria.Repository.ContactsContact;
using biz.matteria.Repository.ContactsGeneral;
using biz.matteria.Repository.ContactsMAI;
using biz.matteria.Repository.EstatusVacantes;
using biz.matteria.Repository.EstatusVacantesProceso;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Repository.Roles;
using biz.matteria.Repository.User;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IopeningsOpening _openings;
        private readonly ICompaniesCompany _company;
        private readonly IEstatusVacantes _estatus;
        private readonly ICandidatesCandidate _candidate;
        private readonly IUserRepository _userRepository;
        private readonly ICompraPaquetes _comprapaquetes;
        private readonly IFrontContentVacantesPaquetes _paquetes;
        private readonly IContactsCompany _ccompany;
        private readonly IContactsContact _ccontacts;
        private readonly IContactsGeneral _cgeneral;
        private readonly IContactsMAI _cMAI;
        private readonly IRoles _roles;
        private readonly IEstatusVacantesProceso _vacantesproceso;
        private readonly ICatalogsCountry _country;
        public BackOfficeController(IMapper mapper,
            ILoggerManager logger,
            IopeningsOpening opening,
            ICompaniesCompany company,
            IEstatusVacantes estatus,
            ICandidatesCandidate candidate,
            IUserRepository users,
            ICompraPaquetes comprapaquetes,
            IFrontContentVacantesPaquetes paquetes,
            IContactsCompany ccompany,
            IContactsContact ccontacts,
            IContactsGeneral cgeneral,
            IContactsMAI cmai,
            IRoles roles,
            IEstatusVacantesProceso vacantesproceso,
            ICatalogsCountry country)
        {
            _mapper = mapper;
            _logger = logger;
            _openings = opening;
            _company = company;
            _estatus = estatus;
            _candidate = candidate;
            _userRepository = users;
            _comprapaquetes = comprapaquetes;
            _paquetes = paquetes;
            _ccompany = ccompany;
            _ccontacts = ccontacts;
            _cgeneral = cgeneral;
            _cMAI = cmai;
            _roles = roles;
            _vacantesproceso = vacantesproceso;
            _country = country;
        }




        [HttpPost("SetCompanyAprobarDesaprobar", Name = "SetCompanyAprobarDesaprobar")]
        public ActionResult<ApiResponse<bool>> SetCompanyAprobarDesaprobar(setCompanyAprobar request)
        {

            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {

                    var objetoCompany = _company.Find(x => x.Id == request.organizacionId);

                    if (objetoCompany != null)
                    {




                        objetoCompany.Approve = request.aprobar;

                        objetoCompany = _company.Update(_mapper.Map<CompaniesCompany>(objetoCompany), objetoCompany.Id);


                        response.Result = true;
                        response.Success = true;

                    }
                    else
                    {
                        response.Result = true;
                        response.Message = "Organización no encontrada";

                    }
                }
                else
                {
                    response.Result = true;
                    response.Message = "Información requerida no valida";
                }


            }
            catch (Exception ex)
            {


                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);



            }

            return StatusCode(201, response);

        }




        [HttpPost("SetCompanyActivaDesactiva", Name = "SetCompanyActivaDesactiva")]
        public ActionResult<ApiResponse<bool>> SetCompanyActivaDesactiva(setcompanyDesactiva request)
        {

            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {

                    var objetoCompany = _company.Find(x => x.Id == request.organizacionId);

                    if (objetoCompany != null)
                    {




                        objetoCompany.Status = request.activa;

                        objetoCompany = _company.Update(_mapper.Map<CompaniesCompany>(objetoCompany), objetoCompany.Id);


                        response.Result = true;
                        response.Success = true;

                    }
                    else
                    {
                        response.Result = true;
                        response.Message = "Organización no encontrada";

                    }
                }
                else
                {
                    response.Result = true;
                    response.Message = "Información requerida no valida";
                }


            }
            catch (Exception ex)
            {


                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);



            }

            return StatusCode(201, response);

        }



        [HttpPost("SetConsultorVacante", Name = "SetConsultorVacante")]
        public ActionResult<ApiResponse<bool>> SetConsultorVacante(consultorVacante request)
        {

            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {

                    var objetoVacante = _openings.Find(x => x.Id == request.vacanteId);

                    if (objetoVacante != null)
                    {




                        objetoVacante.UserId = request.consultorId;

                        objetoVacante = _openings.Update(_mapper.Map<OpeningsOpening>(objetoVacante), objetoVacante.Id);


                        response.Result = true;
                        response.Success = true;

                    }
                    else
                    {
                        response.Result = true;
                        response.Message = "Vacante no encontrada";

                    }
                }
                else
                {
                    response.Result = true;
                    response.Message = "Información requerida no valida";
                }


            }
            catch (Exception ex)
            {


                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);



            }

            return StatusCode(201, response);

        }


        [HttpGet("GetTipoMonea", Name = "GetTipoMonea")]
        public async Task<ActionResult<ApiResponse<bool>>> GetTipoCambioMoneda()
        {

            var response = new ApiResponse<bool>();
            string baseURL = "https://exchange-rates.abstractapi.com/";
            string target = "";

            try
            {
                var client = new HttpClient();

                var Result = _mapper.Map<List<CatalogsCountryService>>(_country.GetCatalogCountry());

                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var item in Result)
                {
                    if (!string.IsNullOrEmpty(item.codeCountry))
                    {


                        target = item.codeCountry;


                        HttpResponseMessage Res = await client.GetAsync("v1/live/?api_key=e987fc91304b47a69e4f2e0af36e5b26&base=USD&target=" + target);

                        if (Res.IsSuccessStatusCode)
                        {
                            var resp = Res.Content.ReadAsStringAsync().Result;

                            //le falta
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);




        }




        [HttpGet("GetServiciosCompany", Name = "GetServiciosCompany")]
        public ActionResult<ApiResponse<List<comprasCompany>>> GetServiciosCompany(int companyId)
        {

            var response = new ApiResponse<List<comprasCompany>>();


            try
            {
                var result = _mapper.Map<List<comprasCompany>>(_comprapaquetes.GetPaquetesByCompany(companyId));
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



        [HttpGet("GetOpeningCandidatesCompanyRpt", Name = "GetOpeningCandidatesCompanyRpt")]
        public ActionResult<ApiResponse<List<openingCompanyCandidate>>> GetOpeningCandidatesCompanyRpt(int companyId)
        {

            var response = new ApiResponse<List<openingCompanyCandidate>>();


            try
            {
                var result = _mapper.Map<List<openingCompanyCandidate>>(_openings.GetOpeningCandidatesCompany(companyId));
                response.Success = true;
                response.Result = result;

            }
            catch(Exception ex)
            {

                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);

        }



        [HttpGet("GetTotalesPostulantes", Name = "GetTotalesPostulantes")]
        public ActionResult<ApiResponse<enlistaPostulantesTotales>> GetTotalesPostulantes(string fechaInicial, string FechaFinal, string profesion, int edad, int pais, string ciudad)
        {
            enlistaPostulantesTotales modelResponse = new enlistaPostulantesTotales();

            var response = new ApiResponse<enlistaPostulantesTotales>();

            try
            {
                
                modelResponse = _mapper.Map<enlistaPostulantesTotales>(_candidate.GetCandidatos(fechaInicial,FechaFinal,profesion,edad,pais,ciudad));



                response.Success = true;
                response.Result = modelResponse;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);
        }


        [HttpGet("GetAllContacts", Name = "GetAllContacts")]
        public ActionResult<ApiResponse<contactos>> GetAllContacts()
        {
            contactos modelResponse = new contactos();

            var response = new ApiResponse<contactos>();
            try
            {
                var company = _mapper.Map<List<biz.matteria.Entities.ContactsCompany>>(_ccompany.GetAllContactsCompany());

                var contacts = _mapper.Map<List<biz.matteria.Entities.ContactsContact>>(_ccontacts.GetAllContactsContact());

                var contactsGeneral = _mapper.Map<List<biz.matteria.Entities.ContactsGeneral>>(_cgeneral.GetAllContacsGeneral());

                var contacsMAI = _mapper.Map<List<biz.matteria.Entities.ContactsMai>>(_cMAI.GetAllContactsMAI());


                modelResponse.contactsCompany = company;
                modelResponse.contactsContact = contacts;
                modelResponse.contactsGeneral = contactsGeneral;
                modelResponse.contactsMAI = contacsMAI;

                response.Success = true;
                response.Result = modelResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }





        [HttpPost("NewPaquetesVacantes", Name = "NewPaquetesVacantes")]
        public ActionResult<ApiResponse<FrontContentVacantesPaquete>> NewPaquetesVacantes(FrontContentVacantesPaquete request)
        {

            var response = new ApiResponse<FrontContentVacantesPaquete>();

            try
            {

                var updatePaquete = _paquetes.Add(_mapper.Map<FrontContentVacantesPaquete>(request));


                response.Success = true;
                response.Result = updatePaquete;

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


        [HttpPost("UpdatePaquetesVacantes", Name = "UpdatePaquetesVacantes")]
        public ActionResult<ApiResponse<FrontContentVacantesPaquete>> UpdatePaquetesVacantes(FrontContentVacantesPaquete request)
        {
            var response = new ApiResponse<FrontContentVacantesPaquete>();

            try
            {
                var paquete = _paquetes.Find(x => x.Id == request.Id);

                if(paquete != null)
                {
                    paquete.Id = request.Id;
                    paquete.Title = request.Title;
                    paquete.Description = request.Description;
                    paquete.RealPrice = request.RealPrice;
                    paquete.PackagePrice = request.PackagePrice;
                    paquete.NumberCredits = request.NumberCredits;
                    paquete.AplicaIva = request.AplicaIva;
                    paquete.Active = request.Active;
                    paquete.CurrencyId = request.CurrencyId;


                    var updatePaquete = _paquetes.Update(_mapper.Map<FrontContentVacantesPaquete>(paquete), paquete.Id);


                    response.Success = true;
                    response.Result = updatePaquete;
                }
                else
                {
                    response.Success = true;
                    response.Message = "No existe el paquete de vacantes";

                }

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



        [HttpGet("GetPaquetesById", Name = "GetPaquetesById")]
        public ActionResult<ApiResponse<FrontContentVacantesPaquete>> GetPaquetesById(int id)
        {
            var response = new ApiResponse<FrontContentVacantesPaquete>();
            try
            {
                var Result = _mapper.Map<FrontContentVacantesPaquete>(_paquetes.GetFrontVacantesPaquetesById(id));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }



        [HttpGet("GetPaquetes", Name = "GetPaquetes")]
        public ActionResult<ApiResponse<List<FrontContentVacantesPaquete>>> GetPaquetes(int languajeId=1)
        {
            var response = new ApiResponse<List<FrontContentVacantesPaquete>>();
            try
            {
                var Result = _mapper.Map<List<FrontContentVacantesPaquete>>(_paquetes.GetFrontVacantesPaquetes(languajeId));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }


        [HttpGet("GetCompraById", Name = "GetCompraById")]
        public ActionResult<ApiResponse<comprasDetalleAdmin>> GetCompraById(int compraId)
        {
            var response = new ApiResponse<comprasDetalleAdmin>();
            try
            {
                var Result = _mapper.Map<comprasDetalleAdmin>(_comprapaquetes.GetCompraById(compraId));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }


        [HttpGet("GetListaComprasRpt", Name = "GetListaComprasRpt")]
        public ActionResult<ApiResponse<comprasAdminRpt>> GetListaComprasRpt(int companyId, int metodoPagoId, string fechaInicial, string FechaFinal, int paisId, int productoId,string ciudad)
        {
            var response = new ApiResponse<comprasAdminRpt>();
            try
            {
                var Result = _mapper.Map<comprasAdminRpt>(_comprapaquetes.getComprasAdminRpt(companyId, metodoPagoId, fechaInicial, FechaFinal, paisId, productoId,ciudad));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }









        [HttpGet("GetListaCompras", Name = "GetListaCompras")]
        public ActionResult<ApiResponse<List<comprasAdmin>>> GetListaCompras(int companyId, int metodoPagoId, string fechaInicial, string FechaFinal, int paisId, int productoId,string ciudad)
        {
            var response = new ApiResponse<List<comprasAdmin>>();
            try
            {
                var Result = _mapper.Map<List<comprasAdmin>>(_comprapaquetes.getComprasAdmin(companyId, metodoPagoId, fechaInicial, FechaFinal, paisId, productoId,ciudad));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }


        [HttpGet("GetUserById", Name = "GetUserById")]
        public ActionResult<ApiResponse<AuthUser>> GetUserById(int id)
        {
            var response = new ApiResponse<AuthUser>();
            try
            {
                var Result = _mapper.Map<AuthUser>(_userRepository.GetUserById(id));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }

        [HttpGet("GetRoles", Name = "GetRoles")]
        public ActionResult<ApiResponse<List<Role>>> GetRoles()
        {
            var response = new ApiResponse<List<Role>>();
            try
            {
                var Result = _mapper.Map<List<Role>>(_roles.getRoles());
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }

        [HttpGet("GetUsers", Name = "GetUsers")]
        public ActionResult<ApiResponse<List<AuthUser>>> GetUsers()
        {
            var response = new ApiResponse<List<AuthUser>>();
            try
            {
                var Result = _mapper.Map<List<AuthUser>>(_userRepository.GetUsers());
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }


        [HttpGet("GetUsersAdmon", Name = "GetUsersAdmon")]
        public ActionResult<ApiResponse<List<AuthUserService>>> GetUsersAdmon(string descripcion, int pais)
        {
            var response = new ApiResponse<List<AuthUserService>>();
            try
            {
                var Result = _mapper.Map<List<AuthUserService>>(_userRepository.GetUsersAdmon(descripcion, pais));
                response.Success = true;
                response.Result = Result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);


        }



        [HttpGet("GetCompanysReport", Name = "GetCompanysReport")]
        public ActionResult<ApiResponse<enlistaCompanysTotales>> GetCompanysReport(string nameCompany, int pais, int tipoOrganizacion, int? aprobadas, int? status)
        {

            var response = new ApiResponse<enlistaCompanysTotales>();

            try
            {

                var Result = _mapper.Map<enlistaCompanysTotales>(_company.GetCompanysReport(nameCompany,pais, tipoOrganizacion,aprobadas,status));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);



        }



        [HttpGet("GetEnlistaCompanys", Name = "GetEnlistaCompanys")]
        public ActionResult<ApiResponse<List<enlistaCompany>>> GetEnlistaCompanys(string nameCompany, int pais, int tipoOrganizacion, int? aprobadas, int? status)
        {

            var response = new ApiResponse<List<enlistaCompany>>();

            try
            {

                var Result = _mapper.Map<List<enlistaCompany>>(_company.GetEnlistaCompanys(nameCompany,pais,tipoOrganizacion,aprobadas,status));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);



        }


        [HttpGet("GetPostulaneById", Name = "GetPostulaneById")]
        public ActionResult<ApiResponse<enlistaCandidate>> GetPostulaneById(int id)
        {

            var response = new ApiResponse<enlistaCandidate>();

            try
            {

                var Result = _mapper.Map<enlistaCandidate>(_candidate.GetPostulanteById(id));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);



        }


        [HttpGet("GetEnlistaPostulantes", Name = "GetEnlistaPostulantes")]
        public ActionResult<ApiResponse<List<enlistaCandidate>>> GetEnlistaPostulantes(string fechaInicial, string FechaFinal, string profesion, int edad, int pais, string ciudad)
        {

            var response = new ApiResponse<List<enlistaCandidate>>();

            try
            {

                var Result = _mapper.Map<List<enlistaCandidate>>(_candidate.GetEnlistaCandidates(fechaInicial,FechaFinal,profesion,edad,pais,ciudad));
                response.Success = true;
                response.Result = Result;


            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);



        }


        [HttpGet("GetEstatusVacantesProceso", Name = "GetEstatusVacantesProceso")]
        public ActionResult<ApiResponse<List<EstatusVacantesProceso>>> GetEstatusVacantesProceso()
        {

            var response = new ApiResponse<List<EstatusVacantesProceso>>();

            try
            {
                var Result = _mapper.Map<List<EstatusVacantesProceso>>(_vacantesproceso.GetEstatusVacantesProceso());
                response.Success = true;
                response.Result = Result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }




        [HttpGet("GetEstatusVacantes", Name = "GetEstatusVacantes")]
        public ActionResult<ApiResponse<List<EstatusVacante>>> GetEstatusVacantes()
        {

            var response = new ApiResponse<List<EstatusVacante>>();

            try
            {
                var Result = _mapper.Map<List<EstatusVacante>>(_estatus.GetEstatusVacantes());
                response.Success = true;
                response.Result = Result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }





        [HttpGet("GetDDLCompany", Name = "GetDDLCompany")]
        public ActionResult<ApiResponse<List<dllCompany>>> GetDDLCompany()
        {

            var response = new ApiResponse<List<dllCompany>>();

            try
            {
                var Result = _mapper.Map<List<dllCompany>>(_company.GetDDLCompany());
                response.Success = true;
                response.Result = Result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }


        [HttpPost("GetOpeningsByFilterSearchTotalesRPT", Name = "GetOpeningsByFilterSearchTotalesRPT")]
        public ActionResult<ApiResponse<OpenignRptVacantes>> GetOpeningsByFilterSearchTotalesRPT(requestSearchOpenings request)
        {

            var response = new ApiResponse<OpenignRptVacantes>();

            try
            {


                var Result = _mapper.Map<OpenignRptVacantes>(_openings.GetOpeningsTotalesRptVacantes(request.fechaInicial, request.fechaFinal, request.companyId, request.descripcion, request.sector, request.pais, request.ciudad, request.status,request.companyTypeId, request.jornada, request.tipoContratoId));
                response.Success = true;
                response.Result = Result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }



        [HttpPost("GetOpeningsByFilterSearch", Name = "GetOpeningsByFilterSearch")]
        public ActionResult<ApiResponse<List<openingServiceBackOffice>>> GetOpeningsByFilterSearch(requestSearchOpenings request)
        {

            var response = new ApiResponse<List<openingServiceBackOffice>>();

            try
            {
                

                var Result = _mapper.Map<List<openingServiceBackOffice>>(_openings.GetOpeningsFilterSearch(request.fechaInicial,request.fechaFinal,request.companyId,request.descripcion,request.sector,request.pais,request.ciudad,request.status, request.companyTypeId, request.jornada, request.tipoContratoId));
                response.Success = true;
                response.Result = Result;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }


    }
}
