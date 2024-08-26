using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.loginRequest
{
    public class userService
    {
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        
        public string FirstName { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        
        public int cpais { get; set; }

        public string cciudad { get; set; }

        public string cgenero { get; set; }

        public DateTime cfecha { get; set; }

        public DateTime fechaNacimiento { get; set; }
    }
}
