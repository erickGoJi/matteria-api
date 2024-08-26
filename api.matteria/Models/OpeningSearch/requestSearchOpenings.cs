using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.OpeningSearch
{
    public class requestSearchOpenings
    {
        public string fechaInicial { get; set; }
        public string fechaFinal { get; set; }
        public int companyId { get; set; }
        public string descripcion { get; set; }

        public int sector { get; set; }
        public int pais { get; set; }
        public string ciudad { get; set;}
        public int status { get; set; }
        public int companyTypeId { get; set; }
        public string jornada { get; set; }
        public int tipoContratoId { get; set; }

    }
}
