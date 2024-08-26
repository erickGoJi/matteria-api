using biz.matteria.Models.Openings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.CreateOpening
{
    public class createOpening
    {
        //public opening opening { get; set; }

        public OpeningsService opening { get; set; }

        //public List<biz.matteria.Entities.OpeningsOpeningProfession> professions { get; set; }

        public int idCredito { get; set; }
        public int? Idpaquete { get; set; }
    }
}
