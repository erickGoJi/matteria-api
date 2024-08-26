using biz.matteria.Entities;
using biz.matteria.Repository.ContactsMAI;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ContactsMAI
{
    public class ContactsMAIRepository: GenericRepository<biz.matteria.Entities.ContactsMai>, IContactsMAI
    {
        public ContactsMAIRepository(DbmatteriaContext context) : base(context) { }

        public List<ContactsMai> GetAllContactsMAI()
        {
            var service = _context.contactMAI
                .Select(i => new ContactsMai
                {
                    ActivePdf = i.ActivePdf,
                    Email = i.Email,
                    Id = i.Id,
                    Name = i.Name,
                    RegistrationDate = i.RegistrationDate,
                    Respuesta = i.Respuesta


                }).ToList();

            return service;
        }
    }
}
