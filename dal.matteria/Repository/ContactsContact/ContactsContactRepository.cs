using biz.matteria.Repository.ContactsContact;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ContactsContact
{
    public class ContactsContactRepository: GenericRepository<biz.matteria.Entities.ContactsContact>, IContactsContact
    {

        public ContactsContactRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.ContactsContact> GetAllContactsContact()
        {
            var service = _context.contactContact
                .Select(i => new biz.matteria.Entities.ContactsContact
                {

                    Comments = i.Comments,
                    Email = i.Email,
                    Id = i.Id,
                    Name = i.Name,
                    Phone = i.Phone,
                    RegistrationDate = i.RegistrationDate,
                    Respuesta = i.Respuesta


                }).ToList();

            return service;
        }
    }
}
