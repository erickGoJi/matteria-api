using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.HomePostulante
{
    public class HomePostulante
    {



        public biz.matteria.Entities.FrontContentHomeHeaderPostulante homeheaderpostulante { get; set; }

        public biz.matteria.Entities.FrontContentHomeImpactoPostulante homeimpactoPostulante { get; set; }

        public List<biz.matteria.Models.Openings.OpeningsService> homeOpeningservice { get; set; }

        //public List<FrontContentHomeOrgContenidoRecurso> frontContentOrgContenido { get; set; }

        public List<FrontContentManagerBlog> frontContentOrgContenido { get; set; }

    }
}
