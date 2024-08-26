using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.paquetes
{
    public class paquetes
    {

        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string TitlePt { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionPt { get; set; }
        public decimal RealPrice { get; set; }
        public decimal PackagePrice { get; set; }
        public bool? AplicaIva { get; set; }
        public int? CurrencyId { get; set; }
        public bool? Active { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int NumberCredits { get; set; }
        public decimal? Savemoney { get; set; }

        public decimal? precioPaqueteMonedaLocal { get; set; }

        public string lblAhorra { get; set; }
        public string lblPrecio { get; set; }
    }
}
