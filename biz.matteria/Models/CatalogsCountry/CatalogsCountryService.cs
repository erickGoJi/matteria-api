using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.CatalogsCountry
{
    public class CatalogsCountryService
    {
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Abreviation { get; set; }
        
        public string NamePt { get; set; }

        public string NameEn { get; set; }

        public string codeCountry { get; set; }

        public decimal? amountMoney { get; set; }
    }
}
