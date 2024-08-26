using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.comprasadmin
{
    public class comprasDetalleAdmin
    {
        public int id { get; set; }

        public string title { get; set; }
        public int numberCredits { get; set; }
        public int consumidos { get; set; }
        public int disponibles { get; set; }

        public DateTime fechaCompra { get; set; }

        public string metodoPago { get; set; }

        public string company { get; set; }

        public List<biz.matteria.Entities.OpeningsOpening> vacantes { get; set; }

    }
}
