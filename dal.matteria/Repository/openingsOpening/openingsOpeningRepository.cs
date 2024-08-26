using biz.matteria.Entities;
using biz.matteria.Models.openingCubiertas;
using biz.matteria.Models.OpeningPostulationsCandidate;
using biz.matteria.Models.OpeningPostulatios;
using biz.matteria.Models.Openings;
using biz.matteria.Models.VisitaOpening;
using biz.matteria.Repository.openingsOpening;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.openingsOpening
{
    public class openingsOpeningRepository : GenericRepository<biz.matteria.Entities.OpeningsOpening>, IopeningsOpening
    {

        public openingsOpeningRepository(DbmatteriaContext context) : base(context) { }


        public List<OpeningsService> GetOpeningsByCompanyId(int companyId,string name,int status)
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(i => i.CompanyId == companyId)
                .Where(j => string.IsNullOrEmpty(name) || j.Name.Contains(name))
                .Where(k => status == 0 || k.StatusProcess == status)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    Name = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpening,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    description_company = i.Company.Description,
                    social_facebook = i.Company.SocialFacebook,
                    social_instagram = i.Company.SocialInstagram,
                    social_linkedin = i.Company.SocialLinkedin,
                    social_twitter = i.Company.SocialTwitter,
                    whyJoin = i.Whyjoin,
                    purposeOpening = i.PurposeOpening,
                    OpeningsOpeningProfessions = i.OpeningsOpeningProfessions,
                    areaid = i.WorkAreaId,
                    SalaryTodefine = i.SalaryTodefine,
                    logo = i.Company.Logo,
                    hunting = i.UserId,
                    estatusProceso = i.StatusProcessNavigation.Name,
                    statusVacanteId = i.StatusOpening,
                    statusProcesoVacanteId = i.StatusProcess,
                    numeroVisualizaciones = i.VisitasVacantes.Count(),
                    numeroPostulaciones = i.OpeningsOpeningcandidates.Count(),
                    nameSelected = (from oc in i.OpeningsOpeningcandidates
                                   join op in _context.OpeningsOpenings on oc.OpeningId equals op.Id
                                   join cd in _context.CandidatesCandidates on oc.CandidateId equals  cd.Id
                                   join us in _context.AuthUsers on cd.UserId equals us.Id
                                   where op.CompanyId == companyId && oc.Selected == true
                                   select us.FirstName + us.LastName).FirstOrDefault()





                }).ToList();


            return service;
        }


        public List<OpeningsService> GetAllOpeningsDestacadas()
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(y => y.Featured == true)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    Name = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpening,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    logo = i.Company.Logo,
                    nameCompany = i.Company.Name
                    



                }).ToList();


            return service;
        }


        public List<OpeningsService> GetAllOpenings(int candidateId = 0)
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(y => y.StatusOpening == 4 && (y.StatusProcess == 2 || y.StatusProcess == 3 || y.StatusProcess== 5)) //publicada(activa) estatus proceso publicada 2 -- preseleccion perfiles 3 --entrevistas individuales 5
                .OrderByDescending(j => j.Timestamp)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    Name = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpening,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    logo = i.Company.Logo,
                    nameCompany = i.Company.Name,
                    hunting = i.UserId,
                    estatusProceso = i.StatusProcessNavigation.Name,
                    statusVacanteId = i.StatusOpening,
                    statusProcesoVacanteId = i.StatusProcess,
                    tipoContrato = i.HireTypeNavigation.Name,
                    postulado = i.OpeningsOpeningcandidates.Where(x => x.CandidateId == candidateId).FirstOrDefault() == null ? false :true
                     



                }).ToList();


            return service;
        }

        public OpeningsService GetOpeningById(int id)
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(i => i.Id == id)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    Name = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpening,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    description_company = i.Company.Description,
                    social_facebook = i.Company.SocialFacebook,
                    social_instagram = i.Company.SocialInstagram,
                    social_linkedin = i.Company.SocialLinkedin,
                    social_twitter = i.Company.SocialTwitter,
                    whyJoin = i.Whyjoin,
                    purposeOpening = i.PurposeOpening,
                    OpeningsOpeningProfessions = i.OpeningsOpeningProfessions,
                    areaid = i.WorkAreaId,
                    SalaryTodefine = i.SalaryTodefine,
                    hunting = i.UserId,
                    featured = i.Featured,
                    nameCompany = i.Company.Name,
                    estatusProceso = i.StatusProcessNavigation.Name,
                    statusVacanteId = i.StatusOpening,
                    statusProcesoVacanteId = i.StatusProcess,
                    tipoContrato = i.HireTypeNavigation.Name,
                    listaProfesiones = (from p in i.OpeningsOpeningProfessions
                                        join cp in _context.CatalogsProfessions on p.ProfessionId equals cp.Id
                                        select cp.Name).ToList(),
                    interest = i.OpeningsOpeningInterests

                    
                   




                }).FirstOrDefault();


            
                if (service.listaProfesiones.Count > 0)
                {
                    foreach (var j in service.listaProfesiones)
                    {
                        service.profesiones = service.profesiones + j + ",";
                    }

                    service.profesiones = service.profesiones.TrimEnd(',');

                }


            


            return service;
        }



        public List<OpeningsService> GetOpeningsByCandidateId(int candidateId)
        {
            var service = _context.OpeningsOpeningcandidates
                .Include(d => d.StatusPostulationNavigation)
                .Include(a => a.Opening)
                .Include(c => c.Opening.Company)
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Opening.Activities,
                    AlternateCompanyAlias = i.Opening.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.Opening.AlternateCompanyDescription,
                    Avaliability = i.Opening.Avaliability,
                    City = i.Opening.City,
                    CloseOpening = i.Opening.CloseOpening,
                    CompanyId = i.Opening.CompanyId,
                    ConsultantId = i.Opening.ConsultantId,
                    CountryId = i.Opening.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.Opening.CurrencyId,
                    Name = i.Opening.Name,
                    KeySkills = i.Opening.KeySkills,
                    OpeningTypeId = i.Opening.OpeningTypeId,
                    OpenOpening = i.Opening.OpenOpening,
                    Perks = i.Opening.Perks,
                    PrivateSalary = i.Opening.PrivateSalary,
                    RelevantDetails = i.Opening.RelevantDetails,
                    Responsabilities = i.Opening.Responsabilities,
                    Salary = i.Opening.Salary,
                    Status = i.Status,
                    StatusOpening = i.Opening.StatusOpening,
                    YearsExperience = i.Opening.YearsExperience,
                    YearsExperienceOpening = i.Opening.YearsExperienceOpening,
                    HireType = i.Opening.HireType,
                    description_company = i.Opening.Company.Description,
                    social_facebook = i.Opening.Company.SocialFacebook,
                    social_instagram = i.Opening.Company.SocialInstagram,
                    social_linkedin = i.Opening.Company.SocialLinkedin,
                    social_twitter = i.Opening.Company.SocialTwitter,
                    whyJoin = i.Opening.Whyjoin,
                    statusPostulation = i.Opening.StatusProcess == 2 ? "Postulación recibida" : i.Opening.StatusProcessNavigation.Name,
                    nameCompany = i.Opening.Company.Name,
                    applicationdate = i.Timestamp.ToString("dd/MM/yyyy"),
                    hunting = i.Opening.UserId,
                    logo = i.Opening.Company.Logo,
                    estatusProceso = i.Opening.StatusProcess == 2 ? "Postulación recibida" : i.Opening.StatusProcessNavigation.Name,
                    statusVacanteId = i.Opening.StatusOpening,
                    statusProcesoVacanteId = i.Opening.StatusProcess,
                    statusVacante =  i.Opening.StatusOpeningNavigation.Name
                    



                }).ToList();


            return service;
        }

        public List<userOpening> GetPostulationsAndCandidates(int openingId)
        {



            var service = _context.OpeningsOpeningcandidates
            .Include(a => a.Candidate)
            .Include(c => c.Candidate.User)
            .Where(z => z.OpeningId == openingId && z.Candidate.UserId != null)
            .Select(i => new userOpening
            {
                Id = i.Id,
                gender = i.Candidate.Genre,
                name = i.Candidate.User.FirstName,
                name_second = i.Candidate.User.LastName,
                avatar = i.Candidate.Avatar,
                birthday = i.Candidate.Birthday,
                candidateId = i.Candidate.Id,
                city = i.Candidate.City,
                countryId = i.Candidate.CountryId,
                email = i.Candidate.User.Email,
                phone = i.Candidate.CellphoneNumber == null ? "no capturado": i.Candidate.CellphoneNumber,
                userId = i.Candidate.UserId,
                selected = i.Selected,
                score = i.Score






            }).ToList();

            return service;


        }


        public OpenignRptVacantes GetOpeningsTotalesRptVacantes(string fechaInicial, string fechaFinal, int companyId, string descripcion, int sector, int pais, string ciudad, int status, int companyTypeId, string jornada, int tipoContratoId)
        {
            decimal sumaPrecio = 0;
            int sumaPostulaciones = 0;
            int companys = 0;
            int vacantes = 0;
            OpenignRptVacantes modelResponse = new OpenignRptVacantes();


            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(b => b.OpenOpening.Date >= Convert.ToDateTime(fechaInicial).Date && b.OpenOpening.Date <= Convert.ToDateTime(fechaFinal).Date)
                .Where(e => companyId == 0 || e.CompanyId == companyId)
                .Where(j => string.IsNullOrEmpty(descripcion) || j.Name.Contains(descripcion))
                .Where(k => sector == 0 || k.Company.CompanyTypeId == sector)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
                .Where(j => status == 0 || j.StatusOpening == status)
                .Where(k => companyTypeId == 0 || k.Company.CompanyTypeId == companyTypeId)
                .Where(j => string.IsNullOrEmpty(jornada) || j.Avaliability == jornada)
                .Where(k => tipoContratoId == 0 || k.HireType == tipoContratoId)
                .Select(i => new openingServiceBackOffice
                {
                    openingId = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    nameOpening = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpeningNavigation.Name,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    description_company = i.Company.Description,
                    social_facebook = i.Company.SocialFacebook,
                    social_instagram = i.Company.SocialInstagram,
                    social_linkedin = i.Company.SocialLinkedin,
                    social_twitter = i.Company.SocialTwitter,
                    whyJoin = i.Whyjoin,
                    purposeOpening = i.PurposeOpening,
                    OpeningsOpeningProfessions = i.OpeningsOpeningProfessions,
                    areaid = i.WorkAreaId,
                    SalaryTodefine = i.SalaryTodefine,
                    logo = i.Company.Logo,
                    hunting = i.UserId,
                    featured = i.Featured,
                    nameCompany = i.Company.Name,
                    sector = i.Company.CompanyType.Name,
                    pais = i.Company.Country.Name,
                     paquetes = (from a in i.Creditos
                                 join cm in _context.compraPaquete on a.IdCompra equals cm.Id
                                 join pa in _context.FrontContentVacantesPaquetes on cm.IdProducto equals pa.Id
                                 where a.IdCompra != null && a.IdOpening == i.Id
                                 select pa).ToList(),
                     postulantes = i.OpeningsOpeningcandidates.Count(),
                    asignacion = i.User,
                    tipoContrato = i.HireTypeNavigation.Name,
                    tipoOrganizacion = i.Company.CompanyType.Name,
                    estatusAsignacion = i.User == null ? "No asiganada" : "Asignada"





                }).ToList();

            foreach(var item in service)
            {
                foreach(var itemp in item.paquetes.GroupBy(y => y.Id).Select(y => y.First()).ToList())
                {
                    sumaPrecio += itemp.RealPrice;
                    
                }

                sumaPostulaciones += item.postulantes;
            }

            
            if(service.Count > 0)
            {
                

                companys = service.GroupBy(y => y.CompanyId).Count();

            }




            modelResponse.ofertas = service.Count();
            modelResponse.ofertasCanceladas = service.Where(x => x.StatusOpening == "cancelada").Count();
            modelResponse.ofertasCerradas = service.Where(x => x.StatusOpening == "cubierta").Count();
            //modelResponse.ingresosOfertas = sumaPrecio;
            modelResponse.ofertasActivas = service.Where(x => x.StatusOpening == "activa").Count();
            modelResponse.Postulaciones = sumaPostulaciones;

            //try
            //{
            //    modelResponse.promedioOfertasOrganizacion = service.Count() / companys;

            //}
            //catch (Exception ex)
            //{
            //    modelResponse.promedioOfertasOrganizacion = 0;

            //}

            return modelResponse;

        }

        public List<openingServiceBackOffice> GetOpeningsFilterSearch(string fechaInicial, string fechaFinal, int companyId, string descripcion,int sector,int pais,string ciudad,int status,int companyTypeId,string jornada,int tipoContratoId)
        {


            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(b => b.OpenOpening >= Convert.ToDateTime(fechaInicial) && b.OpenOpening <= Convert.ToDateTime(fechaFinal))
                .Where(e => companyId == 0 || e.CompanyId == companyId)
                .Where(j => string.IsNullOrEmpty(descripcion) || j.Name.Contains(descripcion))
                .Where(k => sector == 0 || k.Company.CompanyTypeId == sector)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
                .Where(j => status == 0 || j.StatusOpening == status)
                .Where(k => companyTypeId == 0 || k.Company.CompanyTypeId == companyTypeId)
                .Where(j => string.IsNullOrEmpty(jornada) || j.Avaliability == jornada)
                .Where(k => tipoContratoId == 0 || k.HireType == tipoContratoId)
                .Select(i => new openingServiceBackOffice
                {
                    openingId = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    nameOpening = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpeningNavigation.Name,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    description_company = i.Company.Description,
                    social_facebook = i.Company.SocialFacebook,
                    social_instagram = i.Company.SocialInstagram,
                    social_linkedin = i.Company.SocialLinkedin,
                    social_twitter = i.Company.SocialTwitter,
                    whyJoin = i.Whyjoin,
                    purposeOpening = i.PurposeOpening,
                    OpeningsOpeningProfessions = i.OpeningsOpeningProfessions,
                    areaid = i.WorkAreaId,
                    SalaryTodefine = i.SalaryTodefine,
                    logo = i.Company.Logo,
                    hunting = i.UserId,
                    featured = i.Featured,
                    nameCompany = i.Company.Name,
                    sector = i.Company.CompanyType.Name,
                    pais = i.Company.Country.Name,
                    postulantes = i.OpeningsOpeningcandidates.Count(),
                    email = i.Company.User.Email,
                    statusVacanteProceso = i.StatusProcessNavigation.Name,
                    statusVacanteId = i.StatusOpening,
                    statusProcesoVacanteId = i.StatusProcess,
                    numeroVisualizaciones = i.VisitasVacantes.Count(),
                    numeroPostulaciones = i.OpeningsOpeningcandidates.Count(),
                    nameSelected = (from oc in i.OpeningsOpeningcandidates
                                    join op in _context.OpeningsOpenings on oc.OpeningId equals op.Id
                                    join cd in _context.CandidatesCandidates on oc.CandidateId equals cd.Id
                                    join us in _context.AuthUsers on cd.UserId equals us.Id
                                    where oc.Selected == true
                                    select us.FirstName + us.LastName).FirstOrDefault(),
                    asignacion = i.User,
                    tipoContrato = i.HireTypeNavigation.Name,
                    tipoOrganizacion = i.Company.CompanyType.Name,
                    estatusAsignacion = i.User == null ? "No asiganada" : "Asignada"








                }).ToList();


            return service;
        }

        public List<openingCubiertas> GetOpeningCubiertas()
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(x => x.StatusProcess == 6) //estatus del proceso vacante finalizada // se cambio a cerrada que es cuando ya se le asigno a alguien
                .Select(i => new openingCubiertas
                {
                    id = i.Id,
                    logo = i.Company.Logo,
                    nombreVacante = i.Name,
                    organizacion = i.Company.Name



                }).ToList();

            if(service.Count < 3)
            {

                service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(x => x.StatusProcess == 6 && x.StatusProcess == 2) // se cambio a cerrada que es cuando ya se le asigno a alguien y tambien las que esten publicadas
                .Select(i => new openingCubiertas
                {
                    id = i.Id,
                    logo = i.Company.Logo,
                    nombreVacante = i.Name,
                    organizacion = i.Company.Name



                }).ToList();

            }

            

            return service;

        }

        public List<openingddl> GetAllOpeningsDDL()
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Where(y => y.StatusOpening == 4)// publicada(activa)
                .Select(i => new openingddl
                {
                    id = i.Id,
                    name = i.Name
                    



                }).ToList();


            return service;
        }

        public List<userOpening> GetPostulacionesCandidatos()
        {
            var service = _context.OpeningsOpeningcandidates
            .Include(a => a.Candidate)
            .Include(c => c.Candidate.User)
            .Select(i => new userOpening
            {
                Id = i.Id,
                gender = i.Candidate.Genre,
                name = i.Candidate.User.FirstName,
                name_second = i.Candidate.User.LastName,
                avatar = i.Candidate.Avatar,
                birthday = i.Candidate.Birthday,
                candidateId = i.Candidate.Id,
                city = i.Candidate.City,
                countryId = i.Candidate.CountryId,
                email = i.Candidate.User.Email,
                phone = i.Candidate.CellphoneNumber,
                userId = i.Candidate.UserId






            }).ToList();

            return service;


        }

        public List<openingCompanyCandidate> GetOpeningCandidatesCompany(int companyId)
        {
            var service = _context.OpeningsOpenings
                .Where(x => x.CompanyId == companyId)
                .Select(i => new openingCompanyCandidate
                {
                    openingId = i.Id,
                    logo = i.Company.Logo,
                    dateOpening = i.OpenOpening,
                    nameCompany = i.Company.Name,
                    nameOpening = i.Name,
                    candidatesOpening =(from oc in i.OpeningsOpeningcandidates
                                        join cd in _context.CandidatesCandidates on oc.CandidateId equals cd.Id
                                        join us in _context.AuthUsers on cd.UserId equals us.Id
                                        select us).ToList(),

                    dateCloseOpening = i.CloseOpening,
                     datePublicaOpening = i.OpenOpening,
                      ciudad = i.City,
                      estatus = i.StatusOpeningNavigation.Name,
                      disponibilidad = i.Avaliability,
                      colorEstatus = (from st in _context.estatusvacantes
                                     where st.Id == i.StatusOpening
                                     select st.Color).FirstOrDefault(),
                      pais = i.Country.Name,
                    prospectos = i.OpeningsOpeningcandidates.Count()
                    





                }).ToList();

            return service;
        }

        public List<OpeningsService> GetOpeningAllCloseCaducidad()
        {
            var service = _context.OpeningsOpenings
                .Include(x => x.Company)
                .Select(i => new OpeningsService
                {
                    Id = i.Id,
                    Activities = i.Activities,
                    AlternateCompanyAlias = i.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.AlternateCompanyDescription,
                    Avaliability = i.Avaliability,
                    City = i.City,
                    CloseOpening = i.CloseOpening,
                    CompanyId = i.CompanyId,
                    ConsultantId = i.ConsultantId,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    CurrencyId = i.CurrencyId,
                    Name = i.Name,
                    KeySkills = i.KeySkills,
                    OpeningTypeId = i.OpeningTypeId,
                    OpenOpening = i.OpenOpening,
                    Perks = i.Perks,
                    PrivateSalary = i.PrivateSalary,
                    RelevantDetails = i.RelevantDetails,
                    Responsabilities = i.Responsabilities,
                    Salary = i.Salary,
                    Status = i.Status,
                    StatusOpening = i.StatusOpening,
                    YearsExperience = i.YearsExperience,
                    YearsExperienceOpening = i.YearsExperienceOpening,
                    HireType = i.HireType,
                    logo = i.Company.Logo,
                    nameCompany = i.Company.Name,
                    hunting = i.UserId,
                    estatusProceso = i.StatusProcessNavigation.Name,
                    statusVacanteId = i.StatusOpening,
                    statusProcesoVacanteId = i.StatusProcess



                }).ToList();


            return service;
        }

        public List<OpeningsService> GetVacantesVisitadas(int postulanteId)
        {

            var service = _context.visitaVacante
                .Where(j => j.PostulanteId == postulanteId)
                .Select(i => new OpeningsService
                {
                    Id = i.Vacante.Id,
                    Activities = i.Vacante.Activities,
                    AlternateCompanyAlias = i.Vacante.AlternateCompanyAlias,
                    AlternateCompanyDescription = i.Vacante.AlternateCompanyDescription,
                    Avaliability = i.Vacante.Avaliability,
                    City = i.Vacante.City,
                    CloseOpening = i.Vacante.CloseOpening,
                    CompanyId = i.Vacante.CompanyId,
                    ConsultantId = i.Vacante.ConsultantId,
                    CountryId = i.Vacante.CountryId,
                    CreatedById = i.Vacante.CreatedById,
                    CurrencyId = i.Vacante.CurrencyId,
                    Name = i.Vacante.Name,
                    KeySkills = i.Vacante.KeySkills,
                    OpeningTypeId = i.Vacante.OpeningTypeId,
                    OpenOpening = i.Vacante.OpenOpening,
                    Perks = i.Vacante.Perks,
                    PrivateSalary = i.Vacante.PrivateSalary,
                    RelevantDetails = i.Vacante.RelevantDetails,
                    Responsabilities = i.Vacante.Responsabilities,
                    Salary = i.Vacante.Salary,
                    Status = i.Vacante.Status,
                    StatusOpening = i.Vacante.StatusOpening,
                    YearsExperience = i.Vacante.YearsExperience,
                    YearsExperienceOpening = i.Vacante.YearsExperienceOpening,
                    HireType = i.Vacante.HireType,
                    logo = i.Vacante.Company.Logo,
                    nameCompany = i.Vacante.Company.Name,
                    hunting = i.Vacante.UserId,
                    estatusProceso = i.Vacante.StatusProcessNavigation.Name,
                    statusVacanteId = i.Vacante.StatusOpening,
                    statusProcesoVacanteId = i.Vacante.StatusProcess,
                    pais = i.Vacante.Country.Name,
                    numeroVisitas = (from vv in _context.visitaVacante
                                    where vv.VacanteId == i.Vacante.Id && vv.PostulanteId == postulanteId
                                    select vv.Id).Count(),
                    nameStatusVacante = i.Vacante.StatusOpeningNavigation.Name,
                    statusPostulation = i.Vacante.StatusProcess == 2 ? "Postulación recibida" : i.Vacante.StatusProcessNavigation.Name,



                }).ToList();


            service = service.GroupBy(i => i.Id).Select(y => y.First()).ToList();

            return service;

        }

        public List<visitaOpening> GetPopUpVacantesVisitadas(int openingId)
        {
            var service = _context.visitaVacante
                .Where(i => i.VacanteId == openingId)
                .Select(j => new visitaOpening
                {
                    candidateId = j.Postulante.Id,
                    avatar = j.Postulante.Avatar,
                    nombre = j.Postulante.User.FirstName + " " + j.Postulante.User.LastName,
                    ciudad = j.Postulante.City,
                    pais = j.Postulante.Country.Name,
                    postulado = j.Vacante.OpeningsOpeningcandidates.Count == 0 ? false : true



                }).ToList();


            service = service.GroupBy(y => y.candidateId).Select(y => y.First()).ToList();

            return service;
        }

        public List<OpeningsOpeningInterest> GetOpeningInterest(int openingId)
        {
            var service = _context.openinginterest
                .Select(i => new OpeningsOpeningInterest
                {
                    Id = i.Id,
                    InterestId = i.InterestId,
                    OpeningId = i.OpeningId



                }).ToList();


            return service;
        }
    }
}
