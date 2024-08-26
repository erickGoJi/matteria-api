using biz.matteria.Models.catalogsInterestService;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsInterest
{
    public interface ICatalogsInterest: IGenericRepository<biz.matteria.Entities.CatalogsInterest>
    {
        List<catalogsInterestService> getCatalogInterest();
    }
}
