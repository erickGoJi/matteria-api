using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentADN
{
    public interface IFrontContentADN: IGenericRepository<biz.matteria.Entities.FrontContentAdnHeader>
    {
        biz.matteria.Entities.FrontContentAdnHeader GetFrontADNHeader(int languajeId);

    }
}
