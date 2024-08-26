using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentRecruitingPassiveHeader
{
    public interface IFrontContentRecruitingPassiveHeader: IGenericRepository<biz.matteria.Entities.FrontContentRecruitingPassiveHeader>
    {

        biz.matteria.Entities.FrontContentRecruitingPassiveHeader GetRecruitingPassiveHeader(int languageId);
    }
}
