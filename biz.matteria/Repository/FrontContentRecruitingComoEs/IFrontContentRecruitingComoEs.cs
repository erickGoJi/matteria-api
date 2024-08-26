using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentRecruitingComoEs
{
    public interface IFrontContentRecruitingComoEs: IGenericRepository<biz.matteria.Entities.FrontContentRecruitingComo>
    {

        List<biz.matteria.Entities.FrontContentRecruitingComo> GetRecruitingComoEs(int languageId);

    }
}
