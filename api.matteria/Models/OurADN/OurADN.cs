using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.OurADN
{
    public class OurADN
    {
        public List<biz.matteria.Entities.FrontContentOurAdn> ourADN { get; set; }
        
        public biz.matteria.Entities.FrontContentOurAdnhead ourADNHead { get; set; }
    }
}
