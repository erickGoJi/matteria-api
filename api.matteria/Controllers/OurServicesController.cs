using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.OurServices;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.OurServices;
using biz.matteria.Repository.OurServicesHeader;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IOurServices _ourservices;
        private readonly IOurServicesHeader _ourServicesHeader;

        public OurServicesController(IMapper mapper,
            ILoggerManager logger,
            IOurServices ourservices,
            IOurServicesHeader ourServicesHeader)
        {
            _mapper = mapper;
            _logger = logger;
            _ourservices = ourservices;
            _ourServicesHeader = ourServicesHeader;

        }



        [HttpGet("GetOurServicesAndHeader", Name = "GetOurServicesAndHeader")]
        public ActionResult<ApiResponse<OurServicesAndHeader>> GetOurServicesAndHeader(int languageId=1)
        {

            OurServicesAndHeader modelResponse = new OurServicesAndHeader();
            var response = new ApiResponse<OurServicesAndHeader>();

            try
            {
                var ResultOurServices = _mapper.Map<List<FrontContentManagerNuestrosservicio>>(_ourservices.GetOurServices(languageId));

                var ResultOurServicesHeader = _mapper.Map<FrontContentManagerNuestrosserviciosHeader>(_ourServicesHeader.GetOurServicesHeader(languageId));

                modelResponse.ourServices = ResultOurServices;
                modelResponse.ourServicesHeader = ResultOurServicesHeader;


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
