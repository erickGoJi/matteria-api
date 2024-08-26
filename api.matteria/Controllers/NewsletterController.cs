using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.Response;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Repository.newsletterOrganization;
using biz.matteria.Repository.NewsletterPostulant;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly InewsletterOrganization _newsletterorg;
        private readonly INewsletterPostulant _newletterPostulant;
        private readonly IWebHostEnvironment _env;

        public NewsletterController(AutoMapper.IMapper mapper,
         ILoggerManager logger, InewsletterOrganization newsletterorg,
         INewsletterPostulant newletterPostulant,
         IWebHostEnvironment env)
        {
            _mapper = mapper;
            _logger = logger;
            _newsletterorg = newsletterorg;
            _newletterPostulant = newletterPostulant;
            _env = env;

        }

        [HttpGet("GetFrontNewsLetterPostulant", Name = "GetFrontNewsLetterPostulant")]
        public ActionResult<ApiResponse<NewsletterPostulantFrontConfiguration>> GetFrontNewsLetterPostulant(int language = 1)
        {


            var response = new ApiResponse<NewsletterPostulantFrontConfiguration>();

            try
            {
                var Result = _mapper.Map<NewsletterPostulantFrontConfiguration>(_newletterPostulant.GetNewsletterPostulantConfiguration(language));
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


        [HttpGet("GetFrontNewsLetterOrg", Name = "GetFrontNewsLetterOrg")]
        public ActionResult<ApiResponse<NewsletterOrganizationFrontConfiguration>> GetFrontNewsLetterOrg(int language=1)
        {


            var response = new ApiResponse<NewsletterOrganizationFrontConfiguration>();

            try
            {
                var Result = _mapper.Map<NewsletterOrganizationFrontConfiguration>(_newsletterorg.getFrontConfigurtionNewsLetterOrganizacion(language));
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


        [HttpPost("AddnewsletterPostulant", Name = "AddnewsletterPostulant")]
        public ActionResult<ApiResponse<NewsletterPostulant>> AddnewsletterPostulant([FromBody] NewsletterPostulant request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            var response = new ApiResponse<NewsletterPostulant>();

            try
            {

                if (_newletterPostulant.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } ya existe";
                    return BadRequest(response);
                }




                request.RegistrationDate = DateTime.Now;
                response.Result = _mapper.Map<NewsletterPostulant>(_newletterPostulant.Add(request));


                


                    modelEmail.To = request.Email;
                    modelEmail.Subject = "Todas las novedades en tu mail 📩";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "";


                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_confirmacion_registro_boletin_postulantes.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, request.Name, "");
            


                response.Success = true;
                response.Message = "Success";


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


        [HttpPost("AddnewsletterOrganization", Name = "AddnewsletterOrganization")]
        public ActionResult<ApiResponse<NewsletterOrganization>> AddnewsletterOrganization([FromBody] NewsletterOrganization request)
        {
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();
            var response = new ApiResponse<NewsletterOrganization>();

            try
            {
                if (_newsletterorg.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } ya existe";
                    return BadRequest(response);
                }



                request.RegistrationDate = DateTime.Now;
                response.Result = _mapper.Map<NewsletterOrganization>(_newsletterorg.Add(request));

                modelEmail.To = request.Email;
                modelEmail.Subject = "Todas las novedades en tu mail 📩";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "";


                var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_confirmacion_registro_boletin_organizaciones.html");
                _serviceEmail.SendEmailMailing(html, modelEmail, request.Name, "");



                response.Success = true;
                response.Message = "Success";

            }
            catch(Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201,response);

        }
    }
}
