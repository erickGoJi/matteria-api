using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Models.MenuPrincipal;
using biz.matteria.Repository.MenuPrincipal;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuPrincipalController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IMenuPrincipal _menu;


        public MenuPrincipalController(IMapper mapper,
            ILoggerManager logger,
            IMenuPrincipal menu)
        {
            _mapper = mapper;
            _logger = logger;
            _menu = menu;

        }


        [HttpGet("GetMenuPrincipal", Name = "GetMenuPrincipal")]
        public ActionResult<ApiResponse<List<menuPrincipalResponse>>> GetMenuPrincipal(int languaje)
        {

            var response = new ApiResponse<List<menuPrincipalResponse>>();


            try
            {
                var result = _mapper.Map<List<menuPrincipalResponse>>(_menu.getMenuPrincipal(languaje));
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
