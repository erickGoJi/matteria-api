using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace admin.matteria.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Ingrese su usuario")]
        public string UsuarioEmail { get; set; }

        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string Password { get; set; }
    }
}
