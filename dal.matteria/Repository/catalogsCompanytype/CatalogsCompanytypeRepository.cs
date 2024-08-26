using biz.matteria.Models.catalogsCompanytype;
using biz.matteria.Repository.CatalogsCompanytype;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.catalogsCompanytype
{
    public class CatalogsCompanytypeRepository : GenericRepository<biz.matteria.Entities.CatalogsCompanytype>, IcatalogsCompanytype
    {

        public CatalogsCompanytypeRepository(DbmatteriaContext context) : base(context) { }
        public List<catalogsCompanytypeService> GetAllCompanyTypes()
        {
            var service = _context.CatalogsCompanytypes
                .Select(i => new catalogsCompanytypeService
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
