using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.CompraPaquete
{
    public class compraPaquetesRequest
    {
        public int idProducto { get; set; }

        public int idCompany { get; set; }

        public int metodoPagoId { get; set; }

        public int usuarioId { get; set; }


    }
}
