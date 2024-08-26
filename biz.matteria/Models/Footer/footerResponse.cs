using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.Footer
{
    public class footerResponse
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public  ICollection<FooterDetail> FooterDetails { get; set; }

        public string url { get; set; }
    }
}
