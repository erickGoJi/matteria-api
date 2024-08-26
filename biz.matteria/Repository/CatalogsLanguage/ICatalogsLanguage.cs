using biz.matteria.Models.CatalogsLanguaje;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsLanguage
{
    public interface ICatalogsLanguage: IGenericRepository<biz.matteria.Entities.CatalogsLanguage>
    {
        List<CatalogsLanguageService> GetAllCatalogLanguaje();
    }
}
