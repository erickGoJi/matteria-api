﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class CandidatesWorkandsocialexp
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime? WorkFrom { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime? WorkTo { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool ActualJob { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string PositiveImpact { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? CreatedById { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CandidateId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string WorkFromMonth { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string WorkFromYear { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string WorkToMonth { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string WorkToYear { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? UpdatedById { get; set; }
        public bool? Volunteering { get; set; }

        public virtual CandidatesCandidate Candidate { get; set; }
    }
}