using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ContactsContact
{
    public interface IContactsContact: IGenericRepository<biz.matteria.Entities.ContactsContact>
    {
        List<biz.matteria.Entities.ContactsContact> GetAllContactsContact();

    }
}
