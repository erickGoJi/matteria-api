﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;



namespace biz.matteria.Entities
{
    /// <summary>
    /// TRIAL
    /// </summary>
    public partial class OpeningsOpeningProfession
    {
        /// <summary>
        /// TRIAL
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int OpeningId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int ProfessionId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Trial280 { get; set; }

        public virtual OpeningsOpening Opening { get; set; }
    }
}