using biz.matteria.Models.CatalogsCountry;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsCountry
{
    public interface ICatalogsCountry : IGenericRepository<biz.matteria.Entities.CatalogsCountry>
    {
        List<CatalogsCountryService> GetCatalogCountry();

    }
}
