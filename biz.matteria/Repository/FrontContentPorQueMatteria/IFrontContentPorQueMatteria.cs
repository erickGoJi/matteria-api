using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentPorQueMatteria
{
    public interface IFrontContentPorQueMatteria: IGenericRepository<biz.matteria.Entities.FrontContentPorqueMatterium>
    {
        List<biz.matteria.Entities.FrontContentPorqueMatterium> GetFrontContentPorqueMatteria(int languajeid);


    }
}
