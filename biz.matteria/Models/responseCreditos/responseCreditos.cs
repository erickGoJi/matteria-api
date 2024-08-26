using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.responseCreditos
{
    public class responseCreditos
    {

        
        public int paqueteId { get; set; }

        

        public int idstatus { get; set; }

        public int creditosDisponibles { get; set; }

        public List<Credito> creditosActivos { get; set; }
    }
}
