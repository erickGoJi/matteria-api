using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHeaderOrganizaciones
{
    public interface IFrontContentHeaderOrganizaciones: IGenericRepository<biz.matteria.Entities.FrontContentHeaderOrganizacione>
    {

        List<biz.matteria.Entities.FrontContentHeaderOrganizacione> GetFrontContentHeaderOrg(int languajeid);
    }
}
