using biz.matteria.Models.CatalogsExparea;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsExparea
{
    public interface ICatalogsExparea: IGenericRepository<biz.matteria.Entities.CatalogsExparea>
    {
        List<CatalogsExpareaService> GetCatalogAreaExp();
    }
}
