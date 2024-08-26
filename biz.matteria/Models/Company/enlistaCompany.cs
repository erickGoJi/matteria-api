using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.Company
{
    public class enlistaCompany
    {

        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string contact_cellphone_number { get; set; }

        public int candidateId { get; set; }

        public string nameCountry { get; set; }

        public string representante { get; set; }

        public string pais { get; set; }

        public string sector { get; set; }

        public int openings { get; set; }

        public int paquetes { get; set; }

        public int prospectos { get; set; }

        public int sesiones { get; set; }

        
        public string logo { get; set; }

        public DateTime timestamp { get; set; }

        public biz.matteria.Entities.AuthUser asignaciones { get; set; }

        public string statusAsignadas { get; set; }

    }
}
