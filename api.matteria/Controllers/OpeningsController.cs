using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.candidateSelected;
using api.matteria.Models.CompraPaquete;
using api.matteria.Models.CreateOpening;
using api.matteria.Models.OpeningCandidate;
using api.matteria.Models.openingChangeStatus;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Models.CatalogsGrade;
using biz.matteria.Models.OpeningPostulationsCandidate;
using biz.matteria.Models.OpeningPostulatios;
using biz.matteria.Models.Openings;
using biz.matteria.Models.responseCreditos;
using biz.matteria.Models.VisitaOpening;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CatalogsOpeningArea;
using biz.matteria.Repository.CatalogsTypeContract;
using biz.matteria.Repository.CompaniesCompany;
using biz.matteria.Repository.CompraPaquetes;
using biz.matteria.Repository.Creditos;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using biz.matteria.Repository.openingOpeningInterest;
using biz.matteria.Repository.OpeningProfessions;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Repository.openingsOpeningcandidate;
using biz.matteria.Repository.User;
using biz.matteria.Repository.visitasVacantes;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningsController : ControllerBase
    {
        enum statusVacantes : int
        {
            pendientePago = 1,
            enRevision = 2,
            noVisible = 3,
            publicada = 4,
            cerrada = 5,
            cancelada = 6,
            borrador = 7,
            pago_sin_procesar = 1,
            pago_rechazado = 2,
            pagado = 3,
            cubierta = 11,
            activa = 12


        }


        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IopeningsOpening _openings;
        private readonly IopeningsOpeningcandidate _openingCandidate;
        private readonly ICatalogsTypeContract _typeContract;
        private readonly IopeningProfessions _openingProfessions;
        private readonly ICatalogsOpeningArea _openingArea;
        private readonly ICreditos _creditos;
        public readonly ICompraPaquetes _compra;
        public readonly IFrontContentVacantesPaquetes _fronpaquetes;
        private readonly IUserRepository _userRepository;
        private readonly ICompaniesCompany _company;
        private readonly IWebHostEnvironment _env;
        private readonly IvisitasVacantes _visitasVacantes;
        private readonly IopeningOpeningInterest _openingInterest;
        private readonly ICandidatesCandidate _candidate;
        public OpeningsController(IMapper mapper,
            ILoggerManager logger,
            IopeningsOpening openings,
            IopeningsOpeningcandidate openingcandidate,
            ICatalogsTypeContract typeContract,
            IopeningProfessions openingProfessions,
            ICatalogsOpeningArea openingArea,
            ICreditos creditos,
            ICompraPaquetes compra,
            IFrontContentVacantesPaquetes fronpaquetes,
            IUserRepository user,
            ICompaniesCompany company,
            IWebHostEnvironment env,
            IvisitasVacantes visitasVacantes,
            IopeningOpeningInterest openingInterest,
            ICandidatesCandidate candidate)
        {
            _mapper = mapper;
            _logger = logger;
            _openings = openings;
            _openingCandidate = openingcandidate;
            _typeContract = typeContract;
            _openingProfessions = openingProfessions;
            _openingArea = openingArea;
            _creditos = creditos;
            _compra = compra;
            _fronpaquetes = fronpaquetes;
            _userRepository = user;
            _company = company;
            _env = env;
            _visitasVacantes = visitasVacantes;
            _openingInterest = openingInterest;
            _candidate = candidate;

        }



        [HttpPost("SetCandidateOpeningScore", Name = "SetCandidateOpeningScore")]
        public ActionResult<ApiResponse<bool>> SetCandidateOpeningScore(candidateScore request)
        {

            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {

                    var openingCandidate = _openingCandidate.Find(x => x.CandidateId == request.candidateId && x.OpeningId == request.openingId);

                    if (openingCandidate != null)
                    {




                        openingCandidate.Score = request.score;

                        openingCandidate = _openingCandidate.Update(_mapper.Map<OpeningsOpeningcandidate>(openingCandidate), openingCandidate.Id);


                        response.Result = true;
                        response.Success = true;

                    }
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


        [HttpPost("SetCandidateOpeningSelected", Name = "SetCandidateOpeningSelected")]
        public ActionResult<ApiResponse<bool>> SetCandidateOpeningSelected(candidateSelected request)
        {
            
            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {

                    var openingCandidate = _openingCandidate.Find(x => x.CandidateId == request.candidateId && x.OpeningId == request.openingId);

                    if (openingCandidate != null)
                    {




                        openingCandidate.Selected = request.selected;

                        openingCandidate = _openingCandidate.Update(_mapper.Map<OpeningsOpeningcandidate>(openingCandidate),openingCandidate.Id);


                        response.Result = true;
                        response.Success = true;

                    }
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

        [HttpGet("GetPopUpVacantesVisitadas", Name = "GetPopUpVacantesVisitadas")]
        public ActionResult<ApiResponse<List<visitaOpening>>> GetPopUpVacantesVisitadas(int openingId)
        {

            var response = new ApiResponse<List<visitaOpening>>();

            try
            {
                var result = _mapper.Map<List<visitaOpening>>(_openings.GetPopUpVacantesVisitadas(openingId));
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



        [HttpGet("GetVacantesVisitadasByPostulanteId", Name = "GetVacantesVisitadasByPostulanteId")]
        public ActionResult<ApiResponse<List<OpeningsService>>> GetVacantesVisitadasByPostulanteId(int postulanteId)
        {

            var response = new ApiResponse<List<OpeningsService>>();

            try
            {
                var result = _mapper.Map<List<OpeningsService>>(_openings.GetVacantesVisitadas(postulanteId));
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


        [HttpPost("SetVisitasVacantes", Name = "SetVisitasVacantes")]
        public ActionResult<ApiResponse<bool>> SetVisitasVacantes(modelvisitaVacantes request)
        {
            VisitasVacante modelVisitas = new VisitasVacante();
            var response = new ApiResponse<bool>();

            try
            {
                if (request != null)
                {
                    modelVisitas.PostulanteId = request.postulanteId;
                    modelVisitas.VacanteId = request.vacanteId;
                    modelVisitas.CreationDate = DateTime.Now;
                    var visitas = _visitasVacantes.Add(_mapper.Map<VisitasVacante>(modelVisitas));


                    response.Result = true;
                    response.Success = true;


                }


            }
            catch(Exception ex)
            {


                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);



            }

            return StatusCode(201, response);

        }



        [HttpGet("GetOpeningsDDL", Name = "GetOpeningsDDL")]
        public ActionResult<ApiResponse<List<openingddl>>> GetOpeningsDDL(int companyId)
        {
            
            var response = new ApiResponse<List<openingddl>>();

            try
            {
                var result = _mapper.Map<List<openingddl>>(_openings.GetAllOpeningsDDL());
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



        [HttpPost("CreateCompraPaquetes", Name = "CreateCompraPaquetes")]
        public ActionResult<ApiResponse<ComprasPaquete>> CreateCompraPaquetes(compraPaquetesRequest request)
        {
            ComprasPaquete modelCompra = new ComprasPaquete();
            Credito modelCredito = new Credito();

            var response = new ApiResponse<ComprasPaquete>();


            try
            {
                var paquete = _fronpaquetes.Find(i => i.Id == request.idProducto);

                if (paquete != null)
                {
                    modelCompra.CreationDate = DateTime.Now;
                    modelCompra.Id = 0;
                    modelCompra.IdProducto = paquete.Id;
                    modelCompra.MetodoPagoId = request.metodoPagoId;
                    modelCompra.UserId = request.usuarioId;
                    modelCompra.IdStatus = (int)statusVacantes.pago_sin_procesar;
                    
                        
                    var compra = _compra.Add(_mapper.Map<ComprasPaquete>(modelCompra));

                    for (int i = 1; i <= paquete.NumberCredits; i++)
                    {
                        modelCredito.CreationDate = DateTime.Now;
                        modelCredito.Id = 0;
                        modelCredito.IdCompany = request.idCompany;
                        modelCredito.IdCompra = compra.Id;
                        modelCredito.IdEstatus = (int)statusVacantes.pago_sin_procesar;
                        modelCredito.IdProducto = paquete.Id;

                        var credito = _creditos.Add(_mapper.Map<Credito>(modelCredito));
                    }

                    response.Success = true;
                    response.Result = compra;
                    response.Message = "La compra se realizo con éxito, se han generado sus creditos";


                }
                else
                {
                    response.Success = true;
                    response.Success = false;
                    response.Message = "No se encotro información del producto";

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


        [HttpGet("GetCretidosVacantesByCompany", Name = "GetCretidosVacantesByCompany")]
        public ActionResult<ApiResponse<responseCreditos>> GetCretidosVacantesByCompany(int companyId)
        {
            responseCreditos modelResponse = new responseCreditos();
            List<Credito> listCreditosActivos = new List<Credito>();
            int contador = 1;
            int IdpaqueteComparativo = 0;
            int company = 0;
            int idstatus = 0;

            var response = new ApiResponse<responseCreditos>();

            try
            {
                var creditosDsiponibles = _mapper.Map<List<Credito>>(_creditos.GetCreditosVacantes(companyId));

                foreach(var item in creditosDsiponibles)
                {
                    if(contador == 1)
                    {
                        IdpaqueteComparativo = item.IdProducto == null ? 0:Convert.ToInt32(item.IdProducto);
                        company = item.IdCompany;
                        idstatus = item.IdEstatus;
                    }

                    if(IdpaqueteComparativo == (item.IdProducto == null ? 0 : Convert.ToInt32(item.IdProducto)))
                    {
                        listCreditosActivos.Add(item);
                    }

                    contador++;

                }

                modelResponse.creditosDisponibles = listCreditosActivos.Count();
                modelResponse.creditosActivos = listCreditosActivos;
                modelResponse.idstatus = idstatus;
                modelResponse.paqueteId = IdpaqueteComparativo;

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

        

        [HttpGet("GetCatalogAreaOpening", Name = "GetCatalogAreaOpening")]
        public ActionResult<ApiResponse<List<CatalogsAreaOpening>>> GetCatalogAreaOpening(int languageId)
        {

            var response = new ApiResponse<List<CatalogsAreaOpening>>();

            try
            {
                var Result = _mapper.Map<List<CatalogsAreaOpening>>(_openingArea.GetOpeningAreas(languageId));

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


        [HttpPost("CierraVcantesCaducadas", Name = "CierraVcantesCaducadas")]
        public ActionResult<ApiResponse<bool>> CierraVcantesCaducadas()
        {
            var response = new ApiResponse<bool>();

            try
            {

                var vacantes = _mapper.Map<List<OpeningsService>>(_openings.GetOpeningAllCloseCaducidad());


                if(vacantes != null)
                {

                    foreach(var item in vacantes)
                    {
                        var opening = _openings.Find(x => x.Id == item.Id);

                        if(opening != null)
                        {
                            if (opening.CloseOpening < DateTime.Now)
                            {
                                opening.StatusProcess = 6; //estatus proceso cerrada
                                _openings.Update(_mapper.Map<OpeningsOpening>(opening), opening.Id);
                            }
                        }
                        


                    }


                }


                response.Result = true;
                response.Success = true;


            }
            catch(Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }


        [HttpPost("SetFeaturedOpening", Name = "SetFeaturedOpening")]
        public ActionResult<ApiResponse<bool>> SetFeaturedOpening(changeFeatured request)
        {
            var response = new ApiResponse<bool>();


            try
            {
                var opening = _openings.Find(x => x.Id == request.id);

                if (opening != null)
                {
                    opening.Featured = request.featured;

                    _openings.Update(_mapper.Map<OpeningsOpening>(opening), opening.Id);

                    response.Success = true;
                    response.Result = true;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Upps algo salio mal.";


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


        [HttpPost("ChangeStatusOpeningProcess", Name = "ChangeStatusOpeningProcess")]
        public ActionResult<ApiResponse<bool>> ChangeStatusOpeningProcess(changeStatus request)
        {
            var response = new ApiResponse<bool>();


            try
            {
                var opening = _openings.Find(x => x.Id == request.Id);

                if (opening != null)
                {
                    opening.StatusProcess = request.status;

                    _openings.Update(_mapper.Map<OpeningsOpening>(opening), opening.Id);

                    response.Success = true;
                    response.Result = true;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Upps algo salio mal.";


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


        [HttpPost("ChangeStatusOpening", Name = "ChangeStatusOpening")]
        public ActionResult<ApiResponse<bool>> ChangeStatusOpening(changeStatus request)
        {
            var response = new ApiResponse<bool>();


            try
            {
                var opening = _openings.Find(x => x.Id == request.Id);

                if(opening != null)
                {
                    opening.StatusOpening = request.status;


                    //if (request.status == 4) //estatus vacante publicada
                    //{
                    //    opening.StatusProcess = 2; //estatus proceso vacante postulación recibida
                    //}

                    //if (request.status == 5) //estatus vacante cerrada
                    //{
                    //    opening.StatusProcess = 6; //proceso de la vacante cerrada

                    //}



                    _openings.Update(_mapper.Map<OpeningsOpening>(opening),opening.Id);

                    response.Success = true;
                    response.Result = true;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Upps algo salio mal.";


                }



            }
            catch(Exception ex)
            {

                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);
        }



        [HttpPost("createNewOpening", Name = "createNewOpening")]
        public ActionResult<ApiResponse<OpeningsService>> createNewOpening(OpeningsService request)
        {
            AuthUser usuario = new AuthUser();
            var response = new ApiResponse<OpeningsService>();
            OpeningsOpening ResultOpening = new OpeningsOpening();
            createOpening modelResponse = new createOpening();
            OpeningsOpening modelOpening = new OpeningsOpening();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            biz.matteria.Models.Mailings.emailNewOpening modelParameters = new biz.matteria.Models.Mailings.emailNewOpening();
            OpeningsOpeningInterest modelOpeningInterest = new OpeningsOpeningInterest();

            try
            {

                if (request != null)
                {
                    modelOpening.Activities = request.Activities;
                    modelOpening.AlternateCompanyAlias = request.AlternateCompanyAlias;
                    modelOpening.AlternateCompanyDescription = request.AlternateCompanyDescription;
                    modelOpening.Avaliability = request.Avaliability;
                    modelOpening.City = request.City;
                    modelOpening.CloseOpening = request.CloseOpening;
                    modelOpening.CompanyId = request.CompanyId;
                    modelOpening.ConsultantId = null;
                    modelOpening.CountryId = request.CountryId;
                    modelOpening.CreatedById = null;
                    modelOpening.CurrencyId = request.CurrencyId;
                    modelOpening.HireType = request.HireType;
                    modelOpening.Id = request.Id;
                    modelOpening.KeepCompanyAlias = false;
                    modelOpening.KeySkills = request.KeySkills;
                    modelOpening.Name = request.Name;
                    modelOpening.OpeningTypeId = 0;
                    modelOpening.Perks = request.Perks;
                    modelOpening.PhaseId = null;
                    modelOpening.PrivateSalary = request.PrivateSalary;
                    modelOpening.PurposeOpening = request.purposeOpening;
                    modelOpening.RelevantDetails = request.RelevantDetails;
                    modelOpening.Responsabilities = request.Responsabilities;
                    modelOpening.Salary = request.Salary;
                    modelOpening.SalaryTodefine = request.SalaryTodefine;
                    modelOpening.Status = true;
                    modelOpening.StatusOpening = 2; //estatus vacante en revision
                    modelOpening.StatusProcess = 1; //estatus proceso vacante en revision
                    modelOpening.TeamProfile = request.TeamProfile;
                    modelOpening.TopLevel = null;
                    modelOpening.Updated = DateTime.Now;
                    modelOpening.Whyjoin = request.whyJoin;
                    modelOpening.WorkAreaId = request.areaid;
                    modelOpening.YearsExperience = request.YearsExperience;
                    modelOpening.YearsExperienceOpening = request.YearsExperienceOpening;
                    modelOpening.UserId = request.hunting;
                    modelOpening.Featured = request.featured;
                    modelOpening.Timestamp = DateTime.Now;
                    modelOpening.OpenOpening = DateTime.Now;

                    if (request.Id == 0)
                    {
                        


                        ResultOpening = _openings.Add(_mapper.Map<OpeningsOpening>(modelOpening));

                        var creditoConsumido = _creditos.Find(x => x.Id == request.idCredito);

                        if (creditoConsumido != null)
                        {
                            creditoConsumido.IdOpening = ResultOpening.Id;
                            creditoConsumido.IdProducto = request.Idpaquete;
                            creditoConsumido.DateHighOpening = DateTime.Now;

                            var credito = _creditos.Update(_mapper.Map<Credito>(creditoConsumido), creditoConsumido.Id);
                        }
                    }
                    else
                    {
                                                



                        modelOpening.OpenOpening = request.OpenOpening;
                        modelOpening.StatusOpening = request.StatusOpening;


                        //if(request.StatusOpening == 4) //estatus vacante publicada
                        //{
                        //    modelOpening.StatusProcess = 2;//estatus proceso vacante Postulación recibida
                        //}

                        //if(request.StatusOpening == 5) //estatus vacante cerrada
                        //{
                        //    modelOpening.StatusProcess = 6; //estatus proceso cerrado

                        //}


                        ResultOpening = _openings.Update(_mapper.Map<OpeningsOpening>(modelOpening), request.Id);
                    }
                }


                    if(request.OpeningsOpeningProfessions != null)
                    {

                        var profesiones = _mapper.Map<List<OpeningsOpeningProfession>>(_openingProfessions.openingsOpeningProfessions(ResultOpening.Id));

                    if(profesiones != null)
                    {
                        foreach(var item in profesiones)
                        {
                            _openingProfessions.Delete(item);
                        }

                    }

                    



                        foreach(var item in request.OpeningsOpeningProfessions)
                        {
                        item.Id = 0;
                            item.OpeningId = ResultOpening.Id;
                            var resultProfessionsOpening = _openingProfessions.Add(_mapper.Map<OpeningsOpeningProfession>(item));



                        //if(item.Id == 0)
                        //{
                        //item.OpeningId = ResultOpening.Id;
                        //    var resultProfessionsOpening = _openingProfessions.Add(_mapper.Map<OpeningsOpeningProfession>(item));
                        //}
                        //else
                        //{
                        //item.OpeningId = ResultOpening.Id;
                        //var resultProfessionsOpening = _openingProfessions.Update(_mapper.Map<OpeningsOpeningProfession>(item),item.Id);
                        //}

                    }
                }





                var ListOpeningProfessions = _mapper.Map<List<OpeningsOpeningProfession>>(_openingProfessions.openingsOpeningProfessions(ResultOpening.Id));


                modelResponse.opening = request;
                modelResponse.opening.OpeningsOpeningProfessions = ListOpeningProfessions;




                if (request.interest != null)
                {
                    List<OpeningsOpeningInterest> ListopeningInterest = _mapper.Map<List<OpeningsOpeningInterest>>(_openings.GetOpeningInterest(modelOpening.Id));




                    if (ListopeningInterest.Count() == 0)
                    {
                        foreach (var item in request.interest)
                        {

                            modelOpeningInterest.Id = 0;
                            modelOpeningInterest.OpeningId = modelOpening.Id;
                            modelOpeningInterest.InterestId = item.InterestId;


                            OpeningsOpeningInterest openingInterest = _openingInterest.Add(_mapper.Map<OpeningsOpeningInterest>(modelOpeningInterest));
                        }
                    }
                    else
                    {
                        foreach (var item in ListopeningInterest)
                        {
                            _openingInterest.Delete(item);
                        }

                        foreach (var item in request.interest)
                        {

                            modelOpeningInterest.Id = 0;
                            modelOpeningInterest.OpeningId = modelOpening.Id;
                            modelOpeningInterest.InterestId = item.InterestId;


                            OpeningsOpeningInterest openingInterest = _openingInterest.Add(_mapper.Map<OpeningsOpeningInterest>(modelOpeningInterest));
                        }
                    }
                }




                var company = _company.Find(x => x.Id == modelOpening.CompanyId);

                if (request.Id == 0)
                {

                    if (company != null)
                    {
                        usuario = _userRepository.Find(i => i.Id == company.UserId);

                        if (usuario != null)
                        {
                            modelEmail.To = usuario.Email;
                            modelEmail.Subject = "¡Estamos revisando tu vacante! 🔍";
                            modelEmail.IsBodyHtml = true;
                            modelEmail.Body = "";
                        }

                        modelParameters.nombre = usuario.FirstName;
                        modelParameters.vacante = modelOpening.Name;
                        modelParameters.fechaactual = DateTime.Now.ToString("dd/MM/yyyy");
                        modelParameters.vencimiento = modelOpening.CloseOpening.ToString("dd/MM/yyyy");

                        var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_publicacion_vacante_pendiente_organizaciones.html");
                        _serviceEmail.SendEmailMailingnewOpening(html, modelEmail, modelParameters);

                    }

                    if(Convert.ToBoolean(request.hunting))
                    {

                        modelEmail.To = usuario.Email;
                        modelEmail.Subject = "¡Se ha postulado tu vacante! 🔍";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "";


                        modelParameters.nombre = usuario.FirstName;
                        modelParameters.vacante = modelOpening.Name;
                        modelParameters.fechaactual = DateTime.Now.ToString("dd/MM/yyyy");
                        modelParameters.vencimiento = modelOpening.CloseOpening.ToString("dd/MM/yyyy");



                        var htmlexterno = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_postulacion_vacantes_externo.html");
                        _serviceEmail.SendEmailMailingnewOpening(htmlexterno, modelEmail, modelParameters);


                    }



                }



                response.Success = true;
                response.Result = modelResponse.opening;

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


        [HttpGet("GetTyPeContract", Name = "GetTyPeContract")]
        public ActionResult<ApiResponse<List<CatalogsTypeContract>>> GetTyPeContract(int languageId)
        {
            var response = new ApiResponse<List<CatalogsTypeContract>>();

            try
            {
                var Result = _mapper.Map<List<CatalogsTypeContract>>(_typeContract.GetTypeContract(languageId));

                response.Success = true;
                response.Result = Result;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }


            return Ok(response);
        }




        [HttpPost("CancelOpeningsCandidatePostulation", Name = "CancelOpeningsCandidatePostulation")]
        public ActionResult<ApiResponse<OpeningsOpeningcandidate>> CancelOpeningsCandidatePostulation(int openingCandidateId,int candidateId)
        {
            OpeningsOpeningcandidate modelopening = new OpeningsOpeningcandidate();

            var response = new ApiResponse<OpeningsOpeningcandidate>();

            try
            {
                var openingpostulation = _openingCandidate.Find(x => x.Id == openingCandidateId && x.CandidateId == candidateId);

                if(openingpostulation != null)
                {

                    openingpostulation.StatusPostulation = 4; //Postulación cancelada
                    modelopening = _openingCandidate.Update(_mapper.Map<OpeningsOpeningcandidate>(openingpostulation), openingpostulation.Id);

                    response.Success = true;
                    response.Result = modelopening;
                    response.Message = "Postulación cancelada";

                }
                else
                {
                    response.Success = false;
                    response.Message = "Postulación no encontrada";

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









        [HttpPost("SetOpeningsCandidate", Name = "SetOpeningsCandidate")]
        public ActionResult<ApiResponse<OpeningsOpeningcandidate>> SetOpeningsCandidate(candidateOpening request)
        {
            CandidatesCandidate modelCandidate = new CandidatesCandidate();
            OpeningsOpeningcandidate modelopening = new OpeningsOpeningcandidate();
            var response = new ApiResponse<OpeningsOpeningcandidate>();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            biz.matteria.Models.Mailings.emailNewOpening modelParameters = new biz.matteria.Models.Mailings.emailNewOpening();

            try
            {


                var candidatoPostulado = _openingCandidate.Find(x => x.CandidateId == request.candidateid && x.OpeningId == request.openingid);

                if (candidatoPostulado == null)
                {

                    modelopening.CandidateId = request.candidateid;
                    modelopening.CreatedById = request.userId;
                    modelopening.OpeningId = request.openingid;
                    modelopening.Status = true;
                    modelopening.StatusPostulation = 1;
                    modelopening.Ranking = 1;
                    modelopening.Updated = DateTime.Now;
                    modelopening.Timestamp = DateTime.Now;
                    modelopening.SalaryMin = request.SalaryMin;
                    modelopening.SalaryMax = request.SalaryMax;
                    modelopening.CurrencyId = request.currencyId;

                    OpeningsOpeningcandidate openingcandidatenew = _openingCandidate.Add(_mapper.Map<OpeningsOpeningcandidate>(modelopening));


                    var candidate = _candidate.Find(x => x.Id == request.candidateid);

                    if(candidate != null)
                    {
                        candidate.SalaryMax = request.SalaryMax;
                        candidate.SalaryMin = request.SalaryMin;
                        candidate.CurrencyId = request.currencyId;

                       candidate =  _candidate.Update(_mapper.Map<CandidatesCandidate>(candidate),candidate.Id);



                    }



                    var opening = _openings.Find(x => x.Id == openingcandidatenew.OpeningId);

                    if (opening != null)
                    {


                        var company = _company.Find(x => x.Id == opening.CompanyId);

                        var user = _userRepository.Find(x => x.Id == request.userId);

                        if (user != null)
                        {

                            modelEmail.To = user.Email;
                            modelEmail.Subject = "Su postulación ha sido procesada ✅ / ✅Has solicitado el siguiente empleo:" + opening.Name;
                            modelEmail.IsBodyHtml = true;

                            modelParameters.nombre = user.FirstName;
                            modelParameters.vacante = opening.Name;
                            modelParameters.fechaactual = DateTime.Now.ToString("dd/MM/yyyy");
                            modelParameters.vencimiento = "";
                            modelParameters.empresa = company.Name;

                            if (opening.UserId == null)
                            {
                                var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_postulacion_vacantes_externo.html");
                                _serviceEmail.SendEmailMailingnewOpening(html, modelEmail, modelParameters);
                            }
                            else
                            {
                                var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_postulacion_vacantes.html");
                                _serviceEmail.SendEmailMailingnewOpening(html, modelEmail, modelParameters);
                            }



                        }

                    }



                    response.Success = true;
                    response.Result = openingcandidatenew;

                }
                else
                {
                    response.Success = true;
                    response.Message = "El cadidato ya ha sido postulado a esta vacante";

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


        [HttpGet("GetOpeningByCandidatePostulation", Name = "GetOpeningByCandidatePostulation")]
        public ActionResult<ApiResponse<List<userOpening>>> GetOpeningByCandidatePostulation(int openingId)
        {

            var response = new ApiResponse<List<userOpening>>();

            try
            {
                var Result = _mapper.Map<List<userOpening>>(_openings.GetPostulationsAndCandidates(openingId));
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

        [HttpGet("GetOpeningByCandidateId", Name = "GetOpeningByCandidateId")]
        public ActionResult<ApiResponse<List<OpeningsService>>> GetOpeningByCandidateId(int candidateId)
        {

            var response = new ApiResponse<List<OpeningsService>>();

            try
            {
                var Result = _mapper.Map<List<OpeningsService>>(_openings.GetOpeningsByCandidateId(candidateId));
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


        [HttpGet("GetOpeningById", Name = "GetOpeningById")]
        public ActionResult<ApiResponse<OpeningsService>> GetOpeningById(int id)
        {
            var response = new ApiResponse<OpeningsService>();

            try
            {
                var Result = _mapper.Map<OpeningsService>(_openings.GetOpeningById(id));
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


        [HttpGet("GetOpeningsByCompanyId", Name = "GetOpeningsByCompanyId")]
        public ActionResult<ApiResponse<List<OpeningsService>>> GetOpeningsByCompanyId(int companyId, string name, int status)
        {

            var response = new ApiResponse<List<OpeningsService>>();

            try
            {
                var Result = _mapper.Map<List<OpeningsService>>(_openings.GetOpeningsByCompanyId(companyId,name,status));
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


        [HttpGet("GetOpenings", Name = "GetOpenings")]
        public ActionResult<ApiResponse<List<OpeningsService>>> GetOpenings(int candidateId=0)
        {

            var response = new ApiResponse<List<OpeningsService>>();

            try
            {
                var Result = _mapper.Map<List<OpeningsService>>(_openings.GetAllOpenings(candidateId));
                response.Success = true;
                response.Result = Result;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return Ok(response);
        }

       


    }
}
