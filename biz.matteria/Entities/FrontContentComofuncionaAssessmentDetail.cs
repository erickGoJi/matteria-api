﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    public partial class FrontContentComofuncionaAssessmentDetail
    {
        public int Id { get; set; }
        public int ComoAssessmentId { get; set; }
        public string Description { get; set; }

        public virtual FrontContentComofuncionaAssessment ComoAssessment { get; set; }
    }
}