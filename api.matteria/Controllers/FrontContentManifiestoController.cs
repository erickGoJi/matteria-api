using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontContentManifiestoMatteria;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentManagerFaq;
using biz.matteria.Repository.FrontContentManifiestoMatteria;
using biz.matteria.Repository.FrontContentManifiestoMatteriaRazonser;
using biz.matteria.Repository.FrontContentPoliticasPrivacidad;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentManifiestoController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentManifiestoMatteria _manifiestomatteria;
        private readonly IFrontContentManifiestoMatteriaRazonser _manifiestomatteriarazonser;
        private readonly IFrontContentManagerFaq _faqs;
        private readonly IFrontContentPoliticasPrivacidad _privacidad;


        public FrontContentManifiestoController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentManifiestoMatteria manifiestoMatteria,
            IFrontContentManifiestoMatteriaRazonser manifiestomatteriarazonser,
            IFrontContentManagerFaq faqs,
            IFrontContentPoliticasPrivacidad privacidad)
        {
            _mapper = mapper;
            _logger = logger;
            _manifiestomatteria = manifiestoMatteria;
            _manifiestomatteriarazonser = manifiestomatteriarazonser;
            _faqs = faqs;
            _privacidad = privacidad;


        }



        [HttpGet("GetPoliticasPrivacidad", Name = "GetPoliticasPrivacidad")]
        public ActionResult<ApiResponse<FrontContentPoliticasPrivacidad>> GetPoliticasPrivacidad(int languageId)
        {

            var response = new ApiResponse<FrontContentPoliticasPrivacidad>();

            try
            {
                var result = _mapper.Map<FrontContentPoliticasPrivacidad>(_privacidad.GetPoliticasPrivacidad(languageId));

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


        [HttpGet("GetFaqsandAnswer", Name = "GetFaqsandAnswer")]
        public ActionResult<ApiResponse<List<FrontContentManagerFaq>>> GetFaqsandAnswer(int languageId=1)
        {
            var response = new ApiResponse<List<FrontContentManagerFaq>>();

            try
            {
                var result = _mapper.Map<List<FrontContentManagerFaq>>(_faqs.GetFrontContentFaqsAndAnswers(languageId));

                response.Success = true;
                response.Result = result;

            }
            catch(Exception ex)
            {

                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });


            }

            return Ok(response);

        }



        [HttpGet("GetFrontContentManifiesto", Name = "GetFrontContentManifiesto")]
        public ActionResult<ApiResponse<FrontManifiesto>> GetFrontContentManifiesto(int lenguajeId=1)
        {
            FrontManifiesto modelResponse = new FrontManifiesto();

            var response = new ApiResponse<FrontManifiesto>();

            try
            {
                var Resulmanifiesto = _mapper.Map<FrontContentManifiestoMatterium>(_manifiestomatteria.GetManifiestoMatteria(lenguajeId));

                var Resulmanifiesto_razonser = _mapper.Map<List<FrontContentManifiestoMatteriaRazonser>>(_manifiestomatteriarazonser.GetManifiestoMatteriaRazondeSer(lenguajeId));

                modelResponse.frontmanifiestomatteria = Resulmanifiesto;
                modelResponse.frontmanifiestomatteriarazonser = Resulmanifiesto_razonser;

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
