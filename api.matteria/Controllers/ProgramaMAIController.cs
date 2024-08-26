using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.ProgramaMAI;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.ProgramaMAI;
using biz.matteria.Repository.ProgramaMAIModelo;
using biz.matteria.Repository.ProgramaMAIobjectives;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaMAIController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IProgramaMAI _programa;
        private readonly IProgramaMAIobjectives _programaObjetives;
        private readonly IProgramaMAIModelo _programaModelo;


        public ProgramaMAIController(IMapper mapper,
            ILoggerManager logger,
            IProgramaMAI programa,
            IProgramaMAIobjectives programaObjetives,
            IProgramaMAIModelo programaModelo)
        {
            _mapper = mapper;
            _logger = logger;
            _programa = programa;
            _programaObjetives = programaObjetives;
            _programaModelo = programaModelo;

        }

        [HttpGet("GetProgramaMAI", Name = "GetProgramaMAI")]
        public ActionResult<ApiResponse<responseProgramaMAI>> GetProgramaMAI(int languajeId=1)
        {
            responseProgramaMAI modelResponse = new responseProgramaMAI();

            var response = new ApiResponse<responseProgramaMAI>();

            try
            {
                var prorgramaMAI = _mapper.Map<ProgramaMai>(_programa.GetProgramaMAI(languajeId));

                var prorgramaMAIObjectives = _mapper.Map<List<ProgramaMaiobjective>>(_programaObjetives.GetProgramaMAIObjetives(languajeId));

                var programaMAIModelo = _mapper.Map<List<ProgramaMaimodelo>>(_programaModelo.GetProrgramaMAIModelo(languajeId));



                modelResponse.prorgramaMAI = prorgramaMAI;
                modelResponse.programaMAIModelo = programaMAIModelo;
                modelResponse.prorgramaMAIObjectives = prorgramaMAIObjectives;


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
