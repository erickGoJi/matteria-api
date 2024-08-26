using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.OurADN;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentOurADN;
using biz.matteria.Repository.FrontContentOurADNHead;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentOurADNController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentOurADN _ourADN;
        private readonly IFrontContentOurADNHead _ourADNHead;

        public FrontContentOurADNController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentOurADN ourADN,
            IFrontContentOurADNHead ourADNHead)
        {
            _mapper = mapper;
            _logger = logger;
            _ourADN = ourADN;
            _ourADNHead = ourADNHead;

        }

        [HttpGet("GetFrontContentOurADN", Name = "GetFrontContentOurADN")]
        public ActionResult<ApiResponse<OurADN>> GetFrontContentOurADN(int languageId=1)
        {
            OurADN modelResponse = new OurADN();

            var response = new ApiResponse<OurADN>();

            try
            {
                var ResulADN = _mapper.Map<List<FrontContentOurAdn>>(_ourADN.GetOurADN(languageId));

                var ResulADNHead = _mapper.Map<FrontContentOurAdnhead>(_ourADNHead.GetOurADNHead(languageId));


                modelResponse.ourADN = ResulADN;
                modelResponse.ourADNHead = ResulADNHead;

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
