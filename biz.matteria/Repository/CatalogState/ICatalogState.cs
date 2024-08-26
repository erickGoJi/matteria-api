using biz.matteria.Models.CatalogsState;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogState
{
    public interface ICatalogState: IGenericRepository<biz.matteria.Entities.CatalogsState>
    {
        List<CatalogStateService> GetCatalogState();

        List<CatalogStateService> GetCatalogStateByCountryId(int countryId);
    }
}
