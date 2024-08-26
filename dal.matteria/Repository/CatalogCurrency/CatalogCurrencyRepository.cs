using biz.matteria.Entities;
using biz.matteria.Models.CatalogsCurrency;
using biz.matteria.Repository.CatalogsCurrency;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogCurrency
{
    public class CatalogCurrencyRepository : GenericRepository<biz.matteria.Entities.CatalogsCurrency>, ICatalogsCurrency
    {

        public CatalogCurrencyRepository(DbmatteriaContext context) : base(context) { }
        public List<CatalogsCurrencyService> GetCatalogCurrency()
        {
            var service = _context.CatalogsCurrencys
                .Select(i => new CatalogsCurrencyService
                {
                    Id = i.Id,
                    Abreviation = i.Abreviation,
                    Name = i.Name,
                    NameEn = i.NameEn,
                    NamePt = i.NamePt

                }).ToList();

            return service;
        }
    }
}
