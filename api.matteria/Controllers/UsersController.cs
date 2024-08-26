using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.matteria.Models.loginRequest;
using api.matteria.Models.Response;
using api.matteria.Models.User;
using api.matteria.Models.userRequest;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Models;
using biz.matteria.Models.AuthUser;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CompaniesCompany;
using biz.matteria.Repository.CompraPaquetes;
using biz.matteria.Repository.Creditos;
using biz.matteria.Repository.loginUsers;
using biz.matteria.Repository.OpeningProfessions;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Repository.openingsOpeningcandidate;
using biz.matteria.Repository.PagosPayPal;
using biz.matteria.Repository.Roles;
using biz.matteria.Repository.User;
using biz.matteria.Repository.UsuariosRoles;
using biz.matteria.Repository.visitasVacantes;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.matteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        enum statusVacantes:int
        {
            pendientePago = 1,
            enRevision=2,
            noVisible=3,
            publicada=4,
            cerrada=5,
            cancelada=6


        }
        
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILoggerManager _logger;
        private readonly ICandidatesCandidate _candidate;
        private readonly ICompaniesCompany _company;
        private readonly IWebHostEnvironment _env;
        private readonly ICreditos _creditos;
        private readonly IUsuariosRoles _rolesuser;
        private readonly IRoles _roles;
        private readonly IUsuariosRoles _userRol;
        private readonly IloginUsers _loginusers;
        private readonly IopeningsOpening _openings;
        private readonly IopeningProfessions _profesion;
        private readonly IopeningsOpeningcandidate _ocandidate;
        private readonly IvisitasVacantes _visiatas;
        private readonly ICompraPaquetes _compras;
        private readonly IPagosPayPal _pagosopay;
        
        public UsersController(IMapper mapper, IUserRepository userRepository,
            ILoggerManager logger, ICandidatesCandidate candidate, ICompaniesCompany company,
            IWebHostEnvironment env,
            ICreditos creditos,
            IUsuariosRoles rolesuser,
            IRoles roles,
            IUsuariosRoles userRol,
            IloginUsers loginusers,
            IopeningsOpening opening,
            IopeningProfessions profesion,
            IopeningsOpeningcandidate ocandidate,
            IvisitasVacantes visitas,
            ICompraPaquetes compras,
            IPagosPayPal pagosPay)
        {
            
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _candidate = candidate;
            _company = company;
            _env = env;
            _creditos = creditos;
            _rolesuser = rolesuser;
            _roles = roles;
            _userRol = userRol;
            _loginusers = loginusers;
            _openings = opening;
            _profesion = profesion;
            _ocandidate = ocandidate;
            _visiatas = visitas;
            _compras = compras;
            _pagosopay = pagosPay;
        }


        [HttpPost("AddNewUserAdministrador", Name = "AddNewUserAdministrador")]
        public ActionResult<ApiResponse<userRolRequest>> AddNewUserAdministrador([FromBody] userRolRequest request)
        {
            var response = new ApiResponse<userRolRequest>();
            AuthUser model = new AuthUser();
            UsuariosRole modelRole = new UsuariosRole();

            try
            {
                model.DateJoined = DateTime.Now;
                model.Email = request.Email;
                model.FirstName = request.FirstName;
                model.Id = 0;
                model.IsActive = true;
                model.IsStaff = false;
                model.IsSuperuser = false;
                model.LastLogin = DateTime.Now;
                model.LastName = "";
                model.Password = request.Password;
                model.Username = request.Email;

                if (_userRepository.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } Already Exists";
                    return BadRequest(response);
                }

                AuthUser users = _userRepository.Add(_mapper.Map<AuthUser>(model));


                if(users != null)
                {
                    modelRole.UsuarioId = users.Id;
                    modelRole.RoleId = request.roleId;
                    UsuariosRole role = _userRol.Add(_mapper.Map<UsuariosRole>(modelRole));
                }


                response.Success = true;
                response.Result = request;


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


        [HttpPost("getCheckEmail", Name = "getCheckEmail")]
        public ActionResult<ApiResponse<bool>> getCheckEmail(string email)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Email == email));

                if (_user != null)
                {
                    response.Success = true;
                    response.Result = true;

                }
                else
                {
                    response.Success = false;
                    response.Result = false;
                    response.Message = "El email no existe";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }



        [HttpPost("AddNewUserCompanyFromAdmin", Name = "AddNewUserCompanyFromAdmin")]
        public ActionResult<ApiResponse<AuthUser>> AddNewUserCompanyFromAdmin([FromBody] userServiceCompany request)
        {
            int companyId=0;
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            AuthUser model = new AuthUser();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            var response = new ApiResponse<AuthUser>();
            CompaniesCompany modelCompany = new CompaniesCompany();
            int numberCreditsOeningFree = 3;
            Credito modelCreditos = new Credito();
            string pathFileFinal = string.Empty;

            try
            {

                model.DateJoined = DateTime.Now;
                model.Email = request.Email;
                model.FirstName = request.FirstName;
                model.Id = 0;
                model.IsActive = true;
                model.IsStaff = false;
                model.IsSuperuser = false;
                model.LastLogin = DateTime.Now;
                model.LastName = "";
                model.Password = request.Password;
                model.Username = request.Username;

                if (_userRepository.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } Already Exists";
                    return BadRequest(response);
                }

                AuthUser users = _userRepository.Add(_mapper.Map<AuthUser>(model));

                //agregamos como company

                if (!string.IsNullOrEmpty(request.logo))
                {
                    request.logo = request.logo.Replace("data:image/jpeg;base64,", "");

                    imageBytes = Convert.FromBase64String(request.logo);


                    if (imageBytes.Length > 0)
                    {

                        filePath = Path.Combine(_env.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

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





                modelCompany.ContactName = string.Empty;
                modelCompany.ContactPhoneNumber = string.Empty;
                modelCompany.ContactEmail = string.Empty;
                modelCompany.HeightField = 0;
                modelCompany.WidthField = 0;
                modelCompany.Timestamp = DateTime.Now;
                modelCompany.Updated = DateTime.Now;
                modelCompany.CreatedById = users.Id;
                modelCompany.UserId = users.Id;
                modelCompany.Status = true;
                modelCompany.StatusCompany = "cliente";
                modelCompany.TermsPolitics = true;
                modelCompany.MailOpeningsEnding = false;
                modelCompany.MailSiteImprovements = false;
                modelCompany.MailUpdatesNewsMatteria = false;
                modelCompany.Name = request.nameCompany;
                modelCompany.FromTcs = false;
                modelCompany.FromTcsMailSent = false;
                modelCompany.CompanyTypeId = request.csector;
                modelCompany.CountryId = request.cpais;
                modelCompany.City = request.cciudad;
                modelCompany.Approve = false;


                CompaniesCompany company = _company.Add(_mapper.Map<CompaniesCompany>(modelCompany));
                companyId = company.Id;


                for (int i = 1; i <= numberCreditsOeningFree; i++)
                {
                    modelCreditos.Id = 0;
                    modelCreditos.IdCompany = company.Id;
                    modelCreditos.IdEstatus = (int)statusVacantes.pendientePago;
                    modelCreditos.CreationDate = DateTime.Now;

                    var credito = _creditos.Add(_mapper.Map<Credito>(modelCreditos));

                }




                response.Success = true;
                response.Result = users;

                
                var url_beinvenidos_organizacion = "http://34.237.214.147/front/webmatteriaprincipal/admin/perfilorganizaciondos/" + +users.Id + "/" + companyId;

                modelEmail.To = model.Email;
                modelEmail.Subject = " ¡Qué alegría contar con ustedes!";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "";


                var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_organizaciones_ul.html");
                _serviceEmail.SendEmailMailing(html, modelEmail, users.FirstName, url_beinvenidos_organizacion);


                // _serviceEmail.SendEmail(modelEmail);




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




        [HttpPost("AddNewUserCompany", Name = "AddNewUserCompany")]
        public ActionResult<ApiResponse<AuthUser>> AddNewUserCompany([FromBody] userServiceCompany request)
        {
            byte[] imageBytes;
            string filePath = string.Empty;
            var nombreArchivo = Guid.NewGuid();
            AuthUser model = new AuthUser();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            var response = new ApiResponse<AuthUser>();
            CompaniesCompany modelCompany = new CompaniesCompany();
            int numberCreditsOeningFree = 3;
            Credito modelCreditos = new Credito();
            string pathFileFinal = string.Empty;

            try
            {

                model.DateJoined = DateTime.Now;
                model.Email = request.Email;
                model.FirstName = request.FirstName;
                model.Id = 0;
                model.IsActive = true;
                model.IsStaff = false;
                model.IsSuperuser = false;
                model.LastLogin = DateTime.Now;
                model.LastName = request.lastName == null ? "" : request.lastName;
                model.Password = request.Password;
                model.Username = request.Username;

                if (_userRepository.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } Already Exists";
                    return BadRequest(response);
                }

                AuthUser users = _userRepository.Add(_mapper.Map<AuthUser>(model));

                //agregamos como company

                if (!string.IsNullOrEmpty(request.logo))
                {
                    request.logo = request.logo.Replace("data:image/jpeg;base64,", "");

                    imageBytes = Convert.FromBase64String(request.logo);


                    if (imageBytes.Length > 0)
                    {

                        filePath = Path.Combine(_env.ContentRootPath, "perfiles", nombreArchivo.ToString() + ".png");

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





                modelCompany.ContactName = string.Empty;
                modelCompany.ContactPhoneNumber = string.Empty;
                modelCompany.ContactEmail = string.Empty;
                modelCompany.HeightField = 0;
                modelCompany.WidthField = 0;
                modelCompany.Timestamp = DateTime.Now;
                modelCompany.Updated = DateTime.Now;
                modelCompany.CreatedById = users.Id;
                modelCompany.UserId = users.Id;
                modelCompany.Status = true;
                modelCompany.StatusCompany = "cliente";
                modelCompany.TermsPolitics = true;
                modelCompany.MailOpeningsEnding = false;
                modelCompany.MailSiteImprovements = false;
                modelCompany.MailUpdatesNewsMatteria = false;
                modelCompany.Name = request.nameCompany;
                modelCompany.FromTcs = false;
                modelCompany.FromTcsMailSent = false;
                modelCompany.Approve = false;
                modelCompany.UserConsultorId = request.usuarioConsultorId;


                CompaniesCompany company = _company.Add(_mapper.Map<CompaniesCompany>(modelCompany));

               

                for(int i=1;i<=numberCreditsOeningFree; i++)
                {
                    modelCreditos.Id = 0;
                    modelCreditos.IdCompany = company.Id;
                    modelCreditos.IdEstatus = (int)statusVacantes.pendientePago;
                    modelCreditos.CreationDate = DateTime.Now;

                    var credito = _creditos.Add(_mapper.Map<Credito>(modelCreditos));

                }




                response.Success = true;
                response.Result = users;


                var url_beinvenidos_organizacion = "http://34.237.214.147/front/webmatteriaprincipal/bienvenidos/" + company.Id;
                
                modelEmail.To = model.Email;
                modelEmail.Subject = " ¡Qué alegría contar con ustedes!";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "";


                var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_organizaciones_ul.html");
                _serviceEmail.SendEmailMailing(html, modelEmail, users.FirstName, url_beinvenidos_organizacion);


                // _serviceEmail.SendEmail(modelEmail);




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



        [HttpGet("GetValueNotificationsUser", Name = "GetValueNotificationsUser")]
        public ActionResult<ApiResponse<bool>> GetValueNotificationsUser(int idUser)
        {
            var response = new ApiResponse<bool>();
            try
            {
                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == idUser));

                if(_user != null)
                {
                    response.Success = true;
                    response.Result = _user.IsNotifications == null?false: Convert.ToBoolean(_user.IsNotifications);

                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario no existe";
                }

            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return BadRequest(new { Success = false, Result = "Service Order Not Found", Message = ex.ToString() });

            }

            return Ok(response);
        }


        [HttpPost("SetNotifications", Name = "SetNotifications")]
        public ActionResult<ApiResponse<AuthUser>> SetNotifications(int idUser,bool active,int tipo)
        {
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            var response = new ApiResponse<AuthUser>();


            //1 configuracion postulantes
            //2 configuracion organizaciones


            try
            {
                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == idUser));

                if(_user != null)
                {

                    _user.IsNotifications = active;

                    AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(_user), _user.Id);


                    response.Success = true;
                    response.Result = users;




                    if(Convert.ToBoolean(_user.IsNotifications))
                    {

                        modelEmail.To = users.Email;
                        modelEmail.Subject = "Todas las novedades en tu mail 📩";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "";


                        if(tipo == 1)
                        {
                            var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_confirmacion_registro_boletin_postulantes.html");
                            _serviceEmail.SendEmailMailing(html, modelEmail, users.FirstName, "");


                        }
                        else if(tipo == 2)
                        {
                            var html = Path.Combine(_env.ContentRootPath, "Mailing", "aviso_confirmacion_registro_boletin_organizaciones.html");
                            _serviceEmail.SendEmailMailing(html, modelEmail, users.FirstName, "");

                        }


                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Usuario no existe";
                    
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





        [HttpPost("CancelAccountCompany", Name = "CancelAccountCompany")]
        public ActionResult<ApiResponse<bool>> CancelAccountCompany(int userId)
        {
            var response = new ApiResponse<bool>();

            try
            {

                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == userId));

                if(_user != null)
                {
                    var company = _company.Find(x => x.UserId == userId);

                    if(company != null)
                    {
                        var opening = _openings.FindAll(x => x.CompanyId == company.Id);


                        if(opening.Count > 0)
                        {

                            foreach(var item in opening)
                            {

                                var creditos = _creditos.FindAll(x => x.IdOpening == item.Id);

                                foreach(var itemcredito in creditos)
                                {
                                    _creditos.Delete(itemcredito);
                                }

                                var profesiones = _profesion.FindAll(x => x.OpeningId == item.Id);

                                foreach(var itemprofesion in profesiones)
                                {
                                    _profesion.Delete(itemprofesion);

                                }

                                var openingCandidate = _ocandidate.FindAll(x => x.OpeningId == item.Id);

                                foreach(var itemopcandidate in openingCandidate)
                                {
                                    _ocandidate.Delete(itemopcandidate);
                                }

                                var visiatasOpening = _visiatas.FindAll(x => x.VacanteId == item.Id);

                                foreach(var visitaope in visiatasOpening)
                                {
                                    _visiatas.Delete(visitaope);
                                }


                                _openings.Delete(item);

                            }

                            var creditosCompany = _creditos.FindAll(x => x.IdCompany == company.Id);

                            foreach(var itemcrecompany in creditosCompany)
                            {
                                _creditos.Delete(itemcrecompany);
                            }

                            _company.Delete(company);




                            var compras = _compras.FindAll(x => x.UserId == userId);

                            

                            
                            

                            foreach(var itemCompras in compras)
                            {
                                var pagosopenpay = _pagosopay.FindAll(x => x.CompraId == itemCompras.Id);

                                foreach(var itempago in pagosopenpay)
                                {
                                    _pagosopay.Delete(itempago);
                                }

                                _compras.Delete(itemCompras);
                            }

                            var loguin = _loginusers.FindAll(x => x.UsuarioId == userId);


                            foreach(var itemloguin in loguin)
                            {
                                _loginusers.Delete(itemloguin);
                            }

                            _userRepository.Delete(_user);

                            response.Success = true;
                            response.Result = true;
                            response.Message = "La cuenta se elimino";

                        }




                    }
                    else
                    {

                        response.Success = true;
                        response.Result = false;
                        response.Message = "La cuenta se elimino";

                    }

                    

                }
                else
                {
                    response.Result = false;
                    response.Message = "No se encontro al usuario";
                }
                


            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);

        }



        [HttpPost("CancelAccount", Name = "CancelAccount")]
        public ActionResult<ApiResponse<bool>> CancelAccount([FromBody] CancelAccountService request)
        {
            var response = new ApiResponse<bool>();

            try
            {

                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == request.idUser));

                if (_user != null)
                {
                    if (_userRepository.VerifyPassword(_user.Password, request.passwrod))
                    {
                        _user.Password = _userRepository.HashPassword(request.passwrod);
                        _user.IsActive = false;
                        _user.ReasonCancellation = request.reasoncancellation;

                        AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(_user), _user.Id);


                        response.Success = true;
                        response.Result = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Contraseña actual incorrecta";
                    }



                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario no existe.";
                    response.Result = false;
                }


            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = ex.ToString();
                _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
                return StatusCode(500, response);

            }

            return StatusCode(201, response);

        }


        //[HttpPost("CancelAccount", Name = "CancelAccount")]
        //public ActionResult<ApiResponse<bool>> CancelAccount([FromBody] CancelAccountService request)
        //{
        //    var response = new ApiResponse<bool>();

        //    try
        //    {

        //        var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == request.idUser));

        //        if(_user != null)
        //        {
        //            if (_userRepository.VerifyPassword(_user.Password, request.passwrod))
        //            {
        //                _user.Password = _userRepository.HashPassword(request.passwrod);
        //                _user.IsActive = false;
        //                _user.ReasonCancellation = request.reasoncancellation;

        //                AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(_user), _user.Id);


        //                response.Success = true;
        //                response.Result = true;
        //            }
        //            else
        //            {
        //                response.Success = false;
        //                response.Message = "Contraseña actual incorrecta";
        //            }



        //        }
        //        else
        //        {
        //            response.Success = false;
        //            response.Message = "El usuario no existe.";
        //            response.Result = false;
        //        }


        //    }
        //    catch(Exception ex)
        //    {
        //        response.Result = false;
        //        response.Success = false;
        //        response.Message = ex.ToString();
        //        _logger.LogError($"Something went wrong: { ex.Message.ToString() }");
        //        return StatusCode(500, response);

        //    }

        //    return StatusCode(201, response);

        //}



        [HttpPost("ChangedPassword", Name = "ChangedPassword")]
        public ActionResult<ApiResponse<AuthUser>> ChangedPassword([FromBody] changedPasswordService request)
        {

            var response = new ApiResponse<AuthUser>();

            try
            {

                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Id == request.idusaurio));

                if(_user != null)
                {

                    if (_userRepository.VerifyPassword(_user.Password, request.passwordNow))
                    {

                        
                        _user.Password = _userRepository.HashPassword(request.passwordNew);

                        AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(_user),_user.Id);


                        response.Success = true;
                        response.Result = users;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Contraseña actual incorrecta";
                    }


                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario no existe";
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


        [HttpPost("ReenviarEmailOrganizacion", Name = "ReenviarEmailOrganizacion")]
        public ActionResult<ApiResponse<AuthUser>> ReenviarEmailOrganizacion(int userId)
        {
            var response = new ApiResponse<AuthUser>();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();

            try
            {

                var user = _userRepository.Find(x => x.Id == userId);

                var company = _company.Find(i => i.UserId == user.Id);

                if (company != null)
                {

                    modelEmail.To = user.Email;
                    modelEmail.Subject = " ¡Qué alegría contar con ustedes!";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "";

                    var url_beinvenidos_organizacion = "http://34.237.214.147/front/webmatteriaprincipal/bienvenidos/" + company.Id;

                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_organizaciones.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, user.FirstName, url_beinvenidos_organizacion);

                    response.Success = true;
                    response.Result = user;

                }
                else
                {

                    response.Success = false;
                    response.Message = "El usuario de la organización no fue encontrado";

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

        [HttpPost("ReenviarEmailPostulante", Name = "ReenviarEmailPostulante")]
        public ActionResult<ApiResponse<AuthUser>> ReenviarEmailPostulante(int userId)
        {
            var response = new ApiResponse<AuthUser>();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            try
            {
                var user = _userRepository.Find(x => x.Id == userId);

                var postulante = _candidate.Find(i => i.UserId == user.Id);

                if (postulante != null)
                {
                    var url_beinvenidos_postulante = "http://34.237.214.147/front/webmatteriaprincipal/bienvenidoPostulante/" + postulante.Id + "/" + user.Id;
                    modelEmail.To = user.Email;
                    modelEmail.Subject = "¡Hola" + user.FirstName + "! 👉 Estás a un click de tu próximo trabajo de impacto";
                    modelEmail.IsBodyHtml = true;
                    modelEmail.Body = "";



                    var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_candidatos.html");
                    _serviceEmail.SendEmailMailing(html, modelEmail, user.FirstName, url_beinvenidos_postulante);


                    response.Success = true;
                    response.Result = user;
                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario postulante no fue encontrado";
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





        [HttpPost("AddNewUserFromAdmin", Name = "AddNewUserFromAdmin")]
        public ActionResult<ApiResponse<AuthUser>> AddNewUserFromAdmin([FromBody] userService request)
        {
            AuthUser model = new AuthUser();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            var response = new ApiResponse<AuthUser>();
            CandidatesCandidate modelPostulante = new CandidatesCandidate();


            try
            {

                model.DateJoined = DateTime.Now;
                model.Email = request.Email;
                model.FirstName = request.FirstName;
                model.Id = 0;
                model.IsActive = true;
                model.IsStaff = false;
                model.IsSuperuser = false;
                model.LastLogin = DateTime.Now;
                model.LastName = request.LastName;
                model.Password = request.Password;
                model.Username = request.Username;

                if (_userRepository.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } Already Exists";
                    return BadRequest(response);
                }

                AuthUser users = _userRepository.Add(_mapper.Map<AuthUser>(model));

                //lo agregamos como candidato
                modelPostulante.Timestamp = DateTime.Now;
                modelPostulante.Updated = DateTime.Now;
                modelPostulante.UserId = users.Id;
                modelPostulante.HeightField = 0;
                modelPostulante.WidthField = 0;
                modelPostulante.Status = true;
                modelPostulante.TermsPolitics = true;
                modelPostulante.MailJobOffers = false;
                modelPostulante.MailSiteImprovements = false;
                modelPostulante.MailUpdatesNewsMatteria = false;
                modelPostulante.FromTcs = false;
                modelPostulante.FromTcsMailSent = false;
                modelPostulante.CountryId = request.cpais;
                modelPostulante.City = request.cciudad;
                modelPostulante.Genre = request.cgenero;
                modelPostulante.Birthday = request.cfecha;
                

                CandidatesCandidate postulante = _candidate.Add(_mapper.Map<CandidatesCandidate>(modelPostulante));


                response.Success = true;
                response.Result = users;



                var url_beinvenidos_postulante = "http://34.237.214.147/front/webmatteriaprincipal/admin/perfilpostulantedos/" + users.Id + "/" + postulante.Id;
                //var url_beinvenidos_postulante = "http://34.237.214.147/front/webmatteriaprincipal/admin/postulanteperfil/" + postulante.Id + "/" + users.Id;
                modelEmail.To = model.Email;
                modelEmail.Subject = "¡Hola" + users.FirstName + "! 👉 Estás a un click de tu próximo trabajo de impacto";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "Gracias por registrarse en matteria:<br><b>usuario:</b>" + users.Username + "<br><b>contrase&ntilde;a:</b>" + request.Password + "<br>Activa tu cuenta:<br>" + $"<a href={url_beinvenidos_postulante}>Click aqui</a>";

                //_serviceEmail.SendEmail(modelEmail);

                //var html1 = System.Web.Hosting.HostingEnvironment.MapPath("~/Mailing/RecuperaPassword.html");
                var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_candidatos.html");
                _serviceEmail.SendEmailMailing(html, modelEmail, users.FirstName, url_beinvenidos_postulante);


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


        [HttpPost("AddNewUser", Name = "AddNewUser")]
        public ActionResult<ApiResponse<AuthUser>> AddNewUser([FromBody] userService request)
        {
            AuthUser model = new AuthUser();
            Email modelEmail = new Email();
            EmailService _serviceEmail = new EmailService();
            var response = new ApiResponse<AuthUser>();
            CandidatesCandidate modelPostulante = new CandidatesCandidate();


            try
            {

                model.DateJoined = DateTime.Now;
                model.Email = request.Email;
                model.FirstName = request.FirstName;
                model.Id = 0;
                model.IsActive = true;
                model.IsStaff = false;
                model.IsSuperuser = false;
                model.LastLogin = DateTime.Now;
                model.LastName = request.LastName;
                model.Password = request.Password;
                model.Username = request.Username;

                if (_userRepository.Exists(c => c.Email == request.Email))
                {
                    response.Success = false;
                    response.Message = $"Email: { request.Email } Already Exists";
                    return BadRequest(response);    
                }

                AuthUser users = _userRepository.Add(_mapper.Map<AuthUser>(model));

                //lo agregamos como candidato
                modelPostulante.Timestamp = DateTime.Now;
                modelPostulante.Updated = DateTime.Now;
                modelPostulante.UserId = users.Id;
                modelPostulante.HeightField = 0;
                modelPostulante.WidthField = 0;
                modelPostulante.Status = true;
                modelPostulante.TermsPolitics = true;
                modelPostulante.MailJobOffers = false;
                modelPostulante.MailSiteImprovements = false;
                modelPostulante.MailUpdatesNewsMatteria = false;
                modelPostulante.FromTcs = false;
                modelPostulante.FromTcsMailSent = false;
                modelPostulante.Genre = request.cgenero;
                modelPostulante.Birthday = request.fechaNacimiento;

                CandidatesCandidate postulante = _candidate.Add(_mapper.Map<CandidatesCandidate>(modelPostulante));
                                            

                response.Success = true;
                response.Result = users;

                var url_beinvenidos_postulante = "http://34.237.214.147/front/webmatteriaprincipal/bienvenidoPostulante/" + postulante.Id + "/" + users.Id;
                modelEmail.To = model.Email;
                modelEmail.Subject = "¡Hola " + users.FirstName + "! 👉 Estás a un click de tu próximo trabajo de impacto";
                modelEmail.IsBodyHtml = true;
                modelEmail.Body = "Gracias por registrarse en matteria:<br><b>usuario:</b>" + users.Username + "<br><b>contrase&ntilde;a:</b>" + request.Password + "<br>Activa tu cuenta:<br>" + $"<a href={url_beinvenidos_postulante}>Click aqui</a>";

                //_serviceEmail.SendEmail(modelEmail);

                //var html1 = System.Web.Hosting.HostingEnvironment.MapPath("~/Mailing/RecuperaPassword.html");
                var html = Path.Combine(_env.ContentRootPath, "Mailing", "bienvenida_candidatos_dos.html");
                _serviceEmail.SendEmailMailing(html,modelEmail,users.FirstName,url_beinvenidos_postulante);


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


        [HttpPost("RecoverPassword", Name = "RecoverPassword")]
        public ActionResult<ApiResponse<bool>> RecoverPassword(string email)
        {

            string PasswordAleatorio = string.Empty;
            EmailService _serviceEmail = new EmailService();
            Email modelEmail = new Email();

            var response = new ApiResponse<bool>();

            try
            {
                var _user = _mapper.Map<AuthUser>(_userRepository.Find(c => c.Email == email));

                if (_user != null)
                {
                    try
                    {

                        PasswordAleatorio = _userRepository.GenerateRandom();
                    }
                    catch (Exception ex)
                    {
                        PasswordAleatorio = _userRepository.GenerateRandom();
                    }

                    _user.Password = _userRepository.HashPassword(PasswordAleatorio);

                    AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(_user), _user.Id);

                    if (users != null)
                    {
                        modelEmail.To = email;
                        modelEmail.Subject = "Te pasamos una contraseña provisora 👉";
                        modelEmail.IsBodyHtml = true;
                        modelEmail.Body = "Generamos esta nueva contrase&ntilde;a para ti, la contraseña generada es :<br><b>" + PasswordAleatorio + "</b>";
                        //_serviceEmail.SendEmail(modelEmail);

                        
                        var candidate = _candidate.Find(x => x.UserId == users.Id);

                        if (candidate != null)
                        {
                            var html = Path.Combine(_env.ContentRootPath, "Mailing", "olvide_contrasena_candidatos.html");
                            _serviceEmail.SendEmailPassword(html, modelEmail, users.FirstName, PasswordAleatorio);
                        }

                        var company = _company.Find(x => x.UserId == users.Id);

                        if(company != null)
                        {
                            var html = Path.Combine(_env.ContentRootPath, "Mailing", "olvide_contrasena_organizaciones.html");
                            _serviceEmail.SendEmailPassword(html, modelEmail, users.FirstName, PasswordAleatorio);
                        }

                        response.Success = true;
                        response.Result = true;
                        response.Message = "El email fue enviado";
                    }
                }
                else
                {
                    response.Success = true;
                    response.Result = false;
                    response.Message = "El email no esta registrado";

                }

            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }



        [HttpPost("LoginPostulante", Name = "LoginPostulante")]
        public ActionResult<ApiResponse<AuthUserService>> LoginPostulante(Models.loginRequest.loginRequest request)
        {
            AuthUserService modelUser = new AuthUserService();
            var response = new ApiResponse<AuthUserService>();
            LoginUser modellogin = new LoginUser(); 

            try
            {

                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Username == request.UsuarioEmail && i.IsActive == true));

                if(_user != null)
                {

                    if (_userRepository.VerifyPassword(_user.Password, request.Password))
                    {

                        var claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.Name,_user.Id.ToString()),
                            new Claim(ClaimTypes.Role,"admon")
                            };
                        var claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120)
                        };
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal
                        //    (claimsIdentity), authProperties);

                        var candidate = _mapper.Map<CandidatesCandidate>(_candidate.Find(i => i.UserId == _user.Id));

                        if (candidate != null)
                        {
                            modelUser.candidateId = candidate.Id;

                            modellogin.Id = 0;
                            modellogin.UsuarioId = _user.Id;
                            modellogin.LoginDate = DateTime.Now;
                            var loginusers = _loginusers.Add(_mapper.Map<LoginUser>(modellogin));
                        }
                        else
                        {

                            modelUser.candidateId = 0;
                            response.Message = "Este usuario no es postulante";

                        }

                        //var userrole = _rolesuser.Find(y => y.UsuarioId == _user.Id);

                        //if(userrole != null)
                        //{
                        //    var role = _roles.Find(z => z.Id == userrole.RoleId);

                        //    if (role != null)
                        //    {
                        //        modelUser.role = role.Name;
                        //    }
                        //}




                        modelUser.Id = _user.Id;
                        modelUser.LastName = _user.LastName;
                        modelUser.FirstName = _user.FirstName;
                        modelUser.Email = _user.Email;

                        

                        response.Success = true;
                        response.Result = modelUser;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Contraseña incorrecta";
                    }



                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario no existe";
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




        [HttpPost("LoginOrganizacion", Name = "LoginOrganizacion")]
        public ActionResult<ApiResponse<AuthUserService>> LoginOrganizacion(Models.loginRequest.loginRequest request)
        {
            LoginUser modellogin = new LoginUser();
            AuthUserService modelUser = new AuthUserService();
            var response = new ApiResponse<AuthUserService>();

            try
            {

                var _user = _mapper.Map<AuthUser>(_userRepository.Find(i => i.Username == request.UsuarioEmail && i.IsActive == true));

                if (_user != null)
                {

                    if (_userRepository.VerifyPassword(_user.Password, request.Password))
                    {

                        var claims = new List<Claim>
                            {
                            new Claim(ClaimTypes.Name,_user.Id.ToString()),
                            new Claim(ClaimTypes.Role,"admon")
                            };
                        var claimsIdentity = new ClaimsIdentity(claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120)
                        };
                        

                        var company = _mapper.Map<CompaniesCompany>(_company.Find(i => i.UserId == _user.Id));
                        
                        if(company != null)
                        {
                            modelUser.candidateId = company.Id;


                            modellogin.Id = 0;
                            modellogin.UsuarioId = _user.Id;
                            modellogin.LoginDate = DateTime.Now;
                            var loginusers = _loginusers.Add(_mapper.Map<LoginUser>(modellogin));
                        }
                        else
                        {
                            modelUser.candidateId = 0;
                            response.Message = "Este usuario no es una organización";
                        }

                        var userrole = _rolesuser.Find(y => y.UsuarioId == _user.Id);

                        if (userrole != null)
                        {
                            var role = _roles.Find(z => z.Id == userrole.RoleId);

                            if (role != null)
                            {
                                modelUser.role = role.Name;
                                modelUser.avatar = _user.Avatar;
                                
                            }
                        }



                        modelUser.Id = _user.Id;
                        modelUser.LastName = _user.LastName;
                        modelUser.FirstName = _user.LastName;
                        modelUser.Email = _user.Email;
                        


                        response.Success = true;
                        response.Result = modelUser;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Contraseña incorrecta";
                    }



                }
                else
                {
                    response.Success = false;
                    response.Message = "El usuario no existe";
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


        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public ActionResult<ApiResponse<AuthUser>> UpdateUser(AuthUser request)
        {
            var response = new ApiResponse<AuthUser>();


            try
            {
                var usuario = _userRepository.Find(j => j.Id == request.Id);

                if(usuario != null)
                {
                    usuario.Id = request.Id;
                    usuario.FirstName = request.FirstName;
                    usuario.LastName = request.LastName;
                    usuario.IsNotifications = request.IsNotifications;
                    usuario.IsActive = request.IsActive;


                    AuthUser users = _userRepository.Update(_mapper.Map<AuthUser>(usuario),usuario.Id);

                    response.Success = true;
                    response.Result = users;



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
    }
}
