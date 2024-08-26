using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentReruitingPorQueContratarnos
{
    public interface IFrontContentReruitingPorQueContratarnos: IGenericRepository<biz.matteria.Entities.FrontContentReruitingPorQueContratarno>
    {
        List<biz.matteria.Entities.FrontContentReruitingPorQueContratarno> GetRecruitingPorQueContratarnos(int languajeId);
    }
}
