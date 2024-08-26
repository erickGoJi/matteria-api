using biz.matteria.Models.CatalogsCountry;
using biz.matteria.Repository.CatalogsCountry;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsCurrency
{
    public class CatalogsCountryRepository : GenericRepository<biz.matteria.Entities.CatalogsCountry>, ICatalogsCountry
    {

        public CatalogsCountryRepository(DbmatteriaContext context) : base(context) { }
        public List<CatalogsCountryService> GetCatalogCountry()
        {
            var service = _context.CatalogsCountrys
                .Select(i => new CatalogsCountryService
                {
                    Id = i.Id,
                    Abreviation = i.Abreviation,
                     Name = i.Name,
                     NamePt = i.NamePt,
                     NameEn = i.NameEn,
                     amountMoney = i.AmountMoney,
                     codeCountry = i.CodeCountry



                }).ToList();

            return service;
        }
    }
}
