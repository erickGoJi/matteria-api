using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.OpeningPostulationsCandidate
{
    public class OpeningsCandidatePostulations
    {
        public int Id { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int YearsExperience { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Avaliability { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? Salary { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime CloseOpening { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Activities { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Responsabilities { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string KeySkills { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string TeamProfile { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string Perks { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string RelevantDetails { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public List<biz.matteria.Entities.AuthUser> users { get; set; }

        public string applicationdate { get; set; }

        public string nameCompany { get; set; }

        public string statusPostulation { get; set; }
    }
}
