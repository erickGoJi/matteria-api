using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria
{
    public interface IFrontContentHomeOrganizacionPorQueMatteria: IGenericRepository<biz.matteria.Entities.FrontContentHomeOrganizacionPorQueMatterium>
    {

        List<biz.matteria.Entities.FrontContentHomeOrganizacionPorQueMatterium> GetFrontContentHoeOrgPorqueMatterria(int languajeid);
    }
}
