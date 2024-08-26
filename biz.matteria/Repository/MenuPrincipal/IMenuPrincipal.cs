using biz.matteria.Models.MenuPrincipal;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.MenuPrincipal
{
    public interface IMenuPrincipal: IGenericRepository<biz.matteria.Entities.MenuPrincipal>
    {
        List<menuPrincipalResponse> getMenuPrincipal(int languageId);


    }
}
