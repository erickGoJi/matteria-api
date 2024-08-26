using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontContentTalleres
{
    public class FrontTalleres
    {
        public biz.matteria.Entities.FrontContentTalleresHeader tallereshead { get; set; }

        public List<biz.matteria.Entities.FrontContentTalleresObjetivo> talleresobjetivos { get; set; }

        public List<biz.matteria.Entities.FrontContentTalleresTemasDetail> tallerestemasdetail { get; set; }

        public biz.matteria.Entities.FrontContentTalleresTemasHead tallerestemashead { get; set; }
    }
}
