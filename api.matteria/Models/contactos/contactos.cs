using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.contactos
{
    public class contactos
    {

        public List<biz.matteria.Entities.ContactsCompany> contactsCompany { get; set; }

        public List<biz.matteria.Entities.ContactsContact> contactsContact { get; set; }


        public List<biz.matteria.Entities.ContactsGeneral> contactsGeneral { get; set; }

        public List<biz.matteria.Entities.ContactsMai> contactsMAI { get; set; }
    }
}
