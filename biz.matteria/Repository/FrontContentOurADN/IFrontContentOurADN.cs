using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentOurADN
{
    public interface IFrontContentOurADN: IGenericRepository<biz.matteria.Entities.FrontContentOurAdn>
    {
        List<biz.matteria.Entities.FrontContentOurAdn> GetOurADN(int languageId);
    }
}
