using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.comprasadmin
{
    public class comprasAdmin
    {

        public int id { get; set; }

        public string title { get; set; }
        public int numberCredits { get; set; }
        public int consumidos { get; set; }
        public int disponibles { get; set; }

        public DateTime fechaCompra { get; set; }

        public string metodoPago { get; set; }

        public decimal monto { get; set; }

        public string nameCompany { get; set; }

        public string logo { get; set; }

        public int paquete { get; set; }

        public string email { get; set; }

        public string paisOrganizacion { get; set; }

        public string ciudadOrganizacion {get;set;}

    }
}
