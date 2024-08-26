using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.paises
{
    public class requestPais
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public int currencyId { get; set; }
        
        public decimal money { get; set; }

        public string codeCountry { get; set; }

        public bool activo { get; set; }

    }
}
