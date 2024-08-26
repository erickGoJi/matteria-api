using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentTalleresTemasDetail
{
    public interface IFrontContentTalleresTemasDetail: IGenericRepository<biz.matteria.Entities.FrontContentTalleresTemasDetail>
    {
        List<biz.matteria.Entities.FrontContentTalleresTemasDetail> GetFrontTalleresTemasDetail(int languajeId);
    }
}
