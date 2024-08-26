using biz.matteria.Entities;
using biz.matteria.Models.AuthUser;
using biz.matteria.Repository.User;
using CryptoHelper;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace dal.matteria.Repository.User
{
    public class UserRepository : GenericRepository<biz.matteria.Entities.AuthUser>, IUserRepository
    {
        private IConfiguration _config;

        public UserRepository(DbmatteriaContext context, IConfiguration config) : base(context) { _config = config; }
        public string BuildToken(AuthUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
        public override biz.matteria.Entities.AuthUser Add(biz.matteria.Entities.AuthUser user)
        {
            user.Password = HashPassword(user.Password);
            return base.Add(user);
        }

        public override biz.matteria.Entities.AuthUser Update(biz.matteria.Entities.AuthUser user, object id)
        {
            
            return base.Update(user, id);
        }

        public System.String GenerateRandom()
        {
            System.Random randomGenerate = new System.Random();
            System.String sPassword = "";
            sPassword = System.Convert.ToString(randomGenerate.Next(00000001, 99999999));
            return sPassword.Substring(sPassword.Length - 8, 8);
        }

        public List<AuthUserService> GetUsersAdmon(string descripcion,int pais)
        {
            var service = _context.usuarioRol
                .Where(k => string.IsNullOrEmpty(descripcion) || (k.Usuario.FirstName + k.Usuario.Workstation + k.Usuario.Team + k.Usuario.Country.Name).Contains(descripcion))
                .Where(k => pais == 0 || k.Usuario.CountryId == pais)
                .Select(i => new AuthUserService
                {
                    Id = i.Usuario.Id,
                    Email = i.Usuario.Email,
                    FirstName = i.Usuario.FirstName,
                    LastName = i.Usuario.LastName,
                    avatar = i.Usuario.Avatar,
                    pais = i.Usuario.Country.Name,
                    cargo = i.Usuario.Workstation,
                    equipo = i.Usuario.Team,
                    ciudad = i.Usuario.City.Name





                }).ToList();

            return service;
        }


        public List<AuthUser> GetUsers()
        {
            var service = _context.AuthUsers
                .Select(i => new AuthUser
                {
                    Id = i.Id,
                    Email = i.Email,
                    FirstName = i.FirstName,
                    IsActive = i.IsActive,
                    IsNotifications = i.IsNotifications,
                    LastName = i.LastName,
                    ReasonCancellation = i.ReasonCancellation


                }).ToList();

            return service;
        }

        public AuthUser GetUserById(int id)
        {
            var service = _context.AuthUsers
                .Where(x => x.Id == id)
                .Select(i => new AuthUser
                {
                    Id = i.Id,
                    Email = i.Email,
                    FirstName = i.FirstName,
                    IsActive = i.IsActive,
                    IsNotifications = i.IsNotifications,
                    LastName = i.LastName,
                    ReasonCancellation = i.ReasonCancellation


                }).FirstOrDefault();

            return service;
        }
    }
}
