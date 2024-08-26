using biz.matteria.Models.openingCubiertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.porqueMatteria
{
    public class porqueMatteria
    {
        public List<biz.matteria.Entities.FrontContentPorqueMatterium> porqueMatteri { get; set; }

        public List<openingCubiertas> vacantesCubiertas { get; set; }

    }
}
