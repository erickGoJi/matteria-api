﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class FrontContentRecruitingPassiveHeader
    {
        public FrontContentRecruitingPassiveHeader()
        {
            FrontContentRecruitingPassives = new HashSet<FrontContentRecruitingPassive>();
        }

        public int Id { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string Title { get; set; }
        public string TitleEn { get; set; }
        public string TitlePt { get; set; }
        public string BtnContact { get; set; }
        public string BtnContactEn { get; set; }
        public string BtnContactPt { get; set; }

        public virtual ICollection<FrontContentRecruitingPassive> FrontContentRecruitingPassives { get; set; }
    }
}