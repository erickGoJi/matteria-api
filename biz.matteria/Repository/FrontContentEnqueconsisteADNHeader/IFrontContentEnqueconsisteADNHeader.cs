using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentEnqueconsisteADNHeader
{
    public interface IFrontContentEnqueconsisteADNHeader: IGenericRepository<biz.matteria.Entities.FrontContentEnqueconsisteAdnHeader>
    {
        biz.matteria.Entities.FrontContentEnqueconsisteAdnHeader GetHeadEnqueConsisteADN(int languajeId);
    }
}
