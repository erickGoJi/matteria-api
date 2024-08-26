using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontOnboarding;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeaderDetail;
using biz.matteria.Repository.FrontHeaderOnboarding;
using biz.matteria.Services.Logger;
using dal.matteria.Repository.FrontComoFuncionaOnboardingDetail;
using dal.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using dal.matteria.Repository.FrontHeaderOnboarding;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentManagerOnboardingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontOnboardingHeader _onboardinghead;
        private readonly IFrontComoFuncionaOnboardingHeaderDetail _comoonboardingdetail;
        private readonly IFrontComoFuncionaOnboardingHeader _comoonboarding;


        public FrontContentManagerOnboardingController(IMapper mapper,
            ILoggerManager logger,
            IFrontOnboardingHeader onboardinghead,
            IFrontComoFuncionaOnboardingHeaderDetail comoonboardingdetail,
            IFrontComoFuncionaOnboardingHeader comoonboarding


            )
        {
            _mapper = mapper;
            _logger = logger;
            _onboardinghead = onboardinghead;
            _comoonboardingdetail = comoonboardingdetail;
            _comoonboarding = comoonboarding;



        }



        [HttpGet("GetFrontManagerOnboarding", Name = "GetFrontManagerOnboarding")]
        public ActionResult<ApiResponse<FrontOnboarding>> GetFrontManagerOnboarding()
        {

            FrontOnboarding modelResponse = new FrontOnboarding();

            var response = new ApiResponse<FrontOnboarding>();


            try
            {
                var ResultOnboardingHead = _mapper.Map<FrontContentManagerConsulOnbiardingHeader> (_onboardinghead.GetContentConultOnboardingHeader());


                var ResultComoFuncionaOnboarding = _mapper.Map<FrontContentManagerComofuncionaHeaderOnboarding>(_comoonboarding.GetComoFuncionaOnboardingHeader());

                var ResultComoFuncionaOnboardingDetail = _mapper.Map<List<FrontContentComofuncionaDetailOnboarding>>(_comoonboardingdetail.GetComoFuncionaOnboardingDetail());

                modelResponse.headOnboardingfront = ResultOnboardingHead;
                modelResponse.frontcomofuncionaOnboarding = ResultComoFuncionaOnboarding;
                modelResponse.frontcomofuncionaOnboardingdetail = ResultComoFuncionaOnboardingDetail;


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



        }
    }
