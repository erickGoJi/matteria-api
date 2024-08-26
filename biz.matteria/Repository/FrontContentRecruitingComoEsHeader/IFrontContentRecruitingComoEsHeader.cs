using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentRecruitingComoEsHeader
{
    public interface IFrontContentRecruitingComoEsHeader: IGenericRepository<biz.matteria.Entities.FrontContentRecruitingComoEsHeader>
    {
        List<biz.matteria.Entities.FrontContentRecruitingComoEsHeader> GetRecruitingComoEsHeader(int languageId);


    }
}
