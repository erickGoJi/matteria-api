using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.comprasadmin
{
    public class comprasCompany
    {
        public int paqueteId { get; set; }

        public string name { get; set; }

        public DateTime fechaCompra { get; set; }

        public string metodoPago { get; set; }

        public int creditos { get; set; }

        public int creditosUsados { get; set; }

        public int creditosDisponibles { get; set; }



    }
}
