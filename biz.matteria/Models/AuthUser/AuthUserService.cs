using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.AuthUser
{
    public class AuthUserService
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
        
        public int candidateId { get; set; }

        public string role { get; set; }

        public string avatar { get; set; }

        public string cargo { get; set; }

        public string equipo { get; set; }

        public string pais { get; set; }
        public string ciudad { get; set; }
    }
}
