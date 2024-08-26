using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.User
{
    public class CancelAccountService
    {
        public int idUser { get; set; }
        public string reasoncancellation { get; set; }
        public string passwrod { get; set; }
    }
}
