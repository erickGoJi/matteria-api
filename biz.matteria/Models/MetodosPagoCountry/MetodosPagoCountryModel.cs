using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.MetodosPagoCountry
{
    public class MetodosPagoCountryModel
    {

        public int Id { get; set; }

        
        public int countryId { get; set; }

        
        public string country { get; set; }

        public string countryImage { get; set; }

        public List<biz.matteria.Entities.MetodosPago> listMetodosPago { get; set; }

    }
}
