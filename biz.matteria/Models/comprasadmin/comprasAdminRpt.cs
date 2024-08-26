using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.comprasadmin
{
    public class comprasAdminRpt
    {
        public int totalCompras { get; set; }
        public string paquetemascomprado { get; set; }
        public decimal ingresoUsd{get;set;}

        public int numCompradores { get; set; }

        public string creditosDisponibles { get; set; }

    }
}
