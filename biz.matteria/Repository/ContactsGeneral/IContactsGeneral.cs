using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ContactsGeneral
{
    public interface IContactsGeneral: IGenericRepository<biz.matteria.Entities.ContactsGeneral>
    {
        List<biz.matteria.Entities.ContactsGeneral> GetAllContacsGeneral();

        biz.matteria.Entities.ContactoGeneralConfiguracion GetContactoGeneralConfiguracion(int languageId);


    }
}
