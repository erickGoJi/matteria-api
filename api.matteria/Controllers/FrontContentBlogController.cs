using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Repository.FontContentContenidoRecursosBlog;
using biz.matteria.Repository.FrontContentManagerBlog;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrontContentBlogController : ControllerBase
    {

        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IFrontContentManagerBlog _blog;
        private readonly IFontContentContenidoRecursosBlog _FrontContenidoRecursoBlog;
        private readonly IWebHostEnvironment _hostingEnv;


        public FrontContentBlogController(AutoMapper.IMapper mapper,
            ILoggerManager logger,
            IFrontContentManagerBlog blog,
            IFontContentContenidoRecursosBlog FrontContenidoRecursoBlog,
            IWebHostEnvironment hostEnv)
        {
            _mapper = mapper;
            _logger = logger;
            _blog = blog;
            _FrontContenidoRecursoBlog = FrontContenidoRecursoBlog;
            _hostingEnv = hostEnv;

        }


        [HttpPost("UpdateblogHeaderContenido", Name = "UpdateblogHeaderContenido")]
        public ActionResult<ApiResponse<FontContentContenidoRecursosBlog>> UpdateblogHeaderContenido([FromBody] FontContentContenidoRecursosBlog request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;

            var response = new ApiResponse<FontContentContenidoRecursosBlog>();

            try
            {

                var blogFrontHeader = _FrontContenidoRecursoBlog.Find(x => x.Id == request.Id);

                if(blogFrontHeader != null)
                {


                    if (!string.IsNullOrEmpty(request.Image))
                    {
                        //request.avatarbase64 = request.avatarbase64.Replace("data:image/jpeg;base64,", "");

                        imageBytes = Convert.FromBase64String(request.Image);


                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "ContenidoRecursosBlog", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                        pathFileFinal  = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                        blogFrontHeader.Image = pathFileFinal;
                    }


                    blogFrontHeader.Id = request.Id;
                    blogFrontHeader.RegistrationDate = DateTime.Now;
                    blogFrontHeader.Title = request.Title;
                    blogFrontHeader.Description = request.Description;
                    blogFrontHeader.DescriptionEn = request.DescriptionEn;
                    blogFrontHeader.DescriptionPt = request.DescriptionPt;
                    blogFrontHeader.TitleEn = request.TitleEn;
                    blogFrontHeader.TitlePt = request.TitlePt;
                    blogFrontHeader.Active = request.Active;
                    blogFrontHeader.LblActualidad = request.LblActualidad;
                    blogFrontHeader.LblActualidadEn = request.LblActualidadEn;
                    blogFrontHeader.LeerMas = request.LeerMas;
                    blogFrontHeader.LeerMasEn = request.LeerMasEn;
                    blogFrontHeader.LeerMasPt = request.LeerMasPt;
                    blogFrontHeader.TextActualidad = request.TextActualidad;
                    blogFrontHeader.TextActualidadEn = request.TextActualidadEn;
                    blogFrontHeader.TextActualidadPt = request.TextActualidadPt;
                    blogFrontHeader.TitleBlog = request.TitleBlog;
                    blogFrontHeader.TitleBogEn = request.TitleBogEn;
                    blogFrontHeader.TitleBlogPt = request.TitleBlogPt;
                    blogFrontHeader.TitleCosejosOrg = request.TitleCosejosOrg;
                    blogFrontHeader.TitleConsejosOrgEn = request.TitleConsejosOrgEn;
                    blogFrontHeader.TitleConsejosOrgPt = request.TitleConsejosOrgPt;
                    blogFrontHeader.TitleContenido = request.TitleContenido;
                    blogFrontHeader.TitleContenidoEn = request.TitleContenidoEn;
                    blogFrontHeader.TitleContenidoPt = request.TitleContenidoPt;


                     var result = _FrontContenidoRecursoBlog.Update(_mapper.Map<FontContentContenidoRecursosBlog>(blogFrontHeader), blogFrontHeader.Id);


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



        [HttpPost("UpdateblogDetalle", Name = "UpdateblogDetalle")]
        public ActionResult<ApiResponse<FrontContentManagerBlog>> UpdateblogDetalle([FromBody] FrontContentManagerBlog request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;


            var response = new ApiResponse<FrontContentManagerBlog>();

            try
            {
                var blogFrontDetalle = _blog.Find(x => x.Id == request.Id);

                if(blogFrontDetalle != null)
                {


                    if (!string.IsNullOrEmpty(request.Imagen))
                    {
                        
                        imageBytes = Convert.FromBase64String(request.Imagen);


                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "blog", nombreArchivo.ToString() + ".png");

                            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                fileStream.Write(imageBytes, 0, imageBytes.Length);
                            }

                        }


                        Uri baseUri = new Uri(filePath);

                        pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                        pathFileFinal = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                        blogFrontDetalle.Imagen = pathFileFinal;
                    }


                    blogFrontDetalle.Id = request.Id;
                    blogFrontDetalle.Titulo = request.Titulo;
                    blogFrontDetalle.Descripcion = request.Descripcion;
                    blogFrontDetalle.Type = request.Type;
                    blogFrontDetalle.ModificationDate = DateTime.Now;
                    blogFrontDetalle.TituloEn = request.TituloEn;
                    blogFrontDetalle.TituloPt = request.TituloPt;
                    blogFrontDetalle.DescriptionEn = request.DescriptionEn;
                    blogFrontDetalle.DescriptionPt = request.DescriptionPt;
                    blogFrontDetalle.ContenidoRecurso = request.ContenidoRecurso;
                    blogFrontDetalle.ContenidoRecursoEn = request.ContenidoRecursoEn;
                    blogFrontDetalle.ContenidoRecursoPt = request.ContenidoRecursoPt;


                    var result = _blog.Update(_mapper.Map<FrontContentManagerBlog>(blogFrontDetalle), blogFrontDetalle.Id);

                    response.Success = true;
                    response.Result = result;

                }
                else
                {
                    response.Success = true;
                    response.Message = "no se encontro el elemento del blog";
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


        [HttpPost("AddDetalleBlog", Name = "AddDetalleBlog")]
        public ActionResult<ApiResponse<FrontContentManagerBlog>> AddDetalleBlog([FromBody] FrontContentManagerBlog request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;


            var response = new ApiResponse<FrontContentManagerBlog>();

            try
            {
                

                


                    if (!string.IsNullOrEmpty(request.Imagen))
                    {

                        imageBytes = Convert.FromBase64String(request.Imagen);


                        if (imageBytes.Length > 0)
                        {

                            filePath = Path.Combine(_hostingEnv.ContentRootPath, "blog", nombreArchivo.ToString() + ".png");

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


                    var result = _blog.Add(_mapper.Map<FrontContentManagerBlog>(request));

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




        [HttpPost("DeleteblogDetalle", Name = "DeleteblogDetalle")]
        public ActionResult<ApiResponse<bool>> DeleteblogDetalle([FromBody] FrontContentManagerBlog request)
        {
            var response = new ApiResponse<bool>();

            try
            {

                var blog = _blog.Find(x => x.Id == request.Id);

                if (blog != null)
                {

                    _blog.Delete(blog);

                    response.Result = true;
                }
                else
                {
                    response.Result = false;
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



            [HttpGet("GetFrontContentContenidoRecursosBlog", Name = "GetFrontContentContenidoRecursosBlog")]
        public ActionResult<ApiResponse<biz.matteria.Entities.FontContentContenidoRecursosBlog>> GetFrontContentContenidoRecursosBlog(int languageId=1)
        {

            var response = new ApiResponse<biz.matteria.Entities.FontContentContenidoRecursosBlog>();

            try
            {
                var Result = _mapper.Map<FontContentContenidoRecursosBlog>(_FrontContenidoRecursoBlog.getFontContenidoRecursosBlog(languageId));

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



        [HttpGet("GetFrontContentBlogById", Name = "GetFrontContentBlogById")]
        public ActionResult<ApiResponse<biz.matteria.Entities.FrontContentManagerBlog>> GetFrontContentBlogById(int languageId, int blogId)
        {
            var response = new ApiResponse<biz.matteria.Entities.FrontContentManagerBlog>();

            try
            {
                var Result = _mapper.Map<FrontContentManagerBlog>(_blog.GetFrontManagerBlogById(languageId, blogId));

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



        [HttpGet("GetFrontContentBlog", Name = "GetFrontContentBlog")]
        public ActionResult<ApiResponse<List<biz.matteria.Entities.FrontContentManagerBlog>>> GetFrontContentBlog(int languageId,int type)
        {

            var response = new ApiResponse<List<biz.matteria.Entities.FrontContentManagerBlog>>();

            try
            {
                var Result = _mapper.Map<List<FrontContentManagerBlog>>(_blog.GetFrontManagerBlog(languageId,type));

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
