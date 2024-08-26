using api.matteria.Models.paises;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.CatalogsCountry;
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
    public class PaisesMonedaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly ICatalogsCountry _country;


        public PaisesMonedaController(IMapper mapper,
            ILoggerManager logger,
            ICatalogsCountry country)
        {
            _mapper = mapper;
            _logger = logger;
            _country = country;

        }

        [HttpPost("AddNewPais", Name = "AddNewPais")]
        public ActionResult<ApiResponse<CatalogsCountry>> AddNewPais(requestPais request)
        {
            CatalogsCountry modelRequest = new CatalogsCountry();


            var response = new ApiResponse<CatalogsCountry>();

            try
            {
                modelRequest.Abreviation = "";
                modelRequest.AmountMoney = request.money;
                modelRequest.CodeCountry = request.codeCountry;
                modelRequest.CreatedById = 1;
                modelRequest.CurrencyId = request.currencyId;
                modelRequest.Id = 0;
                modelRequest.Image = "";
                modelRequest.Name = request.nombre;
                modelRequest.NameEn = "";
                modelRequest.NamePt = "";
                modelRequest.Status = true;
                modelRequest.Timestamp = DateTime.Now;
                modelRequest.Updated = DateTime.Now;
                modelRequest.UpdatedById = 1;
                

                var Result = _country.Add(_mapper.Map<CatalogsCountry>(modelRequest));

                response.Success = true;
                response.Result = Result;

            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }


        [HttpPost("UpdatePais", Name = "UpdatePais")]
        public ActionResult<ApiResponse<CatalogsCountry>> UpdatePais(requestPais request)
        {
            


            var response = new ApiResponse<CatalogsCountry>();

            try
            {
                var modelRequest = _country.Find(x => x.Id == request.Id);

                if (modelRequest != null)
                {

                    modelRequest.AmountMoney = request.money;
                    modelRequest.CodeCountry = request.codeCountry;
                    modelRequest.CurrencyId = request.currencyId;
                    modelRequest.Id = request.Id;
                    modelRequest.Name = request.nombre;
                    modelRequest.Status = request.activo;
                    modelRequest.Updated = DateTime.Now;
                    modelRequest.UpdatedById = 1;


                    var Result = _country.Update(_mapper.Map<CatalogsCountry>(modelRequest), modelRequest.Id);

                    response.Success = true;
                    response.Result = Result;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No se encontro la información";

                }

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);


            }

            return StatusCode(201, response);

        }
    }
}
