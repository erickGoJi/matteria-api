using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontContentRecruiting
{
    public class FrontContentCruiting
    {
        //public List<biz.matteria.Entities.FrontContentRecruitingComo> comoEs { get; set; }

        public List<biz.matteria.Entities.FrontContentRecruitingComoEsHeader> comoEsHeader { get; set; }

        public biz.matteria.Entities.FrontContentRecruitingHeader recruitingHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentRecruitingPassive> recruitingPassive { get; set; }

        public biz.matteria.Entities.FrontContentRecruitingPassiveHeader recruitingPassiveHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentReruitingPorQueContratarno> comoContratarnos { get; set; }

    }
}
