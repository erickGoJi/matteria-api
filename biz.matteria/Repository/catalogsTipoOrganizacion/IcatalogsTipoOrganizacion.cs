using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.catalogsTipoOrganizacion
{
    public interface IcatalogsTipoOrganizacion:IGenericRepository<biz.matteria.Entities.CatalogsTipoOrganizacion>
    {

        List<biz.matteria.Entities.CatalogsTipoOrganizacion> GetAllTipoOrganizacion(int languageId);
    }
}
