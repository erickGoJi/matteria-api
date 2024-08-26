using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManifiestoMatteriaRazonser
{
    public interface IFrontContentManifiestoMatteriaRazonser: IGenericRepository<biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser>
    {

        List<biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser> GetManifiestoMatteriaRazondeSer(int lenguajeId);
    }
}
