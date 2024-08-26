using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.CatalogsState
{
    public class CatalogStateService
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int? CountryId { get; set; }
        
        public string NameEn { get; set; }
        
        public string NamePt { get; set; }
    }
}
