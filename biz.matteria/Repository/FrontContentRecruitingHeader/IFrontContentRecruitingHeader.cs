using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentRecruitingHeader
{
    public interface IFrontContentRecruitingHeader: IGenericRepository<biz.matteria.Entities.FrontContentRecruitingHeader>
    {
        biz.matteria.Entities.FrontContentRecruitingHeader GetRecruitingHeader(int languageId);

    }
}
