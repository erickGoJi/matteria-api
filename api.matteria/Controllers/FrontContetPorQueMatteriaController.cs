using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.porqueMatteria;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models.openingCubiertas;
using biz.matteria.Repository.FrontContentPorQueMatteria;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContetPorQueMatteriaController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentPorQueMatteria _porquemateria;
        private readonly IopeningsOpening _opening;

        public FrontContetPorQueMatteriaController(IMapper mapper,
            ILoggerManager logger,
            IFrontContentPorQueMatteria porQueMatteria,
            IopeningsOpening opening)
        {
            _mapper = mapper;
            _logger = logger;
            _porquemateria = porQueMatteria;
            _opening = opening;

        }



        [HttpGet("GetPorqueMatteria", Name = "GetPorqueMatteria")]
        public ActionResult<ApiResponse<List<porqueMatteria>>> GetPorqueMatteria(int languajeid=1)
        {
            porqueMatteria modelResponse = new porqueMatteria();
            var response = new ApiResponse<porqueMatteria>();

            try
            {

                modelResponse.porqueMatteri = _mapper.Map<List<FrontContentPorqueMatterium>>(_porquemateria.GetFrontContentPorqueMatteria(languajeid));


                modelResponse.vacantesCubiertas = _mapper.Map<List<openingCubiertas>>(_opening.GetOpeningCubiertas());

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

    }
}
