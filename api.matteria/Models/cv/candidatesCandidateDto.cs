using api.matteria.Models.createAccountPostulantService;
using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.cv
{
    public class candidatesCandidateDto
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string City { get; set; }

        public int? CountryId { get; set; }

        public string country { get; set; }

        public DateTime? Birthday { get; set; }

        public string Genre { get; set; }

        public string email { get; set; }

        public string CellphoneNumber { get; set; }

        public string Positivechange { get; set; }

        public string Hobbies { get; set; }

        public int salary_max { get; set; }

        public string position { get; set; }

        public List<catalogInterestService> Interest { get; set; }


        public List<CandidatesWorkandsocialexp> listworkandsocialexp { get; set; }

        public List<CandidatesEducation> listEducation { get; set; }

        public List<CandidatesLanguage> listlanguage { get; set; }




    }
}
