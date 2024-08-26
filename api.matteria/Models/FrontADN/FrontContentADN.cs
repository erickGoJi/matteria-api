using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontADN
{
    public class FrontContentADN
    {
        public biz.matteria.Entities.FrontContentAdnHeader contentADN { get; set; }

        public List<biz.matteria.Entities.FrontContentBeneficiosAdn> beneficiosADN { get; set; }

        public List<biz.matteria.Entities.FrontContentEnqueconsisteAdn> enqueconsisteADN { get; set; }

        public biz.matteria.Entities.FrontContentEnqueconsisteAdnHeader enqueconsisteADNHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentObjetivosAdn> objetivosADN { get; set; }

        public biz.matteria.Entities.FrontContentObjetivosAdnHeader objetivosADNHeader { get; set; }
    }
}
