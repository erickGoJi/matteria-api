using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.candidateSelected
{
    public class candidateScore
    {
        public int candidateId { get; set; }

        public int openingId { get; set; }

        public int score { get; set; }
    }
}
