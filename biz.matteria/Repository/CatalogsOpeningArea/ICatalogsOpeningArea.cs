using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsOpeningArea
{
    public interface ICatalogsOpeningArea: IGenericRepository<biz.matteria.Entities.CatalogsAreaOpening>
    {

        List<biz.matteria.Entities.CatalogsAreaOpening> GetOpeningAreas(int languageId);

    }
}
