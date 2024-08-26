using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentTalleresTemasHead
{
    public interface IFrontContentTalleresTemasHead: IGenericRepository<biz.matteria.Entities.FrontContentTalleresTemasHead>
    {
        biz.matteria.Entities.FrontContentTalleresTemasHead GetFrontTalleresTemasHead(int languajeId);

    }
}
