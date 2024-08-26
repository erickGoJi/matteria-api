using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentEstructuraSalarial;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentEstructuraSalarialController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentEstructuraSalarial _estructurasalarial;

        public FrontContentEstructuraSalarialController(IMapper mapper
            ,IFrontContentEstructuraSalarial estructuraSalarial
            , ILoggerManager logger)
        {
            _mapper = mapper;
            _logger = logger;
            _estructurasalarial = estructuraSalarial;
        }


        [HttpGet("GetEstructuraSalarial", Name = "GetEstructuraSalarial")]
        public ActionResult<ApiResponse<FrontContentEstructuraSalarial>> GetEstructuraSalarial(int languajeId=1)
        {
            var response = new ApiResponse<FrontContentEstructuraSalarial>();

            try
            {

                var Result = _mapper.Map<FrontContentEstructuraSalarial>(_estructurasalarial.GetEstructuraSalarial(languajeId));
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
