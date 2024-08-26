using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentObjetivosADNHeader
{
    public interface IFrontContentObjetivosADNHeader: IGenericRepository<biz.matteria.Entities.FrontContentObjetivosAdnHeader>
    {
        biz.matteria.Entities.FrontContentObjetivosAdnHeader GetHeaderObjetivosADN();
    }
}
