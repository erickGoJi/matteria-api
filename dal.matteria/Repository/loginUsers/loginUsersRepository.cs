using biz.matteria.Repository.loginUsers;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.loginUsers
{
    public class loginUsersRepository: GenericRepository<biz.matteria.Entities.LoginUser>, IloginUsers
    {
        public loginUsersRepository(DbmatteriaContext context) : base(context) { }
    }
}
