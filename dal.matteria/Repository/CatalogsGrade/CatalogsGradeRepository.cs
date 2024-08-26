using biz.matteria.Models.CatalogsGrade;
using biz.matteria.Repository.CatalogGrade;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsGrade
{
    public class CatalogsGradeRepository : GenericRepository<biz.matteria.Entities.Catalogs_grade>, ICatalogsGrade
    {
        public CatalogsGradeRepository(DbmatteriaContext context) : base(context) { }
        public List<CatalogsGradeService> GatAllCatalogGradeService()
        {
            var service = _context.CatalogsGrade
                .Select(i => new CatalogsGradeService
                {
                    id = i.Id,
                    name = i.Name,
                    nameEn = i.NameEn,
                    namePt = i.NamePt

                }).ToList();

            return service;
        }
    }
}
