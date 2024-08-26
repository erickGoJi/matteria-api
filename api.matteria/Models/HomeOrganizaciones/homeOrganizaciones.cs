using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.HomeOrganizaciones
{
    public class homeOrganizaciones
    {
        public List<FrontContentHeaderOrganizacione> headerorg { get; set; }

        public List<FrontContentHomeOrganizacionPorQueMatterium> frontHomeOrgPorqueMatteria { get; set; }

        //public List<FrontContentHomeOrgContenidoRecurso> frontContentOrgContenido { get; set; }

        public List<FrontContentManagerBlog> frontContentOrgContenido { get; set; }

        public List<FrontContentManagerNuestrosservicio> nuestrosServicios { get; set; }
    }
}
