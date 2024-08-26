using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountPostulantService
{
    public class volunteerexpService
    {
        public int id { get; set; }
        public string name { get; set; }

        public string volunteer_function { get; set; }

        public DateTime volunteer_from { get; set; }
        public DateTime volunteer_to { get; set; }

        public bool actual_volunteer { get; set; }
        public string desciption { get; set; }

        public string candidateId { get; set; }

        public string volunteer_from_month { get; set; }
        public string volunteer_to_month { get; set; }
        public string volunteer_from_year { get; set; }
        public string volunteer_to_year { get; set; }

        public List<cause> cause { get; set; }
    }
}
