using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.candidate
{
    public class enlistaCandidate
    {
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string email { get; set; }

        public string position { get; set; }

        public string cellphone_number { get; set; }

        public string genre { get; set; }

        public string city { get; set; }

        public int candidateId { get; set; }

        public string country { get; set; }

        public string profesion { get; set; }
        public int edad { get; set; }

        public string estatus { get; set; }

        public int postulacionOfertas { get; set; }

        public ICollection<OpeningsOpeningcandidate> postulaciones { get; set; }

        public ICollection<LoginUser> sesiones { get; set; }

        public string avatar { get; set; }

        public DateTime Timestamp { get; set; }

        public List<string> listaProfesiones { get; set; }

        public int countVisitas { get; set; }
    }
}
