using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountPostulantService
{
    public class educationService
    {
        public int id { get; set; }
        public string institution { get; set; }
        public string grade { get; set; }

        //public List<gradeProfession> ListGradeProfession { get; set; }

        //public List<Profession> ListProfession { get; set; }

        public int professionId { get; set; }

        public string city { get; set; }

        public int country_id { get; set; }

        
        public int candidateId { get; set; }

        public DateTime studied_from { get; set; }
        public DateTime studied_to { get; set; }

        public string studied_from_month { get; set; }

        public string studied_to_month { get; set; }

        public string studied_from_year { get; set; }

        public string studied_to_year { get; set; }

        public bool actual_student { get; set; }

        public string nameProfession { get; set; }
    }
}
