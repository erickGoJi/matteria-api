using biz.matteria.Models.catalogsCompanytype;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsCompanytype
{
    public interface IcatalogsCompanytype: IGenericRepository<biz.matteria.Entities.CatalogsCompanytype>
    {
        List<catalogsCompanytypeService> GetAllCompanyTypes();
    }
}
