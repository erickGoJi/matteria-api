﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class CandidatesCandidateAnswer2
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CandidateId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CompanytypeId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Trial182 { get; set; }

        public virtual CandidatesCandidate Candidate { get; set; }
    }
}