using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ContactsCompany
{
    public interface IContactsCompany: IGenericRepository<biz.matteria.Entities.ContactsCompany>
    {

        List<biz.matteria.Entities.ContactsCompany> GetAllContactsCompany();
    }
}
