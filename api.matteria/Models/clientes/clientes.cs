using biz.matteria.Entities;
using biz.matteria.Models.FrontContentManager_clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.clientes
{
    public class clientes
    {

        public List<FrontContentManagerClientesService> listaClientes { get; set; }

        public FrontContentManagerNuestrosclientesinfo clientesheader { get; set; }

    }
}
