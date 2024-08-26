using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.OpeningCandidate
{
     public class candidateOpening
    {
        public int userId { get; set; }
        public int candidateid { get; set; }

        public int openingid { get; set; }

        public int SalaryMin { get; set; }

        public int SalaryMax { get; set; }

        public int currencyId { get; set; }
        public bool vacanteExterna { get; set; }

    }
}
