using biz.matteria.Entities;
using biz.matteria.Repository.Roles;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.Roles
{
    public class RolesRepository: GenericRepository<biz.matteria.Entities.Role>, IRoles
    {
        public RolesRepository(DbmatteriaContext context) : base(context) { }

        public List<Role> getRoles()
        {
            var service = _context.roles
                .Select(j => new Role
                {

                    CreationDate = j.CreationDate,
                    Id = j.Id,
                    Name = j.Name


                }).ToList();

            return service;
        }
    }
}
