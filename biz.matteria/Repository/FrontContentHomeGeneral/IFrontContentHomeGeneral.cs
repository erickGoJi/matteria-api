using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHomeGeneral
{
    public interface IFrontContentHomeGeneral: IGenericRepository<biz.matteria.Entities.FrontContentHomeGeneral>
    {

        biz.matteria.Entities.FrontContentHomeGeneral GetHomeGeneral(int languajeid);

    }
}
