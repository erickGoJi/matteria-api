using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Models.consultoriaOrganizacional;
using biz.matteria.Repository.ConsultoriaOrganizacional;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontConsultoriaOrganizacionalController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IConsultoriaOrganizacional _corganizacional;


        public FrontConsultoriaOrganizacionalController(IMapper mapper,
            ILoggerManager logger,
            IConsultoriaOrganizacional corganizacional)
        {
            _mapper = mapper;
            _logger = logger;
            _corganizacional = corganizacional;
        }


        [HttpGet("GetConsultoriaOrganizacional", Name = "GetConsultoriaOrganizacional")]
        public ActionResult<ApiResponse<consultoriaOrganizacionalService>> GetConsultoriaOrganizacional(int lenguajeId)
        {

            var response = new ApiResponse<consultoriaOrganizacionalService>();


            try
            {
                var result = _mapper.Map<consultoriaOrganizacionalService>(_corganizacional.GetConsultoriaOrganizacional(lenguajeId));
                response.Success = true;
                response.Result = result;

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
