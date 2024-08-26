using biz.matteria.Models.CatalogProffesion;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsProffesion
{
    public interface ICatalogsProffesion: IGenericRepository<biz.matteria.Entities.CatalogsProfession>
    {
        List<CatalogsProffesionService> GetAllCatalogProffesion();


    }
}
