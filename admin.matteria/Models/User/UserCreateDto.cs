using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace admin.matteria.Models.User
{
    public class UserCreateDto
    {
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime? LastLogin { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool IsSuperuser { get; set; }
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
        public bool IsStaff { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime DateJoined { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Trial139 { get; set; }
    }
}
