using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontContentManifiestoMatteria
{
    public class FrontManifiesto
    {
        public biz.matteria.Entities.FrontContentManifiestoMatterium frontmanifiestomatteria { get; set; }

        public List<biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser> frontmanifiestomatteriarazonser { get; set; }


    }
}
