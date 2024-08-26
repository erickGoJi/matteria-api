using biz.matteria.Models.CatalogsLanguaje;
using biz.matteria.Repository.CatalogsLanguage;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsLanguage
{
    public class CatalogsLanguageRepository: GenericRepository<biz.matteria.Entities.CatalogsLanguage>, ICatalogsLanguage
    {
        public CatalogsLanguageRepository(DbmatteriaContext context) : base(context) { }

        public List<CatalogsLanguageService> GetAllCatalogLanguaje()
        {
            var service = _context.CatalogsLanguages
                .Select(i => new CatalogsLanguageService
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
