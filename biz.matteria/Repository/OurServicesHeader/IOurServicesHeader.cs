using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.OurServicesHeader
{
    public interface IOurServicesHeader: IGenericRepository<biz.matteria.Entities.FrontContentManagerNuestrosserviciosHeader>
    {
        biz.matteria.Entities.FrontContentManagerNuestrosserviciosHeader GetOurServicesHeader(int languajeId);


    }
}
