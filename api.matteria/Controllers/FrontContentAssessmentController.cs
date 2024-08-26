using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontAssessment;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContent_comofunciona_assessment_detail;
using biz.matteria.Repository.FrontContentAssessment;
using biz.matteria.Repository.FrontContentcomofunciona_assessment;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentAssessmentController : ControllerBase
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentAssessment _assesment;
        private readonly IFrontContentComofuncionaAssessment _comoassesmente;
        private readonly IFrontContentComofuncionaAssessmentDetail _comoassesmentdetail;

        public FrontContentAssessmentController(AutoMapper.IMapper mapper,
         ILoggerManager logger,
         IFrontContentAssessment assesment,
         IFrontContentComofuncionaAssessment comoassesmente,
         IFrontContentComofuncionaAssessmentDetail comoassesmentdetail)
        {
            _mapper = mapper;
            _logger = logger;
            _assesment = assesment;
            _comoassesmente = comoassesmente;
            _comoassesmentdetail = comoassesmentdetail;


        }

        [HttpGet("GetFrontManagerAssessment", Name = "GetFrontManagerAssessment")]
        public ActionResult<ApiResponse<frontAssessment>> GetFrontManagerAssessment(int languajeId= 1)
        {
            frontAssessment modelResponse = new frontAssessment();

            var response = new ApiResponse<frontAssessment>();

            try
            { 
                var resultAssessment = _mapper.Map<FrontContentAssessment>(_assesment.GetFrontContentAssessmentHeader(languajeId));

                var resultComoFuncionaAssessment = _mapper.Map<List<FrontContentComofuncionaAssessment>>(_comoassesmente.GetFrontContentcomofuncionaAssesment(languajeId));

                var resultComoFuncionaAssesmentDetail = _mapper.Map<List<FrontContentComofuncionaAssessmentDetail>>(_comoassesmentdetail.GetFrontComoFuncionaAssessmentDetail());

                modelResponse.frontheaderassessment = resultAssessment;
                modelResponse.frontcomofuncionaAssesment = resultComoFuncionaAssessment;
                modelResponse.frontcomofuncionaAssessmentDetail = resultComoFuncionaAssesmentDetail;




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
