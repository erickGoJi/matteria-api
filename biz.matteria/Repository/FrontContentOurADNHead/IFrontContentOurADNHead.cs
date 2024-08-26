using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentOurADNHead
{
    public interface IFrontContentOurADNHead: IGenericRepository<biz.matteria.Entities.FrontContentOurAdnhead>
    {
        biz.matteria.Entities.FrontContentOurAdnhead GetOurADNHead(int languageId);
    }
}
