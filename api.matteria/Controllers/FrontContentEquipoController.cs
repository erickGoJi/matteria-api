using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.equipo;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentManagerEquipo;
using biz.matteria.Repository.FrontContentManagerEquipoHeader;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentEquipoController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentManagerEquipo _equipo;
        private readonly IFrontContentManagerEquipoHeader _equipoheader;
        private readonly IWebHostEnvironment _hostingEnv;

        public FrontContentEquipoController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentManagerEquipo equipo,
            IFrontContentManagerEquipoHeader equipoHeader,
            IWebHostEnvironment hostingEnv)
        {
            _mapper = mapper;
            _logger = logger;
            _equipo = equipo;
            _equipoheader = equipoHeader;
            _hostingEnv = hostingEnv;

        }

        [HttpPost("UpdateEquipoDetalle", Name = "UpdateEquipoDetalle")]
        public ActionResult<ApiResponse<FrontContentManagerEquipo>> UpdateEquipoDetalle([FromBody] FrontContentManagerEquipo request)
        {

            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;


            var response = new ApiResponse<FrontContentManagerEquipo>();

            try
            {
                var equipo = _equipo.Find(i => i.Id == request.Id);

                if(equipo != null)
                {

                    if (!string.IsNullOrEmpty(request.Imagen))
                    {
                        //request.avatarbase64 = request.avatarbase64.Replace("data:image/jpeg;base64,", "");

                        imageBytes = Convert.FromBase64String(request.Imagen);


                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "equipo", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                        pathFileFinal = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                        equipo.Imagen = pathFileFinal;
                    }



                    equipo.Id = request.Id;
                    equipo.Nombre = request.Nombre;
                    equipo.Puesto = request.Puesto;
                    equipo.ModificationDate = DateTime.Now;
                    

                    var result = _equipo.Update(_mapper.Map<FrontContentManagerEquipo>(equipo), equipo.Id);


                    response.Success = true;
                    response.Result = result;


                }
                else
                {
                    response.Success = true;
                    response.Message = "No se encontro el registro";
                }



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


        [HttpPost("DeleteEquipoDetalle", Name = "DeleteEquipoDetalle")]
        public ActionResult<ApiResponse<bool>> DeleteEquipoDetalle([FromBody] FrontContentManagerEquipo request)
        {

            var response = new ApiResponse<bool>();

            try
            {

                var equipo = _equipo.Find(y => y.Id == request.Id);


                if(equipo != null)
                {
                    _equipo.Delete(equipo);

                    response.Success = true;
                    response.Result = true;

                }
                else
                {
                    response.Message = "No se encontro el registro";
                }

            }
            catch(Exception ex)
            {

                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);

        }



        [HttpPost("AddEquipoDetalle", Name = "AddEquipoDetalle")]
        public ActionResult<ApiResponse<FrontContentManagerEquipo>> AddEquipoDetalle([FromBody] FrontContentManagerEquipo request)
        {

            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;


            var response = new ApiResponse<FrontContentManagerEquipo>();

            try
            {
                

                    if (!string.IsNullOrEmpty(request.Imagen))
                    {
                        //request.avatarbase64 = request.avatarbase64.Replace("data:image/jpeg;base64,", "");

                        imageBytes = Convert.FromBase64String(request.Imagen);


                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "equipo", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                        pathFileFinal = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                        request.Imagen = pathFileFinal;
                    }



                  
                    request.ModificationDate = DateTime.Now;
                request.CreationDate = DateTime.Now;
                request.Status = true;
                request.Descripcion = "";
                request.DescripcionEn = "";
                request.DescriptionPt = "";
                request.PuestoEn = "";
                request.PuestoPt = "";
                    


                    var result = _equipo.Add(_mapper.Map<FrontContentManagerEquipo>(request));


                    response.Success = true;
                    response.Result = result;


                


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









        [HttpPost("UpdateEquipo", Name = "UpdateEquipo")]
        public ActionResult<ApiResponse<FrontContentManagerEquipoHeader>> UpdateEquipo([FromBody] FrontContentManagerEquipoHeader request)
        {
            var response = new ApiResponse<FrontContentManagerEquipoHeader>();


            try
            {
                var equipoheader = _equipoheader.Find(i => i.Id == request.Id);

                if(equipoheader != null)
                {
                    equipoheader.Id = request.Id;
                    equipoheader.Phrase = request.Phrase;

                    var result = _equipoheader.Update(_mapper.Map<FrontContentManagerEquipoHeader>(equipoheader), equipoheader.Id);

                    response.Success = true;
                    response.Result = result;
                }
                else
                {
                    response.Success = true;
                    response.Message = "Información no encontrada";
                }

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








        [HttpGet("GetFrontContentEquipo", Name = "GetFrontContentEquipo")]
        public ActionResult<ApiResponse<equipoResponse>> GetFrontContentEquipo(int languageId=1)
        {
            equipoResponse modelResponse = new equipoResponse();
            var response = new ApiResponse<equipoResponse>();

            try
            {
                var ResultHeader = _mapper.Map<FrontContentManagerEquipoHeader>(_equipo.GetEquipoHeader(languageId));

                var ResultLista = _mapper.Map<List<FrontContentManagerEquipo>>(_equipo.GetFrontContentEquipo(languageId));


                modelResponse.equipoHeader = ResultHeader;
                modelResponse.listaEquipo = ResultLista;

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
