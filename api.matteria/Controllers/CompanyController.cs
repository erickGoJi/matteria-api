using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api.matteria.Models.createAccountCompany;
using api.matteria.Models.Response;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models.catalogsCompanytype;
using biz.matteria.Models.Company;
using biz.matteria.Repository.CatalogsCompanytype;
using biz.matteria.Repository.CompaniesCompany;
using biz.matteria.Repository.User;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IcatalogsCompanytype _companyType;
        private readonly ICompaniesCompany _company;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly IUserRepository _userRepository;

        public CompanyController(IMapper mapper,
            ILoggerManager logger,
            IcatalogsCompanytype companyType,
            ICompaniesCompany company,
            IWebHostEnvironment hostingEnv,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _companyType = companyType;
            _company = company;
            _hostingEnv = hostingEnv;
            _userRepository = userRepository;

        }



        [HttpGet("GetConfiguracionPublicarVacante", Name = "GetConfiguracionPublicarVacante")]
        public ActionResult<ApiResponse<ConfiguracionPublicaVacantesOrganizacion>> GetConfiguracionPublicarVacante(int languajeId = 1)
        {


            var response = new ApiResponse<ConfiguracionPublicaVacantesOrganizacion>();


            try
            {



                var result = _mapper.Map<ConfiguracionPublicaVacantesOrganizacion>(_company.GetConfiguracionPublicarVacante(languajeId));



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


        [HttpGet("GetConfiguracionOrganizacion", Name = "GetConfiguracionOrganizacion")]
        public ActionResult<ApiResponse<ConfiguracionStepByStepOrganizacion>> GetConfiguracionOrganizacion(int languajeId = 1)
        {


            var response = new ApiResponse<ConfiguracionOrganizacion>();


            try
            {



                var result = _mapper.Map<ConfiguracionOrganizacion>(_company.GetConfiguracionOrganizacion(languajeId));



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


        [HttpGet("GetConfiguracionStepByStepOrganizacion", Name = "GetConfiguracionStepByStepOrganizacion")]
        public ActionResult<ApiResponse<ConfiguracionStepByStepOrganizacion>> GetConfiguracionStepByStepOrganizacion(int languajeId = 1)
        {


            var response = new ApiResponse<ConfiguracionStepByStepOrganizacion>();


            try
            {



                var result = _mapper.Map<ConfiguracionStepByStepOrganizacion>(_company.GetConfiguracionStepByStepOrganizacion(languajeId));



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


        [HttpGet("GetConfiguracionPerfilOrganizacion", Name = "GetConfiguracionPerfilOrganizacion")]
        public ActionResult<ApiResponse<ConfiguracionPerfilOrganizacion>> GetConfiguracionPerfilOrganizacion(int languajeId = 1)
        {


            var response = new ApiResponse<ConfiguracionPerfilOrganizacion>();


            try
            {



                var result = _mapper.Map<ConfiguracionPerfilOrganizacion>(_company.GetConfiguracionPerfilOrganizacion(languajeId));



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





        [HttpGet("GetConfiguracionMisVacantes", Name = "GetConfiguracionMisVacantes")]
        public ActionResult<ApiResponse<ConfiguracionMisVacantesOrganizacion>> GetConfiguracionMisVacantes(int languajeId = 1)
        {


            var response = new ApiResponse<ConfiguracionMisVacantesOrganizacion>();


            try
            {



                var result = _mapper.Map<ConfiguracionMisVacantesOrganizacion>(_company.GetConfiguracionMisVacantes(languajeId));



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


        [HttpGet("GetConfiguracionIngresoOrganizacion", Name = "GetConfiguracionIngresoOrganizacion")]
        public ActionResult<ApiResponse<IngresoOrganizacionConfiguracion>> GetConfiguracionIngresoOrganizacion(int languajeId= 1)
        {


            var response = new ApiResponse<IngresoOrganizacionConfiguracion>();


            try
            {



                var result = _mapper.Map<IngresoOrganizacionConfiguracion>(_company.GetConfiguracionIngresoOrganizacion(languajeId));



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





        [HttpGet("GetConfiguracionCrearCuentaOrganizacion", Name = "GetConfiguracionCrearCuentaOrganizacion")]
        public ActionResult<ApiResponse<CrearCuentaOrganizacionConfiguracion>> GetConfiguracionCrearCuentaOrganizacion(int languajeId = 1)
        {
            

            var response = new ApiResponse<CrearCuentaOrganizacionConfiguracion>();


            try
            {



                var result = _mapper.Map<CrearCuentaOrganizacionConfiguracion>(_company.GetConfiguracionCrearCuentaOrganizacion(languajeId));



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


        [HttpPost("createAccountCompany", Name = "createAccountCompany")]
        public ActionResult<ApiResponse<List<createAccountCompany>>> createAccountCompany([FromBody] createAccountCompany request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            string pathFileFinal = string.Empty;

            var response = new ApiResponse<CompaniesCompany>();
            CompaniesCompany modelCompany = new CompaniesCompany();



            try
            {
                if (request != null)
                {
                    modelCompany = _company.Find(i => i.Id == request.id);

                    if (modelCompany != null)
                    {

                        if (!string.IsNullOrEmpty(request.logo))
                        {
                            //request.logo = request.logo.Replace("data:image/jpeg;base64,", "");

                            imageBytes = Convert.FromBase64String(request.logo);


                            if (imageBytes.Length > 0)
                            {

                                filePath =  Path.Combine(_hostingEnv.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

                                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    fileStream.Write(imageBytes, 0, imageBytes.Length);
                                }

                            }


                            Uri baseUri = new Uri(filePath);

                            pathFileFinal = baseUri.AbsoluteUri.Replace("file:///C:", "http:/");

                            pathFileFinal = pathFileFinal.Replace("inetpub/wwwroot", "34.237.214.147");

                            modelCompany.Logo = pathFileFinal;

                        }



                        modelCompany.Id = request.id;

                        modelCompany.CompanyTypeId = request.company_type_id;
                        modelCompany.CountryId = request.country_id;
                        modelCompany.City = request.city;
                        modelCompany.ContactPhoneNumber = request.contact_phone_number;
                        modelCompany.ContactCellphoneNumber = request.contact_cellphone_number;
                        modelCompany.Description = request.description;
                        modelCompany.SocialFacebook = request.social_facebook;
                        modelCompany.SocialInstagram = request.social_instagram;
                        modelCompany.SocialLinkedin = request.social_linkedin;
                        modelCompany.SocialTwitter = request.social_twitter;
                        modelCompany.OurAdn = request.ourADN;
                        modelCompany.OurImpactinfo = request.our_impactinfo;
                        modelCompany.HowDidYouFindOut = request.howDidYouFindOut;
                        modelCompany.Approve = false;
                        modelCompany.UserConsultorId = request.usuarioConsultorId;
                        

                        if(request.name != null)
                        {
                            modelCompany.Name = request.name;
                        }

                        



                        modelCompany = _company.Update(_mapper.Map<CompaniesCompany>(modelCompany), modelCompany.Id);


                        var user = _userRepository.Find(x => x.Id == modelCompany.UserId);

                        if(user != null)
                        {



                            user.FirstName = request.nameRepresentante;
                            user.Email = request.email;
                            user.LastName = request.apellido;

                            if(!string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.Email))
                            {
                                user = _userRepository.Update(_mapper.Map<AuthUser>(user), user.Id);

                            }



                        }

                        response.Result = modelCompany;
                        response.Success = true;



                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "La informaciòn de la organización no fue localizada";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "No hay información de la organización para procesar";

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


        [HttpGet("GetCompanyById", Name = "GetCompanyById")]
        public ActionResult<ApiResponse<createAccountCompany>> GetCompanyById(int companyId)
        {
            createAccountCompany model = new createAccountCompany();

            var response = new ApiResponse<createAccountCompany>();


            try
            {

                
                               
                var result = _mapper.Map<companyService>(_company.GetCompanyById(companyId));

                model.city = result.City;
                model.company_type_id = result.CompanyTypeId;
                model.contact_cellphone_number = result.ContactCellphoneNumber;
                model.contact_phone_number = result.ContactPhoneNumber;
                model.country_id = result.CountryId;
                model.description = result.Description;
                model.howDidYouFindOut = result.HowDidYouFindOut;
                model.id = result.Id;
                model.logo = result.Logo;
                model.ourADN = result.OurAdn;
                model.our_impactinfo = result.OurImpactinfo;
                model.social_facebook = result.SocialFacebook;
                model.social_instagram = result.SocialInstagram;
                model.social_linkedin = result.SocialLinkedin;
                model.social_twitter = result.SocialTwitter;
                model.name = result.Name;
                model.nameRepresentante = result.nameRepresentante;
                model.email = result.email;
                model.name = result.Name;
                model.apellido = result.apellidoRepresentante;


                response.Success = true;
                response.Result = model;

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });



            }

            return Ok(response);

        }





        [HttpGet("GetAllCompanyTypes", Name = "GetAllCompanyTypes")]
        public ActionResult<ApiResponse<List<catalogsCompanytypeService>>> GetAllCompanyTypes()
        {
            var response = new ApiResponse<List<catalogsCompanytypeService>>();

            try
            {

                var Result = _mapper.Map<List<catalogsCompanytypeService>>(_companyType.GetAllCompanyTypes());
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




    }
}
