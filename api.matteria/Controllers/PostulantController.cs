using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models;
using api.matteria.Models.createAccountPostulantService;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Models.candidate;
using biz.matteria.Models.CatalogProffesion;
using biz.matteria.Models.CatalogsCountry;
using biz.matteria.Models.CatalogsCurrency;
using biz.matteria.Models.CatalogsExparea;
using biz.matteria.Models.CatalogsGrade;
using biz.matteria.Models.catalogsInterestService;
using biz.matteria.Models.CatalogsLanguaje;
using biz.matteria.Models.CatalogsOralLevel;
using biz.matteria.Models.CatalogsState;
using biz.matteria.Models.CatalogWrittenLevel;
using biz.matteria.Models.stepBystepPostulante;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CandidatesCandidateExpArea;
using biz.matteria.Repository.CandidatesCandidateInterest;
using biz.matteria.Repository.CandidatesEducation;
using biz.matteria.Repository.CandidatesLanguage;
using biz.matteria.Repository.CandidatesWorkandsocialexp;
using biz.matteria.Repository.CatalogGrade;
using biz.matteria.Repository.CatalogsCountry;
using biz.matteria.Repository.CatalogsCurrency;
using biz.matteria.Repository.CatalogsExparea;
using biz.matteria.Repository.CatalogsInterest;
using biz.matteria.Repository.CatalogsLanguage;
using biz.matteria.Repository.CatalogsProffesion;
using biz.matteria.Repository.CatalogState;
using biz.matteria.Repository.catalogsTipoOrganizacion;
using biz.matteria.Repository.CatalogWrittenLevel;
using biz.matteria.Repository.CtalogOralLevel;
using biz.matteria.Repository.stepBystepPostulante;
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
    public class PostulantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICandidatesCandidate _candidate;
        private readonly ICatalogsInterest _interest;
        private readonly ICatalogsCountry _country;
        private readonly ICatalogState _state;
        private readonly ICatalogsCurrency _currency;
        private readonly ICatalogsExparea _exparea;
        private readonly ICandidatesCandidateInterest _candidateInterest;
        private readonly ICandidatesWorkandsocialexp _candidatesWorkandsocialexp;
        private readonly ICandidatesEducation _candidatesEducation;
        private readonly ICandidatesLanguage _candidatesLanguage;
        private readonly ICandidatesCandidateExpArea _candidatesCandidateExpArea;
        private readonly ICatalogsLanguage _language;
        private readonly ICatalogOralLevel _orallevel;
        public readonly ICatalogWrittenLevel _writtenlevel;
        public readonly ICatalogsProffesion _profesion;
        public readonly ICatalogsGrade _grade;
        private readonly IcatalogsTipoOrganizacion _tipoOrganizacion;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IstepBystepPostulante _stepbystepPostulante;

        public PostulantController(IMapper mapper,
            ILoggerManager logger,
            ICandidatesCandidate candidate,
            ICatalogsInterest interest,
            ICatalogsCountry country,
            ICatalogState state,
            ICatalogsCurrency currency,
            ICatalogsExparea exparea,
            ICandidatesCandidateInterest candidateInterest,
            ICandidatesWorkandsocialexp candidatesWorkandsocialexp,
            ICandidatesEducation candidatesEducation,
            ICandidatesLanguage candidatesLanguage,
            ICandidatesCandidateExpArea candidatesCandidateExpArea,
            ICatalogsLanguage languaje,
            ICatalogOralLevel orallevel,
            ICatalogWrittenLevel writtenLevel,
            ICatalogsProffesion profesion,
            ICatalogsGrade grade,
            IcatalogsTipoOrganizacion tipoOrganizacion,
            IUserRepository userRepository,
            IWebHostEnvironment env,
            IstepBystepPostulante stepbystepPostulant)
        {
            _mapper = mapper;
            _logger = logger;
            _candidate = candidate;
            _interest = interest;
            _country = country;
            _state = state;
            _currency = currency;
            _exparea = exparea;
            _candidateInterest = candidateInterest;
            _candidatesWorkandsocialexp = candidatesWorkandsocialexp;
            _candidatesEducation = candidatesEducation;
            _candidatesLanguage = candidatesLanguage;
            _candidatesCandidateExpArea = candidatesCandidateExpArea;
            _language = languaje;
            _orallevel = orallevel;
            _writtenlevel = writtenLevel;
            _profesion = profesion;
            _grade = grade;
            _tipoOrganizacion = tipoOrganizacion;
            _userRepository = userRepository;
            _env = env;
            _stepbystepPostulante = stepbystepPostulant;
        }


        [HttpGet("GetConfiguracionPostulante", Name = "GetConfiguracionPostulante")]
        public ActionResult<ApiResponse<ConfiguracionPostulante>> GetConfiguracionPostulante(int languageId = 1)
        {

            var response = new ApiResponse<ConfiguracionPostulante>();

            try
            {

                var Result = _mapper.Map<ConfiguracionPostulante>(_candidate.GetConfiguracionPostulante(languageId));
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




        [HttpGet("GetConfiguracionBusquedaVacantes", Name = "GetConfiguracionBusquedaVacantes")]
        public ActionResult<ApiResponse<ConfiguracionBusquedaVacantesPostulante>> GetConfiguracionBusquedaVacantes(int languageId = 1)
        {

            var response = new ApiResponse<ConfiguracionBusquedaVacantesPostulante>();

            try
            {

                var Result = _mapper.Map<ConfiguracionBusquedaVacantesPostulante>(_candidate.GetConfiguracionBusqyedaVcantes(languageId));
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



        [HttpGet("GetConfiguracionPerfilPostulante", Name = "GetConfiguracionPerfilPostulante")]
        public ActionResult<ApiResponse<ConfiguracionMiPerfilPostulante>> GetConfiguracionPerfilPostulante(int languageId = 1)
        {

            var response = new ApiResponse<ConfiguracionMiPerfilPostulante>();

            try
            {

                var Result = _mapper.Map<ConfiguracionMiPerfilPostulante>(_candidate.GetConfiguracionPerfilPostulante(languageId));
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




        [HttpGet("GetConfigurationCrearCuentaPostulante", Name = "GetConfigurationCrearCuentaPostulante")]
        public ActionResult<ApiResponse<ConfiguracionCrearCuentaPostulante>> GetConfigurationCrearCuentaPostulante(int languageId = 1)
        {

            var response = new ApiResponse<ConfiguracionCrearCuentaPostulante>();

            try
            {

                var Result = _mapper.Map<ConfiguracionCrearCuentaPostulante>(_candidate.GetConfiguracionCrearCuentaPostulante(languageId));
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







        [HttpGet("GetConfigurationStepByStepPostulant", Name = "GetConfigurationStepByStepPostulant")]
        public ActionResult<ApiResponse<List<ResponsestepbystepPostulante>>> GetConfigurationStepByStepPostulant(int languageId=1)
        {

            var response = new ApiResponse<List<ResponsestepbystepPostulante>>();

            try
            {

                var Result = _mapper.Map<List<ResponsestepbystepPostulante>>(_stepbystepPostulante.getstepByStepPostulantConfiguration(languageId));
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



        [HttpGet("GetCatTipoOrganizacion", Name = "GetCatTipoOrganizacion")]
        public ActionResult<ApiResponse<List<CatalogsTipoOrganizacion>>> GetCatTipoOrganizacion(int languageId=1)
        {

            var response = new ApiResponse<List<CatalogsTipoOrganizacion>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsTipoOrganizacion>>(_tipoOrganizacion.GetAllTipoOrganizacion(languageId));
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


        [HttpGet("GetCatGrade", Name = "GetCatGrade")]
        public ActionResult<ApiResponse<List<CatalogsGradeService>>> GetCatGrade()
        {

            var response = new ApiResponse<List<CatalogsGradeService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsGradeService>>(_grade.GatAllCatalogGradeService());
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


        [HttpGet("GetCatProfession", Name = "GetCatProfession")]
        public ActionResult<ApiResponse<List<CatalogsProffesionService>>> GetCatProfession()
        {
            var response = new ApiResponse<List<CatalogsProffesionService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsProffesionService>>(_profesion.GetAllCatalogProffesion());
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


        [HttpGet("GetCatWrittenLevel", Name = "GetCatWrittenLevel")]
        public ActionResult<ApiResponse<List<CatalogWrittenLevelService>>> GetCatWrittenLevel(int languageId=1)
        {
            var response = new ApiResponse<List<CatalogWrittenLevelService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogWrittenLevelService>>(_writtenlevel.GetAllCatalogWrittenLevel(languageId));
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


        [HttpGet("GetCatOralLevel", Name = "GetCatOralLevel")]
        public ActionResult<ApiResponse<List<CatalogsOralLevelService>>> GetCatOralLevel(int languageId=1)
        {
            var response = new ApiResponse<List<CatalogsOralLevelService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsOralLevelService>>(_orallevel.GetAllCatalogOralLevel(languageId));
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



        [HttpGet("GetCatLanguage", Name = "GetCatLanguage")]
        public ActionResult<ApiResponse<List<CatalogsLanguageService>>> GetCatLanguage()
        {
            var response = new ApiResponse<List<CatalogsLanguageService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsLanguageService>>(_language.GetAllCatalogLanguaje());
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


        [HttpGet("GetCatExpArea", Name = "GetCatExpArea")]
        public ActionResult<ApiResponse<List<CatalogsExpareaService>>> GetCatExpArea()
        {
            var response = new ApiResponse<List<CatalogsExpareaService>>();

            try
            {

                var Result = _mapper.Map<List<CatalogsExpareaService>>(_exparea.GetCatalogAreaExp());
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


        [HttpGet("GetCatCurrency", Name = "GetCatCurrency")]
        public ActionResult<ApiResponse<List<CatalogsCurrencyService>>> GetCatCurrency()
        {
            var response = new ApiResponse<List<CatalogsCurrencyService>>();


            try
            {
                var Result = _mapper.Map<List<CatalogsCurrencyService>>(_currency.GetCatalogCurrency());
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



        [HttpGet("GetCatStateByCountryId", Name = "GetCatStateByCountryId")]
        public ActionResult<ApiResponse<List<CatalogStateService>>> GetCatStateByCountryId(int countryId)
        {

            var response = new ApiResponse<List<CatalogStateService>>();


            try
            {

                var Result = _mapper.Map<List<CatalogStateService>>(_state.GetCatalogStateByCountryId(countryId));
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


        [HttpGet("GetCatState", Name = "GetCatState")]
        public ActionResult<ApiResponse<List<CatalogStateService>>> GetCatState()
        {

            var response = new ApiResponse<List<CatalogStateService>>();


            try
            {

                var Result = _mapper.Map<List<CatalogStateService>>(_state.GetCatalogState());
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

        [HttpGet("GetCatCountry", Name = "GetCatCountry")]
        public ActionResult<ApiResponse<List<CatalogsCountryService>>> GetCatCountry()
        {
            var response = new ApiResponse<List<CatalogsCountryService>>();

            try
            {
                var Result = _mapper.Map<List<CatalogsCountryService>>(_country.GetCatalogCountry());
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

        [HttpGet("GetCatInterest", Name = "GetCatInterest")]
        public ActionResult<ApiResponse<List<catalogsInterestService>>> GetCatInterest()
        {
            var response = new ApiResponse<List<catalogsInterestService>>();

            try
            {
                var Result = _mapper.Map<List<catalogsInterestService>>(_interest.getCatalogInterest());
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

        [HttpPost("deleteInterest", Name = "deleteInterest")]
        public ActionResult<ApiResponse<List<CandidatesCandidateInterest>>> deleteInterest(int Id, int candidateId)
        {
            var response = new ApiResponse<List<CandidatesCandidateInterest>>();

            try
            {
                var InterestCandidate = _candidateInterest.Find(x => x.Id == Id);

                if(InterestCandidate != null)
                {
                    _candidateInterest.Delete(InterestCandidate);


                    List<CandidatesCandidateInterest> ListcandidateInterest = _mapper.Map<List<CandidatesCandidateInterest>>(_candidateInterest.GetCandidateInterestByCandidateId(candidateId));

                    response.Success = true;
                    response.Result = ListcandidateInterest;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Información no encontrada";

                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return StatusCode(201, response);

        }



        [HttpPost("deleteStudies", Name = "deleteStudies")]
        public ActionResult<ApiResponse<List<CandidatesEducation>>> deleteStudies(int Id,int candidateId)
        {

            var response = new ApiResponse<List<CandidatesEducation>>();

            try
            {
                var educationCandidates = _candidatesEducation.Find(i => i.Id == Id);

                if(educationCandidates != null)
                {
                    _candidatesEducation.Delete(educationCandidates);

                    var ListCandidatesEducation = _mapper.Map<List<CandidatesEducation>>(_candidatesEducation.GetAllCandidatesEducation(candidateId));

                    response.Success = true;
                    response.Result = ListCandidatesEducation;
                }
                else
                {

                    response.Success = false;
                    response.Message = "Información no encontrada";

                }




            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }


            return StatusCode(201, response);
        }


        [HttpPost("deleteLanguage",Name ="deleteLanguage")]
        public ActionResult<ApiResponse<List<CandidatesLanguage>>> deleteLanguage(int Id,int candidateId)
        {
            var response = new ApiResponse<List<CandidatesLanguage>>();

            try
            {

                var languageCandidate = _candidatesLanguage.Find(i => i.Id == Id);


                if(languageCandidate != null)
                {

                    _candidatesLanguage.Delete(languageCandidate);

                    var ListCandidatesLanguage = _mapper.Map<List<CandidatesLanguage>>(_candidatesLanguage.GetAllCandidatesLanguage(candidateId));

                    response.Success = true;
                    response.Result = ListCandidatesLanguage;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Información no encontrada";

                }

                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }


            return StatusCode(201, response);
        }


        [HttpPost("deleteWorkExperience", Name = "deleteWorkExperience")]
        public ActionResult<List<CandidatesWorkandsocialexp>> deleteWorkExperience(int Id,int candidateId)
        {

            var response = new ApiResponse<List<CandidatesWorkandsocialexp>>();

            try
            {
                var WorkExperiencice = _candidatesWorkandsocialexp.Find(i => i.Id == Id);

                if(WorkExperiencice != null)
                {
                    _candidatesWorkandsocialexp.Delete(WorkExperiencice);

                    var ListCandidatesWorkExp = _mapper.Map<List<CandidatesWorkandsocialexp>>(_candidatesWorkandsocialexp.getAllCandidatesWorkSocialExp(candidateId));

                    response.Success = true;
                    response.Result = ListCandidatesWorkExp;

                }
                else
                {
                    response.Success = false;
                    response.Message = "Información no encontrada";
                }



                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return StatusCode(201, response);
        }



        [HttpPost("createAccountPostulant", Name = "createAccountPostulant")]
        public ActionResult<ApiResponse<createAccountPostulantService>> createAccountPostulant([FromBody] createAccountPostulantService request,int userid)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            CandidatesCandidate modelCandidate = new CandidatesCandidate();
            CandidatesCandidateInterest modelCandidateInterest = new CandidatesCandidateInterest();
            CandidatesWorkandsocialexp modelWorkandsocicalExp = new CandidatesWorkandsocialexp();
            CandidatesEducation modelEducation = new CandidatesEducation();
            CandidatesLanguage modelLanguage = new CandidatesLanguage();
            CandidatesCandidateExpArea modelExpArea = new CandidatesCandidateExpArea();

            var response = new ApiResponse<createAccountPostulantService>();

            try
            {

                if (request != null)
                {

                    //paso1
                    modelCandidate = _mapper.Map<CandidatesCandidate>(_candidate.Find(i => i.UserId == userid));

                    if (modelCandidate != null)
                    {
                        if (request.whoYouAre != null)
                        {

                            //modelCandidate.Birthday = request.Birthday;
                            modelCandidate.Hobbies = request.whoYouAre.hobbies;
                            modelCandidate.Positivechange = request.whoYouAre.positivechange;
                            modelCandidate.MailJobOffers = request.receiveJobOffers;
                            CandidatesCandidate candidate = _candidate.Update(_mapper.Map<CandidatesCandidate>(modelCandidate), modelCandidate.Id);


                            List<CandidatesCandidateInterest> ListcandidateInterest = _mapper.Map<List<CandidatesCandidateInterest>>(_candidateInterest.GetCandidateInterestByCandidateId(candidate.Id));

                            if (ListcandidateInterest.Count() == 0)
                            {
                                foreach (var item in request.whoYouAre.Interest)
                                {

                                    modelCandidateInterest.Id = 0;
                                    modelCandidateInterest.CandidateId = candidate.Id;
                                    modelCandidateInterest.InterestId = item.id;


                                    CandidatesCandidateInterest candidateInterest = _candidateInterest.Add(_mapper.Map<CandidatesCandidateInterest>(modelCandidateInterest));
                                }
                            }
                            else
                            {
                                foreach (var item in ListcandidateInterest)
                                {
                                    _candidateInterest.Delete(item);
                                }

                                foreach (var item in request.whoYouAre.Interest)
                                {

                                    modelCandidateInterest.Id = 0;
                                    modelCandidateInterest.CandidateId = candidate.Id;
                                    modelCandidateInterest.InterestId = item.id;


                                    CandidatesCandidateInterest candidateInterest = _candidateInterest.Add(_mapper.Map<CandidatesCandidateInterest>(modelCandidateInterest));
                                }
                            }
                        }

                        //paso2
                        if (request.whatAreYouDoing != null)
                        {
                            modelWorkandsocicalExp.Id = request.whatAreYouDoing.id;
                            modelWorkandsocicalExp.Name = request.whatAreYouDoing.name;
                            modelWorkandsocicalExp.Title = request.whatAreYouDoing.title;
                            modelWorkandsocicalExp.WorkFrom = request.whatAreYouDoing.work_from;
                            modelWorkandsocicalExp.WorkTo = request.whatAreYouDoing.work_to;
                            modelWorkandsocicalExp.ActualJob = request.whatAreYouDoing.actual_job;
                            modelWorkandsocicalExp.CreatedById = userid;
                            modelWorkandsocicalExp.CandidateId = request.whatAreYouDoing.candidateId;
                            modelWorkandsocicalExp.City = request.whatAreYouDoing.city;
                            modelWorkandsocicalExp.CountryId = request.whatAreYouDoing.country_id;
                            modelWorkandsocicalExp.WorkFromMonth = request.whatAreYouDoing.work_from_month;
                            modelWorkandsocicalExp.WorkToMonth = request.whatAreYouDoing.work_to_month;
                            modelWorkandsocicalExp.WorkFromYear = request.whatAreYouDoing.work_from_year;
                            modelWorkandsocicalExp.WorkToYear = request.whatAreYouDoing.work_to_year;
                            modelWorkandsocicalExp.UpdatedById = userid;
                            modelWorkandsocicalExp.Description = request.whatAreYouDoing.description;
                            modelWorkandsocicalExp.Volunteering = request.whatAreYouDoing.Volunteering;


                            if (modelWorkandsocicalExp.Id == 0)
                            {
                                CandidatesWorkandsocialexp candidatework = _candidatesWorkandsocialexp.Add(_mapper.Map<CandidatesWorkandsocialexp>(modelWorkandsocicalExp));
                            }
                            else
                            {
                                CandidatesWorkandsocialexp candidatework = _candidatesWorkandsocialexp.Update(_mapper.Map<CandidatesWorkandsocialexp>(modelWorkandsocicalExp), modelWorkandsocicalExp.Id);

                            }

                            var ListCandidatesWorkExp = _mapper.Map<List<CandidatesWorkandsocialexp>>(_candidatesWorkandsocialexp.getAllCandidatesWorkSocialExp(modelCandidate.Id));

                            request.listworkandsocialexp = ListCandidatesWorkExp;


                        }


                        //Paso3
                        if (request.studies != null)
                        {

                            modelEducation.Id = request.studies.id;
                            modelEducation.Institution = request.studies.institution;
                            modelEducation.Grade = request.studies.grade;
                            modelEducation.StudiedFrom = request.studies.studied_from;
                            modelEducation.StudiedTo = request.studies.studied_to;
                            modelEducation.ActualStudent = request.studies.actual_student;
                            modelEducation.CreatedById = userid;
                            modelEducation.CandidateId = request.studies.candidateId;
                            modelEducation.ProfessionId = request.studies.professionId;
                            modelEducation.City = request.studies.city;
                            modelEducation.CountryId = request.studies.country_id;
                            modelEducation.UpdatedById = userid;
                            modelEducation.Discipline = "";
                            modelEducation.StudiedFromMonth = request.studies.studied_from_month;
                            modelEducation.StudiedToMonth = request.studies.studied_to_month;
                            modelEducation.StudiedFromYear = request.studies.studied_from_year;
                            modelEducation.StudiedToYear = request.studies.studied_to_year;
                            modelEducation.NameProfession = request.studies.nameProfession;

                            if (modelEducation.Id == 0)
                            {
                                CandidatesEducation candidateEducation = _candidatesEducation.Add(_mapper.Map<CandidatesEducation>(modelEducation));
                            }
                            else
                            {
                                CandidatesEducation candidateEducation = _candidatesEducation.Update(_mapper.Map<CandidatesEducation>(modelEducation), modelEducation.Id);
                            }


                            var ListCandidatesEducation = _mapper.Map<List<CandidatesEducation>>(_candidatesEducation.GetAllCandidatesEducation(modelCandidate.Id));

                            request.listEducation = ListCandidatesEducation;



                        }

                        //paso4

                        if (request.language != null)
                        {
                            modelLanguage.Id = request.language.id;
                            modelLanguage.OralLevel = request.language.oral_level;
                            modelLanguage.WrittenLevel = request.language.written_level;
                            modelLanguage.CandidateId = request.language.candidateId;
                            modelLanguage.CreatedById = userid;
                            modelLanguage.LanguageId = request.language.languajeid;
                            modelLanguage.UpdatedById = userid;

                            if (modelLanguage.Id == 0)
                            {
                                CandidatesLanguage candidateLanguage = _candidatesLanguage.Add(_mapper.Map<CandidatesLanguage>(modelLanguage));
                            }
                            else
                            {
                                CandidatesLanguage candidateLanguage = _candidatesLanguage.Update(_mapper.Map<CandidatesLanguage>(modelLanguage), modelLanguage.Id);
                            }

                            var ListCandidatesLanguage = _mapper.Map<List<CandidatesLanguage>>(_candidatesLanguage.GetAllCandidatesLanguage(modelCandidate.Id));

                            request.listlanguage = ListCandidatesLanguage;


                        }

                        if (request.whatAreYouLooking != null)
                        {

                            //paso5
                            modelCandidate.Avaliability = request.whatAreYouLooking.avaliability;
                            modelCandidate.CurrencyId = request.whatAreYouLooking.currencyId;
                            modelCandidate.SalaryMax = request.whatAreYouLooking.salary_max;
                            modelCandidate.Position = request.whatAreYouLooking.position;

                            var candidate = _candidate.Update(_mapper.Map<CandidatesCandidate>(modelCandidate), modelCandidate.Id);


                            if (request.whatAreYouLooking.id_area != 0)
                            {

                                modelExpArea.ExpareaId = request.whatAreYouLooking.id_area;
                                modelExpArea.CandidateId = request.whatAreYouLooking.candidateId;

                                List<CandidatesCandidateExpArea> exparea = _mapper.Map<List<CandidatesCandidateExpArea>>(_candidatesCandidateExpArea.GetCandidateExpAreByCandidateId(modelExpArea.CandidateId));



                                


                                if (exparea.Count == 0)
                                {
                                    CandidatesCandidateExpArea candidateArea = _candidatesCandidateExpArea.Add(_mapper.Map<CandidatesCandidateExpArea>(modelExpArea));
                                }



                            }

                        }



                        if(request.receiveJobOffers)
                        {
                            var user = _userRepository.Find(x => x.Id == userid);


                            if (user != null)
                            {
                                modelEmail.To = user.Email;
                                modelEmail.Subject = "Todas las novedades en tu mail 📩";
                                modelEmail.IsBodyHtml = true;
                                modelEmail.Body = "";


                                var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_confirmacion_registro_boletin_postulantes.html");
                                _serviceEmail.SendEmailMailing(html, modelEmail, user.FirstName,"");
                            }

                        }

                        response.Success = true;
                        response.Result = request;
                    }




                }
                else
                {
                    response.Success = true;
                    response.Message = "La estructura del modelo que esta enviando no esta la correcta, verifique.";
                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });
            }

            return StatusCode(201, response);
        }




    }
}
