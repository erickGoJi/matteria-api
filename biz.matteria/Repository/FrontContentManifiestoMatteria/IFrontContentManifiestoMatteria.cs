using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManifiestoMatteria
{
    public interface IFrontContentManifiestoMatteria : IGenericRepository<biz.matteria.Entities.FrontContentManifiestoMatterium>
    {
        biz.matteria.Entities.FrontContentManifiestoMatterium GetManifiestoMatteria(int languajeid);

    }
}
