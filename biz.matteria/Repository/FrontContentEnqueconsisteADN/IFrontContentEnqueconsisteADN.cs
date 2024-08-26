using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentEnqueconsisteADN
{
    public interface IFrontContentEnqueconsisteADN: IGenericRepository<biz.matteria.Entities.FrontContentEnqueconsisteAdn>
    {
        List<biz.matteria.Entities.FrontContentEnqueconsisteAdn> getEnqueConsisteADN(int languajeId);
    }
}
