using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models.CV;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CandidatesCandidateExpArea;
using biz.matteria.Repository.CandidatesCandidateInterest;
using biz.matteria.Repository.CandidatesEducation;
using biz.matteria.Repository.CandidatesExpSector;
using biz.matteria.Repository.CandidatesLanguage;
using biz.matteria.Repository.CandidatesWorkandsocialexp;
using biz.matteria.Repository.CatalogsExparea;
using biz.matteria.Repository.User;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICandidatesCandidate _candidate;
        private readonly ICandidatesCandidateInterest _candidateInterest;
        private readonly ICandidatesWorkandsocialexp _candidatesWorkandsocialexp;
        private readonly ICandidatesEducation _candidatesEducation;
        private readonly ICandidatesLanguage _candidatesLanguage;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly ICandidatesExpSector _expsector;
        private readonly ICatalogsExparea _exparea;
        private readonly ICandidatesCandidateExpArea _candidatesCandidateExpArea;
        private readonly IUserRepository _userRepository;

        public CVController(IMapper mapper,
            ILoggerManager logger,
            ICandidatesCandidate candidate,
            ICandidatesWorkandsocialexp candidatesWorkandsocialexp,
            ICandidatesEducation candidatesEducation,
            ICandidatesLanguage candidatesLanguage,
            ICandidatesCandidateInterest candidateInterest,
            IWebHostEnvironment hostingEnv,
            ICandidatesExpSector expSector,
            ICatalogsExparea exparea,
            ICandidatesCandidateExpArea candidatesCandidateExpArea,
            IUserRepository userrepository)
        {
            _mapper = mapper;
            _logger = logger;
            _candidate = candidate;
            _candidatesWorkandsocialexp = candidatesWorkandsocialexp;
            _candidatesEducation = candidatesEducation;
            _candidatesLanguage = candidatesLanguage;
            _candidateInterest = candidateInterest;
            _hostingEnv = hostingEnv;
            _expsector = expSector;
            _exparea = exparea;
            _candidatesCandidateExpArea = candidatesCandidateExpArea;
            _userRepository = userrepository;
        }


        [HttpPost("updateAccountPostulant", Name = "updateAccountPostulant")]
        public ActionResult<ApiResponse<candidatesCandidateService>> updateAccountPostulant(candidatesCandidateService request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;
            candidatesCandidateService modelFinal = new candidatesCandidateService();
            CandidatesCandidateInterest modelCandidateInterest = new CandidatesCandidateInterest();



            var response = new ApiResponse<candidatesCandidateService>();

            try
            {
                if(request != null)
                {
                    var candidate = _candidate.Find(x => x.Id == request.Id);

                    if(candidate != null)
                    {

                        if(!string.IsNullOrEmpty(request.avatarbase64))
                        {
                            //request.avatarbase64 = request.avatarbase64.Replace("data:image/jpeg;base64,", "");

                            imageBytes = Convert.FromBase64String(request.avatarbase64);


                            if (imageBytes.Length > 0)
                            {

                                filePath = Path.Combine(_hostingEnv.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

                                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    fileStream.Write(imageBytes, 0, imageBytes.Length);
                                }

                            }


                            Uri baseUri = new Uri(filePath);

                            pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                            pathFileFinal = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                            candidate.Avatar = pathFileFinal;
                        }


                        var user = _userRepository.Find(x => x.Id == candidate.UserId);

                        if(user != null)
                        {

                            user.FirstName = request.name;
                            user.LastName = request.lastname;

                            user = _userRepository.Update(_mapper.Map<AuthUser>(user), user.Id);


                        }


                        candidate.Id = request.Id;
                        candidate.City = request.City;
                        candidate.CountryId = request.CountryId;
                        candidate.Birthday = request.Birthday;
                        candidate.Genre = request.Genre;
                        candidate.CellphoneNumber = request.CellphoneNumber;
                        candidate.Positivechange = request.Positivechange;
                        candidate.Hobbies = request.Hobbies;
                        candidate.SalaryMax = request.salary_max;
                        candidate.Position = request.position;
                        candidate.CurrencyId = request.currencyId;
                        

                        CandidatesCandidate candidateUpdate = _candidate.Update(_mapper.Map<CandidatesCandidate>(candidate), candidate.Id);

                    }




                    List<CandidatesCandidateInterest> ListcandidateInterest = _mapper.Map<List<CandidatesCandidateInterest>>(_candidateInterest.GetCandidateInterestByCandidateId(candidate.Id));

                    if (ListcandidateInterest.Count() == 0)
                    {
                        foreach (var item in request.Interest)
                        {

                            modelCandidateInterest.Id = 0;
                            modelCandidateInterest.CandidateId = request.Id;
                            modelCandidateInterest.InterestId = item.interest_id;


                            CandidatesCandidateInterest candidateInterest = _candidateInterest.Add(_mapper.Map<CandidatesCandidateInterest>(modelCandidateInterest));
                        }

                    }
                    else
                    {

                        foreach (var item in ListcandidateInterest)
                        {
                            _candidateInterest.Delete(item);
                        }

                        foreach (var item in request.Interest)
                        {

                            modelCandidateInterest.Id = 0;
                            modelCandidateInterest.CandidateId = request.Id;
                            modelCandidateInterest.InterestId = item.interest_id;


                            CandidatesCandidateInterest candidateInterest = _candidateInterest.Add(_mapper.Map<CandidatesCandidateInterest>(modelCandidateInterest));
                        }


                    }



                    if (request.listworkandsocialexp != null)
                    {
                        foreach (var item in request.listworkandsocialexp)
                        {

                            if (item.Id == 0)
                            {
                                CandidatesWorkandsocialexp candidatework = _candidatesWorkandsocialexp.Add(_mapper.Map<CandidatesWorkandsocialexp>(item));
                            }
                            else
                            {
                                CandidatesWorkandsocialexp candidatework = _candidatesWorkandsocialexp.Update(_mapper.Map<CandidatesWorkandsocialexp>(item), item.Id);

                            }

                        }
                    }


                    if (request.listEducation != null)
                    {
                        foreach (var item in request.listEducation)
                        {
                            if (item.Id == 0)
                            {
                                CandidatesEducation candidateEducation = _candidatesEducation.Add(_mapper.Map<CandidatesEducation>(item));
                            }
                            else
                            {
                                CandidatesEducation candidateEducation = _candidatesEducation.Update(_mapper.Map<CandidatesEducation>(item), item.Id);
                            }


                        }
                    }


                    if (request.listlanguage != null)
                    {
                        foreach (var item in request.listlanguage)
                        {
                            if (item.Id == 0)
                            {
                                CandidatesLanguage candidateLanguage = _candidatesLanguage.Add(_mapper.Map<CandidatesLanguage>(item));
                            }
                            else
                            {
                                CandidatesLanguage candidateLanguage = _candidatesLanguage.Update(_mapper.Map<CandidatesLanguage>(item), item.Id);
                            }


                        }
                    }



                    if(request.listExpSector != null)
                            {
                        foreach (var item in request.listExpSector)
                        {
                            if (item.Id == 0)
                            {
                                CandidatesCandidateExpSector candidatesexpSector = _expsector.Add(_mapper.Map<CandidatesCandidateExpSector>(item));
                            }
                            else
                            {
                                CandidatesCandidateExpSector candidatesexpSector = _expsector.Update(_mapper.Map<CandidatesCandidateExpSector>(item), item.Id);
                            }

                        }
                    }

                    if (request.listAreaExp != null)
                    {
                        foreach (var item in request.listAreaExp)
                        {
                            if (item.Id == 0)
                            {
                                CandidatesCandidateExpArea candidatesexpSector = _candidatesCandidateExpArea.Add(_mapper.Map<CandidatesCandidateExpArea>(item));
                            }
                            else
                            {
                                CandidatesCandidateExpArea candidatesexpSector = _candidatesCandidateExpArea.Update(_mapper.Map<CandidatesCandidateExpArea>(item), item.Id);
                            }

                        }
                    }


                    var Result = _mapper.Map<candidatesCandidateService>(_candidate.GetCandidatesCV(0, candidate.Id));


                    response.Success = true;
                    response.Result = Result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No hay información recibida.";

                }


            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return StatusCode(201, response);


        }


        [HttpGet("GetCVCandidate", Name = "GetCVCandidate")]
        public ActionResult<ApiResponse<candidatesCandidateService>> GetCVCandidate(int userid,int candidateid)
        {

            var response = new ApiResponse<candidatesCandidateService>();

            try
            {

                var Result = _mapper.Map<candidatesCandidateService>( _candidate.GetCandidatesCV(userid,candidateid));
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
