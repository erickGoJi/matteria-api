using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.aliados;
using api.matteria.Models.HomeOrganizaciones;
using api.matteria.Models.HomePostulante;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentHeaderOrganizaciones;
using biz.matteria.Repository.FrontContentHomeGeneral;
using biz.matteria.Repository.FrontContentHomeHeaderPostulante;
using biz.matteria.Repository.FrontContentHomeImpactoPostulante;
using biz.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria;
using biz.matteria.Repository.FrontContentHomeOrgContenidoRecurso;
using biz.matteria.Repository.FrontContentManagerAliados;
using biz.matteria.Repository.FrontContentManagerBlog;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Repository.OurServices;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentHomeOrganizacionPorQueMatteria _homeorgporque;
        private readonly IFrontContentHeaderOrganizaciones _frontheaderorg;
        private readonly IFrontContentHomeOrgContenidoRecurso _fronthomecontenido;
        private readonly IOurServices _ourservices;
        private readonly IFrontContentHomeImpactoPostulante _homeImpactoPostulante;
        private readonly IFrontContentHomeHeaderPostulante _homeheaderpostulante;
        private readonly IopeningsOpening _openings;
        private readonly IFrontContentHomeGeneral _homeGeneral;
        private readonly IFrontContentManagerAliados _aliados;
        private readonly IFrontContentManagerBlog _blog;

        public HomesController(IMapper mapper,
            ILoggerManager logger,
            IFrontContentHomeOrganizacionPorQueMatteria homeorgporque,
            IFrontContentHeaderOrganizaciones frontheaderorg,
            IFrontContentHomeOrgContenidoRecurso fronthomecontenido,
            IOurServices ourServices,
            IFrontContentHomeImpactoPostulante homeImpactoPostulante,
            IFrontContentHomeHeaderPostulante homeheaderpostulante,
            IopeningsOpening opening,
            IFrontContentHomeGeneral homeGeneral,
            IFrontContentManagerAliados aliados,
            IFrontContentManagerBlog blog)
        {
            _mapper = mapper;
            _logger = logger;
            _homeorgporque = homeorgporque;
            _frontheaderorg = frontheaderorg;
            _fronthomecontenido = fronthomecontenido;
            _ourservices = ourServices;
            _homeImpactoPostulante = homeImpactoPostulante;
            _homeheaderpostulante = homeheaderpostulante;
            _openings = opening;
            _homeGeneral = homeGeneral;
            _aliados = aliados;
            _blog = blog;

        }



        [HttpGet("GetAliados", Name = "GetAliados")]
        public ActionResult<ApiResponse<aliadosResponse>> GetAliados(int languajeid)
        {
            aliadosResponse modelResponse = new aliadosResponse();

            var response = new ApiResponse<aliadosResponse>();

            try
            {

                var resultaliados = _mapper.Map<FrontContentManagerAliadosHeader>(_aliados.getAliadosHeader(languajeid));


                var resultaliadosList = _mapper.Map<List<FrontContentManagerAliado>>(_aliados.GetAliados(languajeid));

                modelResponse.aliadosHeader = resultaliados;
                modelResponse.listAliados = resultaliadosList;

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



        [HttpGet("GetHomeGeneral", Name = "GetHomeGeneral")]
        public ActionResult<ApiResponse<FrontContentHomeGeneral>> GetHomeGeneral(int lenguajeId = 1)
        {


            var response = new ApiResponse<FrontContentHomeGeneral>();

            try
            {

                var result = _mapper.Map<FrontContentHomeGeneral>(_homeGeneral.GetHomeGeneral(lenguajeId));

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



        [HttpGet("GetHomePostulantes", Name = "GetHomePostulantes")]
        public ActionResult<ApiResponse<HomePostulante>> GetHomePostulantes(int type, int languageId = 1)
        {
            HomePostulante modelResponse = new HomePostulante();
            var response = new ApiResponse<HomePostulante>();

            try
            {
                var homeheaderpostulante = _mapper.Map<FrontContentHomeHeaderPostulante>(_homeheaderpostulante.GetHeaderHomePostulante(languageId));

                var homeimpactoPostulante = _mapper.Map<FrontContentHomeImpactoPostulante>(_homeImpactoPostulante.GetHomeImpactoPostulante(languageId));

                var homeOpeningservice = _mapper.Map<List<biz.matteria.Models.Openings.OpeningsService>>(_openings.GetAllOpeningsDestacadas());
                
                //var frontContentOrgContenido = _mapper.Map<List<FrontContentHomeOrgContenidoRecurso>>(_fronthomecontenido.GetFrontContentHomeOrgContenidoRecurso());

                var frontContentOrgContenido = _mapper.Map<List<FrontContentManagerBlog>>(_blog.GetFrontManagerBlog(languageId, type));


                modelResponse.frontContentOrgContenido = frontContentOrgContenido;
                modelResponse.homeheaderpostulante = homeheaderpostulante;
                modelResponse.homeimpactoPostulante = homeimpactoPostulante;
                modelResponse.homeOpeningservice = homeOpeningservice;

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





        [HttpGet("GetHomeOrganizaciones", Name = "GetHomeOrganizaciones")]
        public ActionResult<ApiResponse<homeOrganizaciones>> GetHomeOrganizaciones(int type, int languageId = 1)
        {
            homeOrganizaciones modelResponse = new homeOrganizaciones();
            var response = new ApiResponse<homeOrganizaciones>();

            try
            {

                var headerorg = _mapper.Map<List<FrontContentHeaderOrganizacione>>(_frontheaderorg.GetFrontContentHeaderOrg(languageId));


                var frontHomeOrgPorqueMatteria = _mapper.Map<List<FrontContentHomeOrganizacionPorQueMatterium>>(_homeorgporque.GetFrontContentHoeOrgPorqueMatterria(languageId));


                //var frontContentOrgContenido = _mapper.Map<List<FrontContentHomeOrgContenidoRecurso>>(_fronthomecontenido.GetFrontContentHomeOrgContenidoRecurso());

                var frontContentOrgContenido = _mapper.Map<List<FrontContentManagerBlog>>(_blog.GetFrontManagerBlog(languageId, type));

                var ResultOurServices = _mapper.Map<List<FrontContentManagerNuestrosservicio>>(_ourservices.GetOurServices(languageId));

                modelResponse.headerorg = headerorg;
                modelResponse.frontHomeOrgPorqueMatteria = frontHomeOrgPorqueMatteria;
                modelResponse.frontContentOrgContenido = frontContentOrgContenido;
                modelResponse.nuestrosServicios = ResultOurServices;

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
