using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using biz.matteria.Entities;
using biz.matteria.Repository.User;
using dal.matteria.db_Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace admin.matteria.Controllers
{
    public class UserController : Controller
    {
        private readonly DbmatteriaContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserController(DbmatteriaContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("Login", Name = "Login")]
        public async Task<IActionResult> Login(Models.LoginRequest request)
        {
            var _user =  _mapper.Map<AuthUser>(_userRepository.Find(i => i.Username == request.UsuarioEmail));

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
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal
                          (claimsIdentity), authProperties);


                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Contraseña incorrecta");
                    return View("Index",request);
                }

            }
            else
            {
                ModelState.AddModelError("","El usuario no existe");
                return View("Index", request);
            }

        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "User");
        }



    }
}
