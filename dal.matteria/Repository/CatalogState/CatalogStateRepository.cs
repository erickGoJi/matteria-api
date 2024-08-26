using biz.matteria.Models.CatalogsState;
using biz.matteria.Repository.CatalogState;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogState
{
    public class CatalogStateRepository: GenericRepository<biz.matteria.Entities.CatalogsState>, ICatalogState
    {
        public CatalogStateRepository(DbmatteriaContext context) : base(context) { }

        public List<CatalogStateService> GetCatalogState()
        {
            var service = _context.CatalogsStates
                .Select(i => new CatalogStateService
                {
                    Id = i.Id,
                    CountryId = i.CountryId,
                    Name = i.Name,
                    NameEn = i.NameEn,
                    NamePt = i.NamePt

                }).ToList();

            return service;
        }

        public List<CatalogStateService> GetCatalogStateByCountryId(int countryId)
        {
            var service = _context.CatalogsStates
                .Where(j => j.CountryId == countryId)
                .Select(i => new CatalogStateService
                {
                    Id = i.Id,
                    CountryId = i.CountryId,
                    Name = i.Name,
                    NameEn = i.NameEn,
                    NamePt = i.NamePt

                }).ToList();

            return service;
        }
    }
}
