using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.loginRequest
{
    public class userServiceCompany
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

        public string nameCompany { get; set; }

        public string logo { get; set; }

        public int csector { get; set; }

        public int cpais { get; set; }
        public string cciudad { get; set; }

        public int? usuarioConsultorId { get; set; }

        public string lastName { get; set; }
    }
}
