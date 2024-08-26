using biz.matteria.Repository.MenuPrincipalDetalle;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.MenuPrincipalDetalle
{
    public class menuPrincipalDetalleRepository: GenericRepository<biz.matteria.Entities.MenuPrincipalDetalle>, IMenuPrincipalDetalle
    {
        public menuPrincipalDetalleRepository(DbmatteriaContext context) : base(context) { }


    }
}
