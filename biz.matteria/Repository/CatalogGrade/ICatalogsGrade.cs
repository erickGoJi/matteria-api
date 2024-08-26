using biz.matteria.Models.CatalogsGrade;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogGrade
{
    public interface ICatalogsGrade : IGenericRepository<biz.matteria.Entities.Catalogs_grade>
    {

        List<CatalogsGradeService> GatAllCatalogGradeService();

    }
}
