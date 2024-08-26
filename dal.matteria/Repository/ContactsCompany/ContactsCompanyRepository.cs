using biz.matteria.Repository.ContactsCompany;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ContactsCompany
{
    public class ContactsCompanyRepository : GenericRepository<biz.matteria.Entities.ContactsCompany>, IContactsCompany
    {

        public ContactsCompanyRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.ContactsCompany> GetAllContactsCompany()
        {
            var service = _context.contactCompany
                .Select(x => new biz.matteria.Entities.ContactsCompany
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name,
                    NameCompany = x.NameCompany,
                    RegistrationDate = x.RegistrationDate,
                    Respuesta=x.Respuesta


                }).ToList();

            return service;
        }
    }
}
