﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class FrontContentManagerComofuncionaHeaderOnboarding
    {
        public FrontContentManagerComofuncionaHeaderOnboarding()
        {
            FrontContentComofuncionaDetailOnboardings = new HashSet<FrontContentComofuncionaDetailOnboarding>();
        }

        public int Id { get; set; }
        public string Image { get; set; }
        public bool? Active { get; set; }
        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<FrontContentComofuncionaDetailOnboarding> FrontContentComofuncionaDetailOnboardings { get; set; }
    }
}