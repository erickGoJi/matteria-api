using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentObjetivosADN
{
    public interface IFrontContentObjetivosADN: IGenericRepository<biz.matteria.Entities.FrontContentObjetivosAdn>
    {
        List<biz.matteria.Entities.FrontContentObjetivosAdn> GetObjetivosADN();
    }
}
