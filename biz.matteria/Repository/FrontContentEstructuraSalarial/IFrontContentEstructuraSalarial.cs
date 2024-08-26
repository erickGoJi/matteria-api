using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentEstructuraSalarial
{
    public interface IFrontContentEstructuraSalarial: IGenericRepository<biz.matteria.Entities.FrontContentEstructuraSalarial>
    {

        biz.matteria.Entities.FrontContentEstructuraSalarial GetEstructuraSalarial(int languageId);

    }
}
