using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontContentRecruiting;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentRecruitingComoEs;
using biz.matteria.Repository.FrontContentRecruitingComoEsHeader;
using biz.matteria.Repository.FrontContentRecruitingHeader;
using biz.matteria.Repository.FrontContentRecruitingPassive;
using biz.matteria.Repository.FrontContentRecruitingPassiveHeader;
using biz.matteria.Repository.FrontContentReruitingPorQueContratarnos;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentRecruitingController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentRecruitingComoEs _comoEs;
        private readonly IFrontContentRecruitingComoEsHeader _comoEsHeader;
        private readonly IFrontContentRecruitingHeader _recruitingHeader;
        private readonly IFrontContentRecruitingPassive _recruitingPassive;
        private readonly IFrontContentRecruitingPassiveHeader _recruitingPassiveHeader;
        private readonly IFrontContentReruitingPorQueContratarnos _contratarnos;

        public FrontContentRecruitingController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentRecruitingComoEs comoEs,
            IFrontContentRecruitingComoEsHeader comoEsHeader,
            IFrontContentRecruitingHeader recruitingHeader,
            IFrontContentRecruitingPassive recruitingPassive,
            IFrontContentRecruitingPassiveHeader recruitingPassiveHeader,
            IFrontContentReruitingPorQueContratarnos contratarnos)
        {
            _mapper = mapper;
            _logger = logger;
            _comoEs = comoEs;
            _comoEsHeader = comoEsHeader;
            _recruitingHeader = recruitingHeader;
            _recruitingPassive = recruitingPassive;
            _recruitingPassiveHeader = recruitingPassiveHeader;
            _contratarnos = contratarnos;

        }

        [HttpGet("GetFrontContenRecruiting", Name = "GetFrontContenRecruiting")]
        public ActionResult<ApiResponse<FrontContentCruiting>> GetFrontContenRecruiting(int languajeId)
        {
            FrontContentCruiting modelResponse = new FrontContentCruiting();

            var response = new ApiResponse<FrontContentCruiting>();

            try
            {
                //var comoEs = _mapper.Map<List<FrontContentRecruitingComo>>(_comoEs.GetRecruitingComoEs(languajeId));

                var comoEsHeader = _mapper.Map<List<FrontContentRecruitingComoEsHeader>>(_comoEsHeader.GetRecruitingComoEsHeader(languajeId));


                var recruitingHeader = _mapper.Map<FrontContentRecruitingHeader>(_recruitingHeader.GetRecruitingHeader(languajeId));


                var recruitingPassive = _mapper.Map<List<FrontContentRecruitingPassive>>(_recruitingPassive.GetRecruitingPassive(languajeId));


                var recruitingPassiveHeader = _mapper.Map<FrontContentRecruitingPassiveHeader>(_recruitingPassiveHeader.GetRecruitingPassiveHeader(languajeId));


                var comoContratarnos = _mapper.Map<List<FrontContentReruitingPorQueContratarno>>(_contratarnos.GetRecruitingPorQueContratarnos(languajeId));


                modelResponse.comoContratarnos = comoContratarnos;
                //modelResponse.comoEs = comoEs;
                modelResponse.comoEsHeader = comoEsHeader;
                modelResponse.recruitingHeader = recruitingHeader;
                modelResponse.recruitingPassive = recruitingPassive;
                modelResponse.recruitingPassiveHeader = recruitingPassiveHeader;

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
