using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.Openings
{
    public class openingCompanyCandidate
    {
        public int openingId { get; set; }
        public string nameOpening { get; set; }

        public DateTime dateOpening { get; set; }

        public string nameCompany { get; set; }

        public string logo { get; set; }


        public ICollection<Entities.AuthUser> candidatesOpening { get; set; }

        public DateTime? dateCloseOpening { get; set; }

        public DateTime datePublicaOpening { get; set; }


        public string pais { get; set; }

        public string ciudad { get; set; }

        public string estatus { get; set; }

        public string disponibilidad { get; set; }

        public string colorEstatus { get; set; }

        public int prospectos { get; set; }

    }
}
