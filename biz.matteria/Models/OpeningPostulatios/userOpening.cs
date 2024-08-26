using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.OpeningPostulatios
{
    public class userOpening
    {

        public int Id { get; set; }

        public string name { get; set; }

        public string name_second { get; set; }

        public string gender { get; set; }

        public string avatar { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public int? countryId { get; set; }

        public string city { get; set; }

        public DateTime? birthday { get; set; }

        public int candidateId { get; set; }

        public int? userId { get; set; }

        public bool? selected { get; set; }

        public int? score { get; set; }

    }
}
