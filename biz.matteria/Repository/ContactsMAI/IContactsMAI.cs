using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ContactsMAI
{
    public interface IContactsMAI: IGenericRepository<biz.matteria.Entities.ContactsMai>
    {
        List<biz.matteria.Entities.ContactsMai> GetAllContactsMAI();
    }
}
