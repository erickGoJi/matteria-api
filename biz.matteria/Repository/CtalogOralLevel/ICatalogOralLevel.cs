using biz.matteria.Models.CatalogsOralLevel;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CtalogOralLevel
{
    public interface ICatalogOralLevel: IGenericRepository<biz.matteria.Entities.CatalogOralLevel>
    {
        List<CatalogsOralLevelService> GetAllCatalogOralLevel(int languageId);
        
    }
}
