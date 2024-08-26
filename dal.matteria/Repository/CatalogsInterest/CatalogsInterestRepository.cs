using biz.matteria.Models.catalogsInterestService;
using biz.matteria.Repository.CatalogsInterest;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsInterest
{
    public class CatalogsInterestRepository: GenericRepository<biz.matteria.Entities.CatalogsInterest>, ICatalogsInterest
    {
        public CatalogsInterestRepository(DbmatteriaContext context) : base(context) { }

        public List<catalogsInterestService> getCatalogInterest()
        {
            var service = _context.CatalogsInterests
                .Select(i => new catalogsInterestService
                {
                    Id = i.Id,
                    Name = i.Name,
                    NameEn = i.NameEn,
                    NamePt = i.NamePt

                }).ToList();

            return service;
        }
    }
}
