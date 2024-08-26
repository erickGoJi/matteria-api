using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.Openings
{
    public class openingServiceBackOffice
    {

        public int openingId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string nameOpening { get; set; }
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
        public DateTime? CloseOpening { get; set; }
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
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime Updated { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? CreatedById { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public DateTime OpenOpening { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? ConsultantId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string AlternateCompanyAlias { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public string AlternateCompanyDescription { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool KeepCompanyAlias { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int OpeningTypeId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int YearsExperienceOpening { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? CurrencyId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool PrivateSalary { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? HireType { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        public int? PhaseId { get; set; }
        /// <summary>
        /// TRIAL
        /// </summary>
        /// 
        public string whyJoin { get; set; }
        public string StatusOpening { get; set; }

        public string description_company { get; set; }

        public string social_facebook { get; set; }

        public string social_twitter { get; set; }

        public string social_linkedin { get; set; }

        public string social_instagram { get; set; }

        public string statusPostulation { get; set; }

        public string nameCompany { get; set; }

        public string applicationdate { get; set; }

        public string logo { get; set; }

        public string purposeOpening { get; set; }

        public int? areaid { get; set; }

        public bool? SalaryTodefine { get; set; }

        public int idCredito { get; set; }
        public int? Idpaquete { get; set; }

        public int? hunting { get; set; }

        public bool? featured { get; set; }
        public virtual ICollection<OpeningsOpeningProfession> OpeningsOpeningProfessions { get; set; }

        public string sector { get; set; }

        public string pais { get; set; }

        public List<FrontContentVacantesPaquete> paquetes { get; set; }

        public int postulantes { get; set; }

        public string email { get; set; }

        public string statusVacanteProceso { get; set; }

        public int statusVacanteId { get; set; }

        public int? statusProcesoVacanteId { get; set; }

        public int numeroVisualizaciones { get; set; }

        public int numeroPostulaciones { get; set; }

        public string nameSelected { get; set; }

        public biz.matteria.Entities.AuthUser  asignacion { get; set; }

        public string tipoContrato { get; set; }

        public string tipoOrganizacion { get; set; }

        public string estatusAsignacion { get; set; }
    }
}
