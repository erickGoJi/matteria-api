using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.blogdetalle
{
    public class blogDetalleRequest
    {
        public int id { get; set; }

        public string titulo { get; set; }

        public string imagen { get; set; }

        public string descripcion { get; set; }

        public int type { get; set; }
    }
}
