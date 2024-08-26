using biz.matteria.Models.CatalogProffesion;
using biz.matteria.Repository.CatalogsProffesion;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsProffesion
{
    public class CatalogsProffesionRepository: GenericRepository<biz.matteria.Entities.CatalogsProfession>, ICatalogsProffesion
    {
        public CatalogsProffesionRepository(DbmatteriaContext context) : base(context) { }

        public List<CatalogsProffesionService> GetAllCatalogProffesion()
        {
            var service = _context.CatalogsProfessions
                .Select(i => new CatalogsProffesionService
                {
                    Id = i.Id,
                    Name = i.Name,
                    NameEn = i.NameEn,
                    NamePt = i.NamePt
                }
                ).ToList();

            return service;
        }
    }
}
