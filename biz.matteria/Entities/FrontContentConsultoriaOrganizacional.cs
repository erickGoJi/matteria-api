﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class FrontContentConsultoriaOrganizacional
    {
        public FrontContentConsultoriaOrganizacional()
        {
            FrontContentConsultoriaOrganizacionalDetalles = new HashSet<FrontContentConsultoriaOrganizacionalDetalle>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string TitlePt { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionPt { get; set; }
        public string Image { get; set; }
        public string LabelBtn { get; set; }
        public string LabelBtnEn { get; set; }
        public string LabelBtnPt { get; set; }
        public string BtnLink { get; set; }
        public DateTime? CreatinDate { get; set; }

        public virtual ICollection<FrontContentConsultoriaOrganizacionalDetalle> FrontContentConsultoriaOrganizacionalDetalles { get; set; }
    }
}