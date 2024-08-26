using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountCompany
{
    public class createAccountCompany
    {
        public int id { get; set; }

        public int? company_type_id { get; set; }


        public int? country_id { get; set; }

        public string city { get; set; }



        public string contact_phone_number { get; set; }

        public string contact_cellphone_number { get; set; }

        public string description { get; set; }


        public string social_facebook { get; set; }

        public string social_twitter { get; set; }

        public string social_linkedin { get; set; }

        public string social_instagram { get; set; }

        public string our_impactinfo { get; set; }

        public string ourADN { get; set; }

        public string howDidYouFindOut { get; set; }

        
        public string logo { get; set; }

        public string name { get; set; }

        public string nameRepresentante { get; set; }

        public string email { get; set; }

        public int? usuarioConsultorId { get; set; }

        public string apellido { get; set; }
        
    }
}
