using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHomeOrgContenidoRecurso
{
    public interface IFrontContentHomeOrgContenidoRecurso: IGenericRepository<biz.matteria.Entities.FrontContentHomeOrgContenidoRecurso>
    {

        List<biz.matteria.Entities.FrontContentHomeOrgContenidoRecurso> GetFrontContentHomeOrgContenidoRecurso(int languajeid);


    }
}
