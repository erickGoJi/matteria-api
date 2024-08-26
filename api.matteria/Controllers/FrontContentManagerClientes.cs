using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.ActionFilter;
using api.matteria.Models.clientes;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Models.FrontContentManager_clientes;
using biz.matteria.Repository.FrontContentManagerClientes;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentManagerClientes : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentManagerClientes _frontclientes;

        public FrontContentManagerClientes(AutoMapper.IMapper mapper,
         ILoggerManager logger,
         IFrontContentManagerClientes frontClientes)
        {
            _mapper = mapper;
            _logger = logger;
            _frontclientes = frontClientes;

        }


        [HttpGet("GetServiceFontContentManagerClientes", Name = "GetServiceFontContentManagerClientes")]
        [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
        public ActionResult<ApiResponse<clientes>> GetServiceFontContentManagerClientes(int type,int languageId=1)
        {

            clientes modelResponse = new clientes();

            var response = new ApiResponse<clientes>();
            try
            {
                modelResponse.listaClientes = _mapper.Map<List<FrontContentManagerClientesService>>(_frontclientes.GetAllClientes(type));

                modelResponse.clientesheader = _mapper.Map<FrontContentManagerNuestrosclientesinfo>(_frontclientes.getClientesHeader(languageId));




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
