using biz.matteria.Models.consultoriaOrganizacional;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ConsultoriaOrganizacional
{
    public interface IConsultoriaOrganizacional:IGenericRepository<biz.matteria.Entities.FrontContentConsultoriaOrganizacional>
    {
        consultoriaOrganizacionalService GetConsultoriaOrganizacional(int lenguajeId);
    }
}
