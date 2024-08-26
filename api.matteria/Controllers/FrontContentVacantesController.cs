using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.FrontContentVacantes;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Models.paquetes;
using biz.matteria.Repository.FrontContentVacantesComoFunciona;
using biz.matteria.Repository.FrontContentVacantesComoFuncionaHeader;
using biz.matteria.Repository.FrontContentVacantesComoPublicar;
using biz.matteria.Repository.FrontContentVacantesHeader;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentVacantesController : ControllerBase
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        public readonly IFrontContentVacantesComoFunciona _comofunciona;
        public readonly IFrontContentVacantesComoFuncionaHeader _comofuncionaHeader;
        public readonly IFrontContentVacantesComoPublicar _comoPublicar;
        public readonly IFrontContentVacantesHeader _vacantesHeader;
        public readonly IFrontContentVacantesPaquetes _vacantesPaquetes;



        public FrontContentVacantesController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentVacantesComoFunciona comoFunciona,
            IFrontContentVacantesComoFuncionaHeader comoFuncionaHeader,
            IFrontContentVacantesComoPublicar comoPublicar,
            IFrontContentVacantesHeader vacantesHeader,
            IFrontContentVacantesPaquetes vacantesPaquetes)
        {

            _mapper = mapper;
            _logger = logger;
            _comofunciona = comoFunciona;
            _comofuncionaHeader = comoFuncionaHeader;
            _comoPublicar = comoPublicar;
            _vacantesHeader = vacantesHeader;
            _vacantesPaquetes = vacantesPaquetes;

        }



        [HttpGet("GetInformationPackages", Name = "GetInformationPackages")]
        public ActionResult<ApiResponse<paquetes>> GetFrontContentVacantes(string codeCountry,int languajeId=1)
        {
            var response = new ApiResponse<List<paquetes>>();

            try
            {
                var Result = _mapper.Map<List<paquetes>>(_vacantesPaquetes.GetPaquetes(codeCountry,languajeId));

                response.Success = true;
                response.Result = Result;


            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);

        }








            [HttpGet("GetFrontContentVacantes", Name = "GetFrontContentVacantes")]
        public ActionResult<ApiResponse<FrontContentVacantes>> GetFrontContentVacantes(int languajeId=1)
        {
            FrontContentVacantes modelResponse = new FrontContentVacantes();

            var response = new ApiResponse<FrontContentVacantes>();

            try
            {
                var comofunciona = _mapper.Map<List<FrontContentVacantesComoFunciona>>(_comofunciona.GetFrontVacantesComoFunciona(languajeId));

                var comofuncionaHeader = _mapper.Map<FrontContentVacantesComoFuncionaHeader>(_comofuncionaHeader.GetFrontVacantesComoFuncionaHeader(languajeId));

                var comoPublicar = _mapper.Map<List<FrontContentVacantesComoPublicar>>(_comoPublicar.GetFrontVacantesComoPublicar(languajeId));

                var vacantesHeader = _mapper.Map<FrontContentVacantesHeader>(_vacantesHeader.GetFrontVacantesHeader(languajeId));

                var vacantesPaquetes = _mapper.Map<List<FrontContentVacantesPaquete>>(_vacantesPaquetes.GetFrontVacantesPaquetes(languajeId));

                modelResponse.comofunciona = comofunciona;
                modelResponse.comofuncionaHeader = comofuncionaHeader;
                modelResponse.comoPublicar = comoPublicar;
                modelResponse.vacantesHeader = vacantesHeader;
                modelResponse.vacantesPaquetes = vacantesPaquetes;

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
