using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountPostulantService
{
    public class workandsocialexpService
    {
        public int id { get; set; }
        public string name { get; set; }

        public string title { get; set; }

        public int candidateId { get; set; }

        public string city { get; set; }

        public int country_id { get; set; }

        
        public DateTime work_from { get; set; }

        public DateTime work_to { get; set; }

        public bool actual_job { get; set; }

        public string positive_impact { get; set; }

        public string work_from_month { get; set; }

        public string work_to_month { get; set; }

        public string work_from_year { get; set; }

        public string work_to_year { get; set; }

        public bool Volunteering { get; set; }

        public volunteerexpService volunteerexp { get; set; }

        public string description { get; set; }
    }
}
