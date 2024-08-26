using api.matteria.ActionFilter;
using biz.matteria.Entities;
using biz.matteria.Repository.CandidatesCandidate;
using biz.matteria.Repository.CandidatesCandidateExpArea;
using biz.matteria.Repository.CandidatesCandidateInterest;
using biz.matteria.Repository.CandidatesEducation;
using biz.matteria.Repository.CandidatesExpSector;
using biz.matteria.Repository.CandidatesLanguage;
using biz.matteria.Repository.CandidatesWorkandsocialexp;
using biz.matteria.Repository.CatalogGrade;
using biz.matteria.Repository.CatalogsCompanytype;
using biz.matteria.Repository.CatalogsCountry;
using biz.matteria.Repository.CatalogsCurrency;
using biz.matteria.Repository.CatalogsExparea;
using biz.matteria.Repository.CatalogsInterest;
using biz.matteria.Repository.CatalogsLanguage;
using biz.matteria.Repository.CatalogsOpeningArea;
using biz.matteria.Repository.CatalogsProffesion;
using biz.matteria.Repository.CatalogState;
using biz.matteria.Repository.catalogsTipoOrganizacion;
using biz.matteria.Repository.CatalogsTypeContract;
using biz.matteria.Repository.CatalogWrittenLevel;
using biz.matteria.Repository.CompaniesCompany;
using biz.matteria.Repository.CompraPaquetes;
using biz.matteria.Repository.ConsultoriaOrganizacional;
using biz.matteria.Repository.ContactsCompany;
using biz.matteria.Repository.ContactsContact;
using biz.matteria.Repository.ContactsGeneral;
using biz.matteria.Repository.ContactsMAI;
using biz.matteria.Repository.Creditos;
using biz.matteria.Repository.CtalogOralLevel;
using biz.matteria.Repository.EstatusVacantes;
using biz.matteria.Repository.EstatusVacantesProceso;
using biz.matteria.Repository.FontContentContenidoRecursosBlog;
using biz.matteria.Repository.Footer;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeaderDetail;
using biz.matteria.Repository.FrontContent_comofunciona_assessment_detail;
using biz.matteria.Repository.FrontContentADN;
using biz.matteria.Repository.FrontContentAssessment;
using biz.matteria.Repository.FrontContentBeneficiosADN;
using biz.matteria.Repository.FrontContentcomofunciona_assessment;
using biz.matteria.Repository.FrontContentEnqueconsisteADN;
using biz.matteria.Repository.FrontContentEnqueconsisteADNHeader;
using biz.matteria.Repository.FrontContentEstructuraSalarial;
using biz.matteria.Repository.FrontContentHeaderOrganizaciones;
using biz.matteria.Repository.FrontContentHomeGeneral;
using biz.matteria.Repository.FrontContentHomeHeaderPostulante;
using biz.matteria.Repository.FrontContentHomeImpactoPostulante;
using biz.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria;
using biz.matteria.Repository.FrontContentHomeOrgContenidoRecurso;
using biz.matteria.Repository.FrontContentManagerAliados;
using biz.matteria.Repository.FrontContentManagerBlog;
using biz.matteria.Repository.FrontContentManagerClientes;
using biz.matteria.Repository.FrontContentManagerEquipo;
using biz.matteria.Repository.FrontContentManagerEquipoHeader;
using biz.matteria.Repository.FrontContentManagerFaq;
using biz.matteria.Repository.FrontContentManifiestoMatteria;
using biz.matteria.Repository.FrontContentManifiestoMatteriaRazonser;
using biz.matteria.Repository.FrontContentObjetivosADN;
using biz.matteria.Repository.FrontContentObjetivosADNHeader;
using biz.matteria.Repository.FrontContentOurADN;
using biz.matteria.Repository.FrontContentOurADNHead;
using biz.matteria.Repository.FrontContentPoliticasPrivacidad;
using biz.matteria.Repository.FrontContentPorQueMatteria;
using biz.matteria.Repository.FrontContentRecruitingComoEs;
using biz.matteria.Repository.FrontContentRecruitingComoEsHeader;
using biz.matteria.Repository.FrontContentRecruitingHeader;
using biz.matteria.Repository.FrontContentRecruitingPassive;
using biz.matteria.Repository.FrontContentRecruitingPassiveHeader;
using biz.matteria.Repository.FrontContentReruitingPorQueContratarnos;
using biz.matteria.Repository.FrontContentTalleresHeader;
using biz.matteria.Repository.FrontContentTalleresObjetivos;
using biz.matteria.Repository.FrontContentTalleresTemasDetail;
using biz.matteria.Repository.FrontContentTalleresTemasHead;
using biz.matteria.Repository.FrontContentVacantesComoFunciona;
using biz.matteria.Repository.FrontContentVacantesComoFuncionaHeader;
using biz.matteria.Repository.FrontContentVacantesComoPublicar;
using biz.matteria.Repository.FrontContentVacantesHeader;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using biz.matteria.Repository.FrontHeaderOnboarding;
using biz.matteria.Repository.loginUsers;
using biz.matteria.Repository.MenuPrincipal;
using biz.matteria.Repository.MetodosPagoCountry;
using biz.matteria.Repository.newsletterOrganization;
using biz.matteria.Repository.NewsletterPostulant;
using biz.matteria.Repository.openingOpeningInterest;
using biz.matteria.Repository.OpeningProfessions;
using biz.matteria.Repository.openingsOpening;
using biz.matteria.Repository.openingsOpeningcandidate;
using biz.matteria.Repository.OurServices;
using biz.matteria.Repository.OurServicesHeader;
using biz.matteria.Repository.Pagos;
using biz.matteria.Repository.PagosPayPal;
using biz.matteria.Repository.PagosPayu;
using biz.matteria.Repository.ProgramaMAI;
using biz.matteria.Repository.ProgramaMAIModelo;
using biz.matteria.Repository.ProgramaMAIobjectives;
using biz.matteria.Repository.Roles;
using biz.matteria.Repository.stepBystepPostulante;
using biz.matteria.Repository.User;
using biz.matteria.Repository.UsuariosRoles;
using biz.matteria.Repository.visitasVacantes;
using biz.matteria.Services.Email;
using biz.matteria.Services.Logger;
using dal.matteria.Repository.CandidatesCandidate;
using dal.matteria.Repository.CandidatesCandidateExpArea;
using dal.matteria.Repository.CandidatesCandidateInterest;
using dal.matteria.Repository.CandidatesEducation;
using dal.matteria.Repository.CandidatesExpSector;
using dal.matteria.Repository.CandidatesLanguage;
using dal.matteria.Repository.CandidatesWorkandsocialexp;
using dal.matteria.Repository.CatalogCurrency;
using dal.matteria.Repository.CatalogOralLevel;
using dal.matteria.Repository.catalogsCompanytype;
using dal.matteria.Repository.CatalogsCurrency;
using dal.matteria.Repository.CatalogsExparea;
using dal.matteria.Repository.CatalogsGrade;
using dal.matteria.Repository.CatalogsInterest;
using dal.matteria.Repository.CatalogsLanguage;
using dal.matteria.Repository.CatalogsOpeningArea;
using dal.matteria.Repository.CatalogsProffesion;
using dal.matteria.Repository.CatalogState;
using dal.matteria.Repository.catalogsTipoOrganizacion;
using dal.matteria.Repository.CatalogsTypeContract;
using dal.matteria.Repository.CatalogWrittenLevel;
using dal.matteria.Repository.CompaniesCompany;
using dal.matteria.Repository.CompraPaquetes;
using dal.matteria.Repository.ConsultoriaOrganizacional;
using dal.matteria.Repository.ContactsCompany;
using dal.matteria.Repository.ContactsContact;
using dal.matteria.Repository.ContactsGeneral;
using dal.matteria.Repository.ContactsMAI;
using dal.matteria.Repository.Creditos;
using dal.matteria.Repository.EstatusVacantes;
using dal.matteria.Repository.EstatusVacantesProceso;
using dal.matteria.Repository.FontContentContenidoRecursosBlog;
using dal.matteria.Repository.Footer;
using dal.matteria.Repository.FrontComoFuncionaOnboardingDetail;
using dal.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using dal.matteria.Repository.FrontContentADN;
using dal.matteria.Repository.FrontContentAssessment;
using dal.matteria.Repository.FrontContentBeneficiosADN;
using dal.matteria.Repository.FrontContentComoFuncionaAssessment;
using dal.matteria.Repository.FrontContentComofuncionaAssessmentDetail;
using dal.matteria.Repository.FrontContentEnqueconsisteADN;
using dal.matteria.Repository.FrontContentEnqueconsisteADNHeader;
using dal.matteria.Repository.FrontContentEstructuraSalarial;
using dal.matteria.Repository.FrontContentHeaderOrganizaciones;
using dal.matteria.Repository.FrontContentHomeGeneral;
using dal.matteria.Repository.FrontContentHomeHeaderPostulante;
using dal.matteria.Repository.FrontContentHomeImpactoPostulante;
using dal.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria;
using dal.matteria.Repository.FrontContentHomeOrgContenidoRecurso;
using dal.matteria.Repository.FrontContentManagerAliados;
using dal.matteria.Repository.FrontContentManagerBlog;
using dal.matteria.Repository.FrontContentManagerClientes;
using dal.matteria.Repository.FrontContentManagerEquipo;
using dal.matteria.Repository.FrontContentManagerEquipoHeader;
using dal.matteria.Repository.FrontContentManagerFaq;
using dal.matteria.Repository.FrontContentManifiestoMatteria;
using dal.matteria.Repository.FrontContentManifiestoMatteriaRazonser;
using dal.matteria.Repository.FrontContentObjetivosADN;
using dal.matteria.Repository.FrontContentObjetivosADNHeader;
using dal.matteria.Repository.FrontContentOurADN;
using dal.matteria.Repository.FrontContentOurADNHead;
using dal.matteria.Repository.FrontContentPoliticasPrivacidad;
using dal.matteria.Repository.FrontContentPorQueMatteria;
using dal.matteria.Repository.FrontContentRecruitingComoEs;
using dal.matteria.Repository.FrontContentRecruitingComoEsHeader;
using dal.matteria.Repository.FrontContentRecruitingHeader;
using dal.matteria.Repository.FrontContentRecruitingPassive;
using dal.matteria.Repository.FrontContentRecruitingPassiveHeader;
using dal.matteria.Repository.FrontContentReruitingPorQueContratarnos;
using dal.matteria.Repository.FrontContentTalleresHeader;
using dal.matteria.Repository.FrontContentTalleresObjetivos;
using dal.matteria.Repository.FrontContentTalleresTemasDetail;
using dal.matteria.Repository.FrontContentTalleresTemasHead;
using dal.matteria.Repository.FrontContentVacantesComoFunciona;
using dal.matteria.Repository.FrontContentVacantesComoFuncionaHeader;
using dal.matteria.Repository.FrontContentVacantesComoPublicar;
using dal.matteria.Repository.FrontContentVacantesHeader;
using dal.matteria.Repository.FrontContentVacantesPaquetes;
using dal.matteria.Repository.FrontHeaderOnboarding;
using dal.matteria.Repository.loginUsers;
using dal.matteria.Repository.MenuPrincipal;
using dal.matteria.Repository.MetodosPagoCountry;
using dal.matteria.Repository.newsletterOrganization;
using dal.matteria.Repository.NewsletterPostulant;
using dal.matteria.Repository.openingOpeningInterest;
using dal.matteria.Repository.openingProfessions;
using dal.matteria.Repository.openingsOpening;
using dal.matteria.Repository.openingsOpeningCandidate;
using dal.matteria.Repository.OurServices;
using dal.matteria.Repository.OurServicesHeader;
using dal.matteria.Repository.Pagos;
using dal.matteria.Repository.PagosPayPal;
using dal.matteria.Repository.PagosPayu;
using dal.matteria.Repository.ProgramaMAI;
using dal.matteria.Repository.ProgramaMAIModelo;
using dal.matteria.Repository.ProgramaMAIobjectives;
using dal.matteria.Repository.Roles;
using dal.matteria.Repository.stepBystepPostulante;
using dal.matteria.Repository.User;
using dal.matteria.Repository.UsuariosRoles;
using dal.matteria.Repository.VisitasVacantes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    //.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<InewsletterOrganization, newsletterOrganizationRepository>();
            services.AddTransient<INewsletterPostulant, NewsletterPostulantRepository>();
            services.AddTransient<IFrontContentManagerClientes, FrontContentManagerClientesRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICandidatesCandidate, CandidatesCandidateRepository>();
            services.AddTransient<ICompaniesCompany, CompaniesCompanyRepository>();

            services.AddTransient<ICatalogsInterest, CatalogsInterestRepository>();
            services.AddTransient<ICatalogsCountry, CatalogsCountryRepository>();
                  
                        
            services.AddTransient<ICatalogState, CatalogStateRepository>();
            services.AddTransient<ICatalogsCurrency, CatalogCurrencyRepository>();

            services.AddTransient<ICatalogsExparea, CatalogsExpareaRepository>();

            services.AddTransient<ICandidatesCandidateInterest, CandidatesCandidateInterestRepository>();

            services.AddTransient<ICandidatesWorkandsocialexp, CandidatesWorkandsocialexpRepository>();

            services.AddTransient<ICandidatesEducation, CandidatesEducationRepository>();

            services.AddTransient<ICandidatesLanguage, CandidatesLanguageRepository>();

            services.AddTransient<ICandidatesCandidateExpArea, CandidatesCandidateExpAreaRepository>();

            services.AddTransient<ICatalogsLanguage, CatalogsLanguageRepository>();

            services.AddTransient<ICatalogOralLevel, CatalogOralLevelRepository>();

            services.AddTransient<ICatalogWrittenLevel, CatalogWrittenLevelRepository>();

            services.AddTransient<ICatalogsProffesion, CatalogsProffesionRepository>();


            services.AddTransient<ICatalogsGrade, CatalogsGradeRepository>();

            services.AddTransient<IcatalogsCompanytype, CatalogsCompanytypeRepository>();

            services.AddTransient<IopeningsOpening, openingsOpeningRepository>();

            services.AddTransient<IopeningsOpeningcandidate, openingsOpeningCandidateRepository>();

            services.AddTransient<ICandidatesExpSector, CandidatesExpSectorRepository>();

            
            services.AddTransient<IOurServices, OurServicesRepository>();

            services.AddTransient<IOurServicesHeader, OurServicesHeaderRepository>();

            services.AddTransient<IFrontOnboardingHeader, FrontHeaderOnboardingRepository>();

            services.AddTransient<IFrontComoFuncionaOnboardingHeaderDetail, FrontComoFuncionaOnboardingDetailRepository>();

            services.AddTransient<IFrontComoFuncionaOnboardingHeader, FrontComoFuncionaOnboardingHeaderRepository>();

            services.AddTransient<IFrontContentAssessment, FrontContentAssessmentRepository>();

            services.AddTransient<IFrontContentComofuncionaAssessment, FontContentComoFuncionaAssessmentRepository>();

            services.AddTransient<IFrontContentComofuncionaAssessmentDetail, FrontContentComofuncionaAssessmentDetailRepository>();

            services.AddTransient<IFrontContentBeneficiosADN, FrontContentBeneficiosADNRepository>();

            services.AddTransient<IFrontContentADN, FrontContentADNRepository>();

            services.AddTransient<IFrontContentEnqueconsisteADN, FrontContentEnqueconsisteADNRepository>();


            services.AddTransient<IFrontContentEnqueconsisteADNHeader, FrontContentEnqueconsisteADNHeaderRepository>();


            services.AddTransient<IFrontContentObjetivosADN, FrontContentObjetivosADNRepository>();

            services.AddTransient<IFrontContentObjetivosADNHeader, FrontContentObjetivosADNHeaderRepository>();


            services.AddTransient<IFrontContentManifiestoMatteria, FrontContentManifiestoMatteriaRepository>();

            services.AddTransient<IFrontContentManifiestoMatteriaRazonser, FrontContentManifiestoMatteriaRazonserRepository>();

            services.AddTransient<IFrontContentTalleresHeader, FrontContentTalleresHeaderRepository>();


            services.AddTransient<IFrontContentTalleresHeader, FrontContentTalleresHeaderRepository>();


            services.AddTransient<IFrontContentTalleresObjetivos, FrontContentTalleresObjetivosRepository>();



            services.AddTransient<IFrontContentTalleresTemasDetail, FrontContentTalleresTemasDetailRepository>();


            services.AddTransient<IFrontContentTalleresTemasHead, FrontContentTalleresTemasHeadRepository>();


            //vacantes
            services.AddTransient<IFrontContentVacantesComoFunciona, FrontContentVacantesComoFuncionaRepository>();

            services.AddTransient<IFrontContentVacantesComoFuncionaHeader, FrontContentVacantesComoFuncionaHeaderRepository>();

            services.AddTransient<IFrontContentVacantesComoPublicar, FrontContentVacantesComoPublicarRepository>();

            services.AddTransient<IFrontContentVacantesHeader, FrontContentVacantesHeaderRepository>();

            services.AddTransient<IFrontContentVacantesPaquetes, FrontContentVacantesPaquetesRepository>();


            //recruiting
            services.AddTransient<IFrontContentRecruitingComoEs, FrontContentRecruitingComoEsRepository>();

            services.AddTransient<IFrontContentRecruitingComoEsHeader, FrontContentRecruitingComoEsHeaderRepository>();

            services.AddTransient<IFrontContentRecruitingHeader, FrontContentRecruitingHeaderRepository>();
            services.AddTransient<IFrontContentRecruitingPassive, FrontContentRecruitingPassiveRepository>();

            services.AddTransient<IFrontContentRecruitingPassiveHeader, FrontContentRecruitingPassiveHeaderRepository>();



            services.AddTransient<IFrontContentReruitingPorQueContratarnos, FrontContentReruitingPorQueContratarnosRepository>();


            //ourADN
            services.AddTransient<IFrontContentOurADN, FrontContentOurADNRepository>();

            services.AddTransient<IFrontContentOurADNHead, FrontContentOurADNHeadRepository>();

            //equipo
            services.AddTransient<IFrontContentManagerEquipo, FrontContentManagerEquipoRepository>();

            //blog
            services.AddTransient<IFrontContentManagerBlog, FrontContentManagerBlogRepository>();

            services.AddTransient<ICatalogsTypeContract, CatalogsTypeContractRepository>();

            services.AddTransient<IopeningProfessions, openingProfessionsRepository>();

            services.AddTransient<ICatalogsOpeningArea, CatalogsOpeningAreaRepository>();

            services.AddTransient<IFontContentContenidoRecursosBlog, FontContentContenidoRecursosBlogRepository>();


            services.AddTransient<ICreditos, CreditosRepository>();

            services.AddTransient<ICompraPaquetes, CompraPaquetesRepository>();



            services.AddTransient<IContactsContact, ContactsContactRepository>();


            services.AddTransient<IContactsContact, ContactsContactRepository>();


            services.AddTransient<IContactsCompany, ContactsCompanyRepository>();


            services.AddTransient<IContactsGeneral, ContactsGeneralRepository>();


            services.AddTransient<IContactsMAI, ContactsMAIRepository>();

            services.AddTransient<IProgramaMAI, ProgramaMAIRepository>();



            services.AddTransient<IProgramaMAIobjectives, ProgramaMAIobjectivesRepository>();

            services.AddTransient<IProgramaMAIModelo, ProgramaMAIModeloRepository>();


            services.AddTransient<IMetodosPagoCountry, MetodosPagoCountryRepository>();


            services.AddTransient<IPagosPayPal, PagosPayPalRepository>();


            services.AddTransient<IPagos, PagosRepository>();

            services.AddTransient<IPagosPayu, PagosPeyuRepository>();

            services.AddTransient<IcatalogsTipoOrganizacion, catalogsTipoOrganizacionRepository>();



            services.AddTransient<IFrontContentManagerFaq, FrontContentManagerFaqRepository>();

            services.AddTransient<IFrontContentPoliticasPrivacidad, FrontContentPoliticasPrivacidadRepository>();



            
            services.AddTransient<IFrontContentHomeOrganizacionPorQueMatteria, FrontContentHomeOrganizacionPorQueMatteriaRepository>();

            services.AddTransient<IFrontContentHeaderOrganizaciones, FrontContentHeaderOrganizacionesRepository>();


            services.AddTransient<IFrontContentHomeOrgContenidoRecurso, FrontContentHomeOrgContenidoRecursoRepository>();

            services.AddTransient<IFrontContentHomeImpactoPostulante, FrontContentHomeImpactoPostulanteRepository>();

            services.AddTransient<IFrontContentHomeHeaderPostulante, FrontContentHomeHeaderPostulanteRepository>();



            services.AddTransient<IFrontContentHomeGeneral, FrontContentHomeGeneralRepository>();


            services.AddTransient<IFrontContentManagerAliados, FrontContentManagerAliadosRepository>();


            services.AddTransient<IEstatusVacantes, EstatusVacantesRepository>();


            services.AddTransient<IUsuariosRoles, UsuariosRolesRepository>();

            services.AddTransient<IRoles, RolesRepository>();

            
                services.AddTransient<IFrontContentPorQueMatteria, FrontContentPorqueMatteriaRepository>();
            


                services.AddTransient<IFrontContentEstructuraSalarial, FrontContentEstructuraSalarialRepository>();




            services.AddTransient<IFrontContentManagerEquipoHeader, FrontContentManagerEquipoHeaderRepository>();


            services.AddTransient<IloginUsers, loginUsersRepository>();

            
            services.AddTransient<IMenuPrincipal, menuPrincipalRepository>();

            

            services.AddTransient<IFooter, footerRepository>();

            services.AddTransient<IEstatusVacantesProceso, EstatusVacantesProcesoRepository>();

            
            services.AddTransient<IstepBystepPostulante, stepBystepPostulanteRepository>();

            
            services.AddTransient<IvisitasVacantes,visitasVacantesRepository>();

            services.AddTransient<IConsultoriaOrganizacional, consultoriaOrganizacionalRepository>();

            services.AddTransient<IopeningOpeningInterest, openingOpeningInterestRepository>();
            


        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }
    }
}
