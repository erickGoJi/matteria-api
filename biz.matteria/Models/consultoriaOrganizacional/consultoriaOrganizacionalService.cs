using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.consultoriaOrganizacional
{
    public class consultoriaOrganizacionalService
    {
        public int Id { get; set; }
        public string Title { get; set; }
       
        public string Description { get; set; }
       
        public string Image { get; set; }
        public string LabelBtn { get; set; }
        
        public string BtnLink { get; set; }
        


        public ICollection<biz.matteria.Entities.FrontContentConsultoriaOrganizacionalDetalle> consultoriaDetalle { get; set; }
    }
}
