using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models.MetodosPagoCountry;
using biz.matteria.Repository.MetodosPagoCountry;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosPagoCountryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IMetodosPagoCountry _metodopagocountry;

        public MetodosPagoCountryController(IMapper mapper,
            ILoggerManager logger,
            IMetodosPagoCountry metodosPagoCountry)
        {
            _mapper = mapper;
            _logger = logger;
            _metodopagocountry = metodosPagoCountry;

        }


        [HttpGet("GetMetodosPago", Name = "GetMetodosPago")]
        public ActionResult<ApiResponse<List<MetodosPago>>> GetMetodosPago()
        {


            var response = new ApiResponse<List<MetodosPago>>();

            try
            {
                var Result = _mapper.Map<List<MetodosPago>>(_metodopagocountry.GetMetodosPago());
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




        [HttpGet("GetMetodosPagoCountry", Name = "GetMetodosPagoCountry")]
        public ActionResult<ApiResponse<List<MetodosPagoCountryModel>>> GetMetodosPagoCountry()
        {
            

            var response = new ApiResponse<List<MetodosPagoCountryModel>>();

            try
            {
                var Result = _mapper.Map<List<MetodosPagoCountryModel>>(_metodopagocountry.GetMetodosPagoCountry());
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
