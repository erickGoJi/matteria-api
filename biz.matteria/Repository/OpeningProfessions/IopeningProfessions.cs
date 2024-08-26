using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.OpeningProfessions
{
    public interface IopeningProfessions: IGenericRepository<biz.matteria.Entities.OpeningsOpeningProfession>
    {
        List<biz.matteria.Entities.OpeningsOpeningProfession> openingsOpeningProfessions(int openingId);
    }
}
