using biz.matteria.Models.CatalogWrittenLevel;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogWrittenLevel
{
    public interface ICatalogWrittenLevel: IGenericRepository<biz.matteria.Entities.CatalogWrittenLevel>
    {

        List<CatalogWrittenLevelService> GetAllCatalogWrittenLevel(int languageId);


    }
}
