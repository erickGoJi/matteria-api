using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.MenuPrincipal
{
    public class menuPrincipalResponse
    {
        public int idmenu { get; set; }

        public string nombre { get; set; }

        public int type { get; set; }

        public ICollection<MenuPrincipalDetalle> menudetalle { get; set; }

        public string url { get; set; }

    }
}
