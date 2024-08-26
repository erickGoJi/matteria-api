using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.createAccountPostulantService
{
    public class candidateService
    {
        public string positivechange { get; set; }
        public string hobbies { get; set; }
        public List<catalogInterestService> Interest { get; set; }

    }
}
