using biz.matteria.Models.FrontContentManager_clientes;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManagerClientes
{
    public interface IFrontContentManagerClientes: IGenericRepository<biz.matteria.Entities.FrontContentManagerCliente>
    {
        List<FrontContentManagerClientesService> GetAllClientes(int type);

        biz.matteria.Entities.FrontContentManagerNuestrosclientesinfo getClientesHeader(int languageId);
    }
}
