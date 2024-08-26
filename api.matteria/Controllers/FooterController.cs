using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Models.Footer;
using biz.matteria.Repository.Footer;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFooter _footer;


        public FooterController(IMapper mapper,
            ILoggerManager logger,
            IFooter footer)
        {
            _mapper = mapper;
            _logger = logger;
            _footer = footer;

        }


        [HttpGet("GetFooter", Name = "GetFooter")]
        public ActionResult<ApiResponse<List<footerResponse>>> GetFooter(int languaje)
        {

            var response = new ApiResponse<List<footerResponse>>();


            try
            {
                var result = _mapper.Map<List<footerResponse>>(_footer.GetFooter(languaje));
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
