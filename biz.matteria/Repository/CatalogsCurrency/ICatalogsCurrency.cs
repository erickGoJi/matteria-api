using biz.matteria.Models.CatalogsCurrency;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsCurrency
{
    public interface ICatalogsCurrency: IGenericRepository<biz.matteria.Entities.CatalogsCurrency>
    {

        List<CatalogsCurrencyService> GetCatalogCurrency();

    }
}
