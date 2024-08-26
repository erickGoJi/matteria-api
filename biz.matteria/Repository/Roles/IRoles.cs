using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.Roles
{
    public interface IRoles: IGenericRepository<biz.matteria.Entities.Role>
    {

        List<biz.matteria.Entities.Role> getRoles();

    }
}
