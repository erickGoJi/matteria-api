using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountPostulantService
{
    public class createAccountPostulantService
    {
        public bool receiveJobOffers { get; set; }
        
        public DateTime Birthday { get; set; }

       public candidateService whoYouAre { get; set; }


       public workandsocialexpService whatAreYouDoing { get; set; }
       
        
       public List<CandidatesWorkandsocialexp> listworkandsocialexp { get; set; }

       public educationService studies { get; set; }

       public List<CandidatesEducation> listEducation { get; set; }

       public languageService language { get; set; }

      public List<CandidatesLanguage> listlanguage { get; set; }

        public queBuscasService whatAreYouLooking { get; set; }


    }
}
