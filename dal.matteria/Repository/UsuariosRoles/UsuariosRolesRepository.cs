using biz.matteria.Repository.UsuariosRoles;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.UsuariosRoles
{
    public class UsuariosRolesRepository: GenericRepository<biz.matteria.Entities.UsuariosRole>, IUsuariosRoles
    {
        public UsuariosRolesRepository(DbmatteriaContext context) : base(context) { }
    }
}
