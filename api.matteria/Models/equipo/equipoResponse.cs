using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.equipo
{
    public class equipoResponse
    {
        public FrontContentManagerEquipoHeader equipoHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentManagerEquipo> listaEquipo { get; set; }

    }
}
