using biz.matteria.Models.CatalogsExparea;
using biz.matteria.Repository.CatalogsExparea;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsExparea
{
    public class CatalogsExpareaRepository : GenericRepository<biz.matteria.Entities.CatalogsExparea>, ICatalogsExparea
    {

        public CatalogsExpareaRepository(DbmatteriaContext context) : base(context) { }
        public List<CatalogsExpareaService> GetCatalogAreaExp()
        {
            var service = _context.CatalogsExpareas
                .Select(i => new CatalogsExpareaService
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
