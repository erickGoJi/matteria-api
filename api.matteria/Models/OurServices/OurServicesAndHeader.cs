using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.OurServices
{
    public class OurServicesAndHeader
    {
        public FrontContentManagerNuestrosserviciosHeader ourServicesHeader { get; set; }
        public List<FrontContentManagerNuestrosservicio> ourServices { get; set; }


    }
}
