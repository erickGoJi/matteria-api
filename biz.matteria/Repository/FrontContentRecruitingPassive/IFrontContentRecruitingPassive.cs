using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentRecruitingPassive
{
    public interface IFrontContentRecruitingPassive: IGenericRepository<biz.matteria.Entities.FrontContentRecruitingPassive>
    {
        List<biz.matteria.Entities.FrontContentRecruitingPassive> GetRecruitingPassive(int languajeId);

    }
}
