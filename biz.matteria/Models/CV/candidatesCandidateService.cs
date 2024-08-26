using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.CV
{
    public class candidatesCandidateService
    {

        public int Id { get; set; }
        public string name { get; set; }

        public string lastname { get; set; }

        public string City { get; set; }

        public int? CountryId { get; set; }

        public string country { get; set; }

        public DateTime Birthday { get; set; }

        public string Genre { get; set; }

        public string email { get; set; }

        public string CellphoneNumber { get; set; }

        public string Positivechange { get; set; }

        public string Hobbies { get; set; }

        public int? salary_max { get; set; }

        public string position { get; set; }

        public string avatar { get; set; }

        public int? currencyId { get; set; }

        public string avatarbase64 { get; set; }

        public List<candidatesInterestsService> Interest { get; set; }

        

        public virtual ICollection<CandidatesWorkandsocialexp> listworkandsocialexp { get; set; }

        public virtual ICollection<CandidatesEducation> listEducation { get; set; }

        public virtual ICollection<CandidatesLanguage> listlanguage { get; set; }

        public virtual ICollection<CandidatesCandidateExpArea> listAreaExp { get; set; }

        public virtual ICollection<CandidatesCandidateExpSector> listExpSector { get; set; }

        public string currency { get; set; }
        

    }
}
