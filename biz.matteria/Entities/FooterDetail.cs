﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class FooterDetail
    {
        public int Id { get; set; }
        public int? FooterId { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionPt { get; set; }
        public string Url { get; set; }

        public virtual Footer Footer { get; set; }
    }
}