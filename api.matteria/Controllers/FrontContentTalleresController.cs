using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontContentTalleres;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentTalleresHeader;
using biz.matteria.Repository.FrontContentTalleresObjetivos;
using biz.matteria.Repository.FrontContentTalleresTemasDetail;
using biz.matteria.Repository.FrontContentTalleresTemasHead;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentTalleresController : ControllerBase
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentTalleresHeader _talleresheader;
        private readonly IFrontContentTalleresObjetivos _talleresobjetivos;
        private readonly IFrontContentTalleresTemasDetail _tallerestemasdetail;
        private readonly IFrontContentTalleresTemasHead _tallerestemashead;

        public FrontContentTalleresController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentTalleresHeader talleresheader,
            IFrontContentTalleresObjetivos talleresobjetivos,
            IFrontContentTalleresTemasDetail tallerestemasdetail,
            IFrontContentTalleresTemasHead tallerestemashead)
        {
            _mapper = mapper;
            _logger = logger;
            _talleresheader = talleresheader;
            _talleresobjetivos = talleresobjetivos;
            _tallerestemasdetail = tallerestemasdetail;
            _tallerestemashead = tallerestemashead;




        }


        [HttpGet("GetFrontTalleres", Name = "GetFrontTalleres")]
        public ActionResult<ApiResponse<FrontTalleres>> GetFrontTalleres(int languajeId = 1)
        {
            FrontTalleres modelResponse = new FrontTalleres();

            var response = new ApiResponse<FrontTalleres>();

            try
            {
                var Resulttallereshead = _mapper.Map<FrontContentTalleresHeader>(_talleresheader.GetFrontTalleresHead(languajeId));

                var Resulttalleresobjetivos = _mapper.Map<List<FrontContentTalleresObjetivo>>(_talleresobjetivos.GetFrontTalleresObjetivos(languajeId));

                var Resulttallerestemasdetail = _mapper.Map<List<FrontContentTalleresTemasDetail>>(_tallerestemasdetail.GetFrontTalleresTemasDetail(languajeId));

                var Resulttallerestemashead = _mapper.Map<FrontContentTalleresTemasHead>(_tallerestemashead.GetFrontTalleresTemasHead(languajeId));

                modelResponse.tallereshead = Resulttallereshead;
                modelResponse.talleresobjetivos = Resulttalleresobjetivos;
                modelResponse.tallerestemasdetail = Resulttallerestemasdetail;
                modelResponse.tallerestemashead = Resulttallerestemashead;

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
