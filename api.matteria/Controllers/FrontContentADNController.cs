using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontADN;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentADN;
using biz.matteria.Repository.FrontContentBeneficiosADN;
using biz.matteria.Repository.FrontContentEnqueconsisteADN;
using biz.matteria.Repository.FrontContentEnqueconsisteADNHeader;
using biz.matteria.Repository.FrontContentObjetivosADN;
using biz.matteria.Repository.FrontContentObjetivosADNHeader;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentADNController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentBeneficiosADN _beneficiosadn;
        private readonly IFrontContentADN _contentadn;
        private readonly IFrontContentEnqueconsisteADN _consisteAdn;
        private readonly IFrontContentEnqueconsisteADNHeader _consisteAdnHeader;
        private readonly IFrontContentObjetivosADN _objetivosAdn;
        private readonly IFrontContentObjetivosADNHeader _objetivosAdnHeader;


        public FrontContentADNController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentBeneficiosADN beneficiosADN,
            IFrontContentADN contentADN,
            IFrontContentEnqueconsisteADN consisteAdn,
            IFrontContentEnqueconsisteADNHeader consisteAdnHeader,
            IFrontContentObjetivosADN objetivosAdn,
            IFrontContentObjetivosADNHeader objetivosAdnHeader)
        {
            _mapper = mapper;
            _logger = logger;
            _beneficiosadn = beneficiosADN;
            _contentadn = contentADN;
            _consisteAdn = consisteAdn;
            _consisteAdnHeader = consisteAdnHeader;
            _objetivosAdn = objetivosAdn;
            _objetivosAdnHeader = objetivosAdnHeader;


        }

        [HttpGet("GetFrontContentADN", Name = "GetFrontContentADN")]
        public ActionResult<ApiResponse<FrontContentADN>> GetFrontContentADN(int languajeId=1)
        {
            FrontContentADN modelResponse = new FrontContentADN();

            var response = new ApiResponse<FrontContentADN>();

            try
            {
                var ResulADN = _mapper.Map<FrontContentAdnHeader>(_contentadn.GetFrontADNHeader(languajeId));

                var ResultBeneficiosADN = _mapper.Map<List<FrontContentBeneficiosAdn>>(_beneficiosadn.GetBeneficiosADN(languajeId));

                var ResultenqueconsisteADN = _mapper.Map<List<FrontContentEnqueconsisteAdn>>(_consisteAdn.getEnqueConsisteADN(languajeId));

                var ResultenqueconsisteADNHeader = _mapper.Map<FrontContentEnqueconsisteAdnHeader>(_consisteAdnHeader.GetHeadEnqueConsisteADN(languajeId));


                var ResultobjetivosADN = _mapper.Map<List<FrontContentObjetivosAdn>>(_objetivosAdn.GetObjetivosADN());

                var ResultobjetivosADNHeader = _mapper.Map<FrontContentObjetivosAdnHeader>(_objetivosAdnHeader.GetHeaderObjetivosADN());


                modelResponse.beneficiosADN = ResultBeneficiosADN;
                modelResponse.contentADN = ResulADN;
                modelResponse.enqueconsisteADN = ResultenqueconsisteADN;
                modelResponse.enqueconsisteADNHeader = ResultenqueconsisteADNHeader;
                modelResponse.objetivosADN = ResultobjetivosADN;
                modelResponse.objetivosADNHeader = ResultobjetivosADNHeader;

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
