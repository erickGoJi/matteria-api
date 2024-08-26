using biz.matteria.Entities;
using biz.matteria.Models.Company;
using biz.matteria.Models.ddlCompanys;
using biz.matteria.Repository.CompaniesCompany;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CompaniesCompany
{
    public class CompaniesCompanyRepository : GenericRepository<biz.matteria.Entities.CompaniesCompany>, ICompaniesCompany
    {
        public CompaniesCompanyRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Models.Company.companyService GetCompanyById(int companyId)
        {
            var service = _context.company
                .Where(x => x.Id == companyId)
                .Select(i => new biz.matteria.Models.Company.companyService
                {
                    BillingAddress = i.BillingAddress,
                    BillingCity = i.BillingCity,
                    BillingCountryId = i.BillingCountryId,
                    BillingName = i.BillingName,
                    BillingNumber = i.BillingNumber,
                    BillingPhoneNumber = i.BillingPhoneNumber,
                    City = i.City,
                    CompanyTypeId = i.CompanyTypeId,
                    ConsultantId = i.ConsultantId,
                    ContactCellphoneNumber = i.ContactCellphoneNumber,
                    ContactEmail = i.ContactEmail,
                    ContactName = i.ContactName,
                    ContactPhoneNumber = i.ContactPhoneNumber,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    Description = i.Description,
                    FromTcs = i.FromTcs,
                    HowDidYouFindOut = i.HowDidYouFindOut,
                    HowHearAboutUsId = i.HowHearAboutUsId,
                    Id = i.Id,
                    Logo = i.Logo,
                    Name = i.Name,
                    OurAdn = i.OurAdn,
                    OurImpactinfo = i.OurImpactinfo,
                    SocialFacebook = i.SocialFacebook,
                    SocialInstagram = i.SocialInstagram,
                    SocialLinkedin = i.SocialLinkedin,
                    SocialTwitter = i.SocialTwitter,
                    StatusCompany = i.StatusCompany,
                    nameRepresentante = i.User.FirstName,
                    email = i.User.Email,
                    aprobada = i.Approve,
                    asignacion = i.UserConsultor,
                    apellidoRepresentante = i.User.LastName







                }).FirstOrDefault();

            return service;
        }

        //public enlistaCompanysTotales GetCompanysReport(string fechaInicial, string FechaFinal, int sector, int pais, string ciudad)
        //{

        //    enlistaCompanysTotales modelResponse = new enlistaCompanysTotales();
        //    int promedio = 0;
        //    int suma = 0;
        //    int sumaPostulaciones = 0;
        //    int sumaVcantes = 0;
        //    int sumaProspectos = 0;
        //    int sumaSesiones = 0;

        //    var service = _context.company
        //        .Where(b => b.Timestamp >= Convert.ToDateTime(fechaInicial) && b.Timestamp <= Convert.ToDateTime(FechaFinal))
        //        .Where(k => sector == 0 || k.CompanyTypeId == sector)
        //        .Where(k => pais == 0 || k.CountryId == pais)
        //        .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
        //        .Select(i => new enlistaCompany
        //        {
        //            name = i.Name,
        //            representante = i.User.FirstName + i.User.LastName,
        //            email = i.User.Email,
        //            pais = i.Country.Name,
        //            city = i.City,
        //            sector = i.CompanyType.Name,
        //            openings = i.OpeningsOpenings.Count(),
        //            paquetes = (from a in i.Creditos
        //                        join cm in _context.compraPaquete on a.IdCompra equals cm.Id
        //                        join pa in _context.FrontContentVacantesPaquetes on cm.IdProducto equals pa.Id
        //                        where a.IdCompra != null && a.IdCompany == i.Id
        //                        select pa.Id).Count(),
        //            prospectos = (from op in i.OpeningsOpenings
        //                          join opc in _context.OpeningsOpeningcandidates on op.Id equals opc.OpeningId
        //                          where op.CompanyId == i.Id
        //                          select opc.CandidateId).Count(),
        //            contact_cellphone_number = i.ContactCellphoneNumber,
        //            id = i.User.Id,
        //            candidateId = i.Id,
        //            nameCountry = i.Country.Name,
        //            sesiones = i.User.LoginUsers.Count()



        //        }).ToList();



        //    foreach(var item in service)
        //    {
        //        sumaVcantes += item.openings;
        //        sumaProspectos += item.prospectos;
        //        sumaSesiones += item.sesiones;
        //    }

        //    modelResponse.totalOrganizaciones = service.Count();
        //    modelResponse.nuevasVacantes = sumaVcantes;
        //    modelResponse.TotalPostulaciones = sumaProspectos;
        //    modelResponse.iniciosSesion = sumaSesiones;
        //    try
        //    {
        //        modelResponse.edadPromedio = sumaVcantes / service.Count();
        //    }
        //    catch(Exception ex)
        //    {
        //        modelResponse.edadPromedio=0;
        //    }


        //    return modelResponse;
        //}



        public enlistaCompanysTotales GetCompanysReport(string nameCompany, int pais, int tipoOrganizacion, int? aprobadas, int? status)
        {

            enlistaCompanysTotales modelResponse = new enlistaCompanysTotales();
            int promedio = 0;
            int suma = 0;
            int sumaPostulaciones = 0;
            int sumaVcantes = 0;
            int sumaProspectos = 0;
            int sumaSesiones = 0;

            var service = _context.company
                .Where(k => string.IsNullOrEmpty(nameCompany) || k.Name == nameCompany)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(k => tipoOrganizacion == 0 || k.CompanyTypeId == tipoOrganizacion)
                .Where(k => aprobadas == -1 || k.Approve == Convert.ToBoolean(aprobadas))
                .Where(k => status == -1 || k.Approve == Convert.ToBoolean(status))
                .Select(i => new enlistaCompany
                {
                    name = i.Name,
                    representante = i.User.FirstName + i.User.LastName,
                    email = i.User.Email,
                    pais = i.Country.Name,
                    city = i.City,
                    sector = i.CompanyType.Name,
                    openings = i.OpeningsOpenings.Count(),
                    paquetes = (from a in i.Creditos
                                join cm in _context.compraPaquete on a.IdCompra equals cm.Id
                                join pa in _context.FrontContentVacantesPaquetes on cm.IdProducto equals pa.Id
                                where a.IdCompra != null && a.IdCompany == i.Id
                                select pa.Id).Count(),
                    prospectos = (from op in i.OpeningsOpenings
                                  join opc in _context.OpeningsOpeningcandidates on op.Id equals opc.OpeningId
                                  where op.CompanyId == i.Id
                                  select opc.CandidateId).Count(),
                    contact_cellphone_number = i.ContactCellphoneNumber,
                    id = i.User.Id,
                    candidateId = i.Id,
                    nameCountry = i.Country.Name,
                    sesiones = i.User.LoginUsers.Count(),
                    asignaciones = i.UserConsultor,
                    statusAsignadas = i.UserConsultor == null ? "Sin asignar" : "Asignada"




                }).ToList();



            foreach (var item in service)
            {
                sumaVcantes += item.openings;
                sumaProspectos += item.prospectos;
                sumaSesiones += item.sesiones;
            }

            modelResponse.totalOrganizaciones = service.Count();
            modelResponse.nuevasVacantes = sumaVcantes;
            modelResponse.TotalPostulaciones = sumaProspectos;
            modelResponse.iniciosSesion = sumaSesiones;
            try
            {
                modelResponse.edadPromedio = sumaVcantes / service.Count();
            }
            catch (Exception ex)
            {
                modelResponse.edadPromedio = 0;
            }


            return modelResponse;
        }

        public CrearCuentaOrganizacionConfiguracion GetConfiguracionCrearCuentaOrganizacion(int languageId)
        {

            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);




            var service = _context.cuentaorgconfig
                .Select(i => new CrearCuentaOrganizacionConfiguracion
                {
                    Id = i.Id,
                    InputConfirmPassword = Funclanguage(i.InputConfirmPassword, i.InputConfirmPasswordEn, i.InputConfirmPasswordPt, languageId),
                    InputEmail = Funclanguage(i.InputEmail, i.InputEmailEn, i.InputEmailPt, languageId),
                    InputOrganizationName = Funclanguage(i.InputOrganizationName, i.InputOrganizationNameEn, i.InputOrganizationNamePt, languageId),
                    InputPassword = Funclanguage(i.InputPassword, i.InputPasswordEn, i.InputPasswordPt, languageId),
                    InputResponsable = Funclanguage(i.InputResponsable, i.InputResponsableEn, i.InputResponsableEn, languageId),
                    PlaceHolderConfirmPassword = Funclanguage(i.PlaceHolderConfirmPassword, i.PlaceHolderConfirmPasswordEn, i.PlaceHolderConfirmPasswordPt, languageId),
                    PlaceHolderEmail = Funclanguage(i.PlaceHolderEmail, i.PlaceHolderEmailEn, i.PlaceHolderEmailPt, languageId),
                    PlaceHolderOrganizationName = Funclanguage(i.PlaceHolderOrganizationName, i.PlaceHolderOrganizationNameEn, i.PlaceHolderOrganizationNamePt, languageId),
                    PlaceHolderPassword = Funclanguage(i.PlaceHolderPassword, i.PlaceHolderPasswordEn, i.PlaceHolderPasswordPt, languageId),
                    PlaceHolderResponsable = Funclanguage(i.PlaceHolderResponsable, i.PlaceHolderResponsableEn, i.PlaceHolderResponsablePt, languageId),
                    SmallOneConfirmPassword = Funclanguage(i.SmallOneConfirmPassword, i.SmallOneConfirmPasswordEn, i.SmallOneConfirmPasswordPt, languageId),
                    SmallOneEmail = Funclanguage(i.SmallOneEmail, i.SmallOneEmailEn, i.SmallOneEmailPt, languageId),
                    SmallPassword = Funclanguage(i.SmallPassword, i.SmallPasswordEn, i.SmallPasswordPt, languageId),
                    SmallResponsable = Funclanguage(i.SmallResponsable, i.SmallResponsableEn, i.SmallResponsablePt, languageId),
                    SmalltOrganizationName = Funclanguage(i.SmalltOrganizationName, i.SmalltOrganizationNameEn, i.SmalltOrganizationNamePt, languageId),
                    SmallTwoConfirmPassword = Funclanguage(i.SmallTwoConfirmPassword, i.SmallTwoConfirmPasswordEn, i.SmallTwoConfirmPasswordPt, languageId),
                    SmallTwoEmail = Funclanguage(i.SmallTwoEmail, i.SmallTwoEmailEn, i.SmallTwoEmailPt, languageId),
                    SubTittle = Funclanguage(i.SubTittle, i.SubTittleEn, i.SubTittlePt, languageId),
                    Tittle = Funclanguage(i.Tittle, i.TittleEn, i.TittlePt, languageId),
                    ToastEmail = Funclanguage(i.ToastEmail, i.ToastEmailEn, i.ToastEmailPt, languageId),
                    Activate = Funclanguage(i.Activate, i.ActivateEn, i.ActivatePt, languageId),
                    Mail = Funclanguage(i.Mail, i.MailEn, i.MailPt, languageId),
                    Ready = Funclanguage(i.Ready, i.ReadyEn, i.ReadyPt, languageId),
                    Resend = Funclanguage(i.Resend, i.ResendEn, i.ResendPt, languageId),
                    SmallTerminos = Funclanguage(i.SmallTerminos, i.SmallTerminosEn, i.SmallTerminosPt, languageId),
                    Terminos = Funclanguage(i.Terminos, i.TerminosEn, i.TerminosPt, languageId)





                }).FirstOrDefault();


            return service;
        }

        public IngresoOrganizacionConfiguracion GetConfiguracionIngresoOrganizacion(int languageId)
        {

            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);





            var service = _context.ingresoOrgConfig
                .Select(i => new IngresoOrganizacionConfiguracion
                {
                    Id = i.Id,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    BtnCreater = Funclanguage(i.BtnCreater, i.BtnCreaterEn, i.BtnCreaterPt, languageId),
                    BtnLogIng = Funclanguage(i.BtnLogIng, i.BtnLogIngEn, i.BtnLogIngPt, languageId),
                    EmailInvalid = Funclanguage(i.EmailInvalid, i.EmailInvalidEn, i.EmailInvalidPt, languageId),
                    ForgotePassword = Funclanguage(i.ForgotePassword, i.ForgotePasswordEn, i.ForgotePasswordPt, languageId),
                    NoEmail = Funclanguage(i.NoEmail, i.NoEmailEn, i.NoEmailPt, languageId),
                    PlaceHolderEmail = Funclanguage(i.PlaceHolderEmail, i.PlaceHolderEmailEn, i.PlaceHolderEmailPt, languageId),
                    PlaceHolderPassword = Funclanguage(i.PlaceHolderPassword, i.PlaceHolderPasswordEn, i.PlaceHolderPasswordPt, languageId),
                    WhritePassword = Funclanguage(i.WhritePassword, i.WhritePasswordEn, i.WrhiteEmailPt, languageId),
                    WrhiteEmail = Funclanguage(i.WrhiteEmail, i.WrhiteEmailEn, i.WrhiteEmailPt, languageId)

                }).FirstOrDefault();

            return service;
        }

        public ConfiguracionMisVacantesOrganizacion GetConfiguracionMisVacantes(int languajeId)
        {
            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);

            var service = _context.confMisVcanatesOrg
                .Select(i => new ConfiguracionMisVacantesOrganizacion
                {
                    HolderBusqueda = Funclanguage(i.HolderBusqueda, i.HolderBusquedaEn, i.HolderBusquedaPt, languajeId),
                    Id = i.Id,
                    LblConfiguracion = Funclanguage(i.LblConfiguracion, i.LblConfiguracionEn, i.LblConfiguracionPt, languajeId),
                    LblEditar = Funclanguage(i.LblEditar, i.LblEditarEn, i.LblEditarPt, languajeId),
                    LblFechaCierre = Funclanguage(i.LblFechaCierre, i.LblFechaCierreEn, i.LblFechaCierrePt, languajeId),
                    LblFechaPublica = Funclanguage(i.LblFechaPublica, i.LblFechaPublicaEn, i.LblFechaPublicaPt, languajeId),
                    LblMiPerfil = Funclanguage(i.LblMiPerfil, i.LblMiPerfilEn, i.LblMiPerfilPt, languajeId),
                    LblMisVacantes = Funclanguage(i.LblMisVacantes, i.LblMisVacantesEn, i.LblMisVacantesPt, languajeId),
                    LblPostulante = Funclanguage(i.LblPostulante, i.LblPostulanteEn, i.LblPostulantePt, languajeId),
                    LblPublicada = Funclanguage(i.LblPublicada, i.LblPublicadaEn, i.LblPublicadaPt, languajeId),
                    LblStatus = Funclanguage(i.LblStatus, i.LblStatusEn, i.LblStatusPt, languajeId),
                    LblTextCandidato = Funclanguage(i.LblTextCandidato, i.LblTextCandidatoEn, i.LblTextCandidatoPt, languajeId),
                    LblVisualiza = Funclanguage(i.LblVisualiza, i.LblVisualizaEn, i.LblVisualizaPt, languajeId),
                    UrlMiPerfil = i.UrlMiPerfil,
                    LblCiudad = Funclanguage(i.LblCiudad, i.LblCiudadEn, i.LblCiudadPt, languajeId),
                    LblCiudadResidencia = Funclanguage(i.LblCiudadResidencia, i.LblCiudadResidenciaEn, i.LblCiudadResidenciaPt, languajeId),
                    LblFechaNacimiento = Funclanguage(i.LblFechaNacimiento, i.LblFechaNacimientoEn, i.LblFechaNacimientoPt, languajeId),
                    LblIngresa = Funclanguage(i.LblIngresa, i.LblIngresaEn, i.LblIngresaPt, languajeId),
                    LblModalHomderNombre = Funclanguage(i.LblModalHomderNombre, i.LblModalHomderNombreEn, i.LblModalHomderNombrePt, languajeId),
                    LblModalNombre = Funclanguage(i.LblModalNombre, i.LblModalNombreEn, i.LblModalNombrePt, languajeId),
                    LblModalPerfil = Funclanguage(i.LblModalPerfil, i.LblModalPerfilEn, i.LblModalPerfilPt, languajeId),
                    LblNombre = Funclanguage(i.LblNombre, i.LblNombreEn, i.LblNombrePt, languajeId),
                    LblPais = Funclanguage(i.LblPais, i.LblPaisEn, i.LblPaisPt, languajeId),
                    LblPaisResidencia = Funclanguage(i.LblPaisResidencia, i.LblPaisResidenciaEn, i.LblPaisResidenciaPt, languajeId),
                    LblRating = Funclanguage(i.LblRating, i.LblRatingEn, i.LblRatingPt, languajeId),
                    LblSeleccionado = Funclanguage(i.LblSeleccionado, i.LblSeleccionadoEn, i.LblSeleccionadoPt, languajeId),
                    LblSePostulo = Funclanguage(i.LblSePostulo, i.LblSePostuloEn, i.LblSePostuloPt, languajeId),
                    LblTitlePostulacion = Funclanguage(i.LblTitlePostulacion, i.LblTitlePostulacionEn, i.LblTitlePostulacionPt, languajeId),
                    LblTodos = Funclanguage(i.LblTodos, i.LblTodosEn, i.LblTodosPt, languajeId),
                    TitleVisualizacion = Funclanguage(i.TitleVisualizacion, i.TitleVisualizacionEn, i.TitleVisualizacionPt, languajeId),
                     LblMomento = Funclanguage(i.LblMomento, i.LblMomentoEn, i.LblMomentoPt, languajeId)
                      







                }).FirstOrDefault();

            return service;

        }

        public ConfiguracionOrganizacion GetConfiguracionOrganizacion(int languajeId)
        {
            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);

            var service = _context.configOrg
                .Select(i => new ConfiguracionOrganizacion
                {
                    ActualPassword = Funclanguage(i.ActualPassword, i.ActualPasswordEn, i.ActualPasswordPt, languajeId),
                    BtnChangePassword = Funclanguage(i.BtnChangePassword, i.BtnChangePasswordEn, i.BtnChangePasswordPt, languajeId),
                    BtnDelete = Funclanguage(i.BtnDelete, i.BtnDeleteEn, i.BtnDeletePt, languajeId),
                    ConfirmPassword = Funclanguage(i.ConfirmPassword, i.ConfirmPasswordEn, i.ConfirmPasswordPt, languajeId),
                    Id = i.Id,
                    MenuConfiguracion = Funclanguage(i.MenuConfiguracion, i.MenuConfiguracionEn, i.MenuConfiguracionPt, languajeId),
                    MenuMisvacantes = Funclanguage(i.MenuMisvacantes, i.MenuMisvacantesEn, i.MenuMisvacantesPt, languajeId),
                    MenuPerfil = Funclanguage(i.MenuPerfil, i.MenuPerfilEn, i.MenuPerfilPt, languajeId),
                    MenuUrlConfiguracion = i.MenuUrlConfiguracion,
                    MenuUrlMisvacantes = i.MenuUrlMisvacantes,
                    MenuUrlPerfil = i.MenuUrlPerfil,
                    NewPassword = Funclanguage(i.NewPassword, i.NewPasswordEn, i.NewPasswordPt, languajeId),
                    NotificationBox = Funclanguage(i.NotificationBox, i.NotificationBoxEn, i.NotificationBoxPt, languajeId),
                    PlaceHolders = Funclanguage(i.PlaceHolders, i.PlaceHoldersEn, i.PlaceHoldersPt, languajeId),
                    Reasons = Funclanguage(i.Reasons, i.ReasonsEn, i.ReasonsPt, languajeId),
                    SamllPassword = Funclanguage(i.SamllPassword, i.SamllPasswordEn, i.SamllPasswordPt, languajeId),
                    SmallsRequired = Funclanguage(i.SmallsRequired, i.SmallsRequiredEn, i.SmallsRequiredPt, languajeId),
                    SubtitleFour = Funclanguage(i.SubtitleFour, i.SubtitleFourEn, i.SubtitleFourPt, languajeId),
                    SubtitleOne = Funclanguage(i.SubtitleOne, i.SubtitleOneEn, i.SubtitleOnePt, languajeId),
                    SubTitleThree = Funclanguage(i.SubTitleThree, i.SubTitleThreeEn, i.SubTitleThreePt, languajeId),
                    SubtitleTwo = Funclanguage(i.SubtitleTwo, i.SubtitleTwoEn, i.SubtitleTwoPt, languajeId),
                    ToastNotificationActive = Funclanguage(i.ToastNotificationActive, i.ToastNotificationActiveEn, i.ToastNotificationActivePt, languajeId),
                    ToastNotificationInactive = Funclanguage(i.ToastNotificationInactive, i.ToastNotificationInactiveEn, i.ToastNotificationInactivePt, languajeId),
                    ToastPasswordError = Funclanguage(i.ToastPasswordError, i.ToastPasswordErrorEn, i.ToastPasswordErrorPt, languajeId),
                    ToastPasswordSuccess = Funclanguage(i.ToastPasswordSuccess, i.ToastPasswordSuccessEn, i.ToastPasswordSuccessPt, languajeId),
                    CuentaEliminada = Funclanguage(i.CuentaEliminada, i.CuentaEliminadaEn, i.CuentaEliminadaPt, languajeId),
                    GuardarAjustes = Funclanguage(i.GuardarAjustes, i.GuardarAjustesEn, i.GuardarAjustesPt, languajeId)




                }).FirstOrDefault();


            return service;



        }
        
        public ConfiguracionPerfilOrganizacion GetConfiguracionPerfilOrganizacion(int languajeId)
        {
            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);


            var service = _context.confPerfilOrg
                .Select(i => new ConfiguracionPerfilOrganizacion
                {
                    Ciudad = Funclanguage(i.Ciudad, i.CiudadEn, i.CiudadPt, languajeId),
                    DatosContacto = Funclanguage(i.DatosContacto, i.DatosContactoEn, i.DatosContactoPt, languajeId),
                    FacebookHolder = Funclanguage(i.FacebookHolder, i.FacebookHolderEn, i.FacebookHolderPt, languajeId),
                    Id = i.Id,
                    ImpactoGenerado = Funclanguage(i.ImpactoGenerado, i.ImpactoGeneradoEn, i.ImpactoGeneradoPt, languajeId),
                    InstagramHolder = Funclanguage(i.InstagramHolder, i.InstagramHolderEn, i.InstagramHolderPt, languajeId),
                    LblAdn = Funclanguage(i.LblAdn, i.LblAdnEn, i.LblAdnPt, languajeId),
                    LblDatosContacto = Funclanguage(i.LblDatosContacto, i.LblDatosContactoEn, i.LblDatosContactoPt, languajeId),
                    LbldatosOrg = Funclanguage(i.LbldatosOrg, i.LbldatosOrgEn, i.LbldatosOrgPt, languajeId),
                    LblEmail = Funclanguage(i.LblEmail, i.LblEmailEn, i.LblEmailPt, languajeId),
                    LblImpacto = Funclanguage(i.LblImpacto, i.LblImpactoEn, i.LblImpactoPt, languajeId),
                    LblnombrePersona = Funclanguage(i.LblnombrePersona, i.LblnombrePersonaEn, i.LblnombrePersonaPt, languajeId),
                    LblQuienesSomos = Funclanguage(i.LblQuienesSomos, i.LblQuienesSomosEn, i.LblQuienesSomosPt, languajeId),
                    QuienesSomos = Funclanguage(i.QuienesSomos, i.QuienesSomosEn, i.QuienesSomosPt, languajeId),
                    TipoOrganizacion = Funclanguage(i.TipoOrganizacion, i.TipoOrganizacionEn, i.TipoOrganizacionPt, languajeId),
                    TwitterHolder = Funclanguage(i.TwitterHolder, i.TwitterHolderEn, i.TwitterHolderPt, languajeId),
                    LinkedinHolder = Funclanguage(i.LinkedinHolder, i.LinkedinHolderEn, i.LinkedinHolderPt, languajeId),
                    LblTelCel = Funclanguage(i.LblTelCel, i.LblTelCelEn, i.LblTelCelPt, languajeId),
                    LblTelFijo = Funclanguage(i.LblTelFijo, i.LblTelFijoEn, i.LblTelFijoPt, languajeId),
                    Pais = Funclanguage(i.Pais, i.PaisEn, i.PaisPt, languajeId),
                    MiPerfil = Funclanguage(i.MiPerfil, i.MiPerfilEn, i.MiPerfilPt, languajeId),
                    NuestroAdn = Funclanguage(i.NuestroAdn, i.NuestroAdnEn, i.NuestroAdnPt, languajeId),
                    LblCancel = Funclanguage(i.LblCancel, i.LblCancelEn, i.LblCancelPt, languajeId),
                    LblEdit = Funclanguage(i.LblEdit, i.LblEditEn, i.LblEditPt, languajeId),
                    LblSave = Funclanguage(i.LblSave, i.LblSaveEn, i.LblSavePt, languajeId)





                }).FirstOrDefault();

            return service;

        }

        public ConfiguracionPublicaVacantesOrganizacion GetConfiguracionPublicarVacante(int languajeId)
        {


            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);


            var service = _context.configpublicavacante
                .Select(i => new ConfiguracionPublicaVacantesOrganizacion
                {
                    BtnAtras = Funclanguage(i.BtnAtras, i.BtnAtrasEn, i.BtnAtrasPt, languajeId),
                    BtnComenzar = Funclanguage(i.BtnComenzar, i.BtnComenzarEn, i.BtnComenzarPt, languajeId),
                    BtnEnviar = Funclanguage(i.BtnEnviar, i.BtnEnviarEn, i.BtnEnviarPt, languajeId),
                    BtnRevisar = Funclanguage(i.BtnRevisar, i.BtnRevisarEn, i.BtnRevisarPt, languajeId),
                    BtnSiguiente = Funclanguage(i.BtnSiguiente, i.BtnSiguienteEn, i.BtnSiguientePt, languajeId),
                    CampoRequerido = Funclanguage(i.CampoRequerido, i.CampoRequeridoEn, i.CampoRequeridoPt, languajeId),
                    Completado = Funclanguage(i.Completado, i.CompletadoEn, i.CompletadoPt, languajeId),
                    Id = i.Id,
                    LblExito = Funclanguage(i.LblExito, i.LblExitoEn, i.LblExitoPt, languajeId),
                    Listo = Funclanguage(i.Listo, i.ListoEn, i.ListoPt, languajeId),
                    Paso1 = Funclanguage(i.Paso1, i.Paso1En, i.Paso1Pt, languajeId),
                    Paso1TipsDescrip = Funclanguage(i.Paso1TipsDescrip, i.Paso1TipsDescripEn, i.Paso1TipsDescripPt, languajeId),
                    Paso1Title = Funclanguage(i.Paso1Title, i.Paso1TitleEn, i.Paso1TitlePt, languajeId),
                    Paso2 = Funclanguage(i.Paso2, i.Paso2En, i.Paso2Pt, languajeId),
                    Paso2NombreHolder = Funclanguage(i.Paso2NombreHolder, i.Paso2NombreHolderEn, i.Paso2NombreHolderPt, languajeId),
                    Paso2Nombre = Funclanguage(i.Paso2Nombre, i.Paso2NombreEn, i.Paso2NombrePt, languajeId),
                    Paso2TipoContrato = Funclanguage(i.Paso2TipoContrato, i.Paso2TipoContratoEn, i.Paso2TipoContratoPt, languajeId),
                    Paso2Tips = Funclanguage(i.Paso2Tips, i.Paso2TipsEn, i.Paso2TipsPt, languajeId),
                    Paso2TipsDesc = Funclanguage(i.Paso2TipsDesc, i.Paso2TipsDescEn, i.Paso2TipsDescPt, languajeId),
                    Paso2Title = Funclanguage(i.Paso2Title, i.Paso2TitleEn, i.Paso2TitlePt, languajeId),
                    Paso3 = Funclanguage(i.Paso3, i.Paso3En, i.Paso3Pt, languajeId),
                    Paso3Descrip = Funclanguage(i.Paso3Descrip, i.Paso3DescripEn, i.Paso3DescripPt, languajeId),
                    Paso3DescripHolder = Funclanguage(i.Paso3DescripHolder, i.Paso3DescripHolderEn, i.Paso3DescripHolderPt, languajeId),
                    Paso3TipsDescripcion = Funclanguage(i.Paso3TipsDescripcion, i.Paso3TipsDescripcionEn, i.Paso3TipsDescripcionPt, languajeId),
                    Paso3Title = Funclanguage(i.Paso3Title, i.Paso3TitleEn, i.Paso3TitlePt, languajeId),
                    Paso4 = Funclanguage(i.Paso4, i.Paso4En, i.Paso4Pt, languajeId),
                    Paso4TipsDescrip = Funclanguage(i.Paso4TipsDescrip, i.Paso4TipsDescripEn, i.Paso4TipsDescripPt, languajeId),
                    Paso4Title = Funclanguage(i.Paso4Title, i.Paso4TitleEn, i.Paso4TitlePt, languajeId),
                    Paso5 = Funclanguage(i.Paso5, i.Paso5En, i.Paso5Pt, languajeId),
                    Paso5DescripHolder = Funclanguage(i.Paso5DescripHolder, i.Paso5DescripHolderEn, i.Paso5DescripHolderPt, languajeId),
                    Paso5TipsDescrip = Funclanguage(i.Paso5TipsDescrip, i.Paso5TipsDescripEn, i.Paso5TipsDescripPt, languajeId),
                    Paso5Title = Funclanguage(i.Paso5Title, i.Paso5TitleEn, i.Paso5TitlePt, languajeId),
                    Paso6 = Funclanguage(i.Paso6, i.Paso6En, i.Paso6Pt, languajeId),
                    Paso6TipsDescrip = Funclanguage(i.Paso6TipsDescrip, i.Paso6TipsDescripEn, i.Paso6TipsDescripPt, languajeId),
                    Paso6Title = Funclanguage(i.Paso6Title, i.Paso6TitleEn, i.Paso6TitlePt, languajeId),
                    PasoAniosExpHolder = Funclanguage(i.PasoAniosExpHolder, i.PasoAniosExpHolderEn, i.PasoAniosExpHolderPt, languajeId),
                    PasoDescrip = Funclanguage(i.PasoDescrip, i.PasoDescripEn, i.PasoDescripPt, languajeId),
                    WelcomeDescripcion = Funclanguage(i.WelcomeDescripcion, i.WelcomeDescripcionEn, i.WelcomeDescripcionPt, languajeId),
                    WelcomeTitle = Funclanguage(i.WelcomeTitle, i.WelcomeTitleEn, i.WelcomeTitlePt, languajeId),
                    Paso1Descripcion = Funclanguage(i.Paso1Descripcion, i.Paso1DescripcionEn, i.Paso1DescripcionPt, languajeId),
                    Paso2AniosExp = Funclanguage(i.Paso2AniosExp, i.Paso2AniosExpEn, i.Paso2AniosExpPt, languajeId),
                    Paso2Area = Funclanguage(i.Paso2Area, i.Paso2AreaEn, i.Paso2AreaPt, languajeId),
                    Paso2Descripcion = Funclanguage(i.Paso2Descripcion, i.Paso2DescripcionEn, i.Paso2DescripcionPt, languajeId),
                    Paso2Jornada = Funclanguage(i.Paso2Jornada, i.Paso2JornadaEn, i.Paso2JornadaPt, languajeId),
                    Paso2Localidad = Funclanguage(i.Paso2Localidad, i.Paso2LocalidadEn, i.Paso2LocalidadPt, languajeId),
                    Paso2Lugar = Funclanguage(i.Paso2Lugar, i.Paso2LugarEn, i.Paso2LugarPt, languajeId),
                    Paso4DescripHolder = Funclanguage(i.Paso4DescripHolder, i.Paso4DescripHolderEn, i.Paso4DescripHolderPt, languajeId),
                    Paso1TtitleValidacion = Funclanguage(i.Paso1TtitleValidacion, i.Paso1TtitleValidacionEn, i.Paso1TtitleValidacionPt, languajeId)























                }).FirstOrDefault();

            return service;


        }

        public ConfiguracionStepByStepOrganizacion GetConfiguracionStepByStepOrganizacion(int languajeId)
        {

            string languaje(string es, string en, string pt, int languajeid)
            {
                string texto = "";

                if (languajeid == 1)
                {
                    texto = es;
                }
                else if (languajeid == 2)
                {
                    texto = en;
                }
                else if (languajeid == 3)
                {
                    texto = pt;
                }

                return texto;
            };

            Func<string, string, string, int, string> Funclanguage = new Func<string, string, string, int, string>(languaje);


            var service = _context.confstepBystepOrg
                .Select(i => new ConfiguracionStepByStepOrganizacion
                {
                    BtnAnterior = Funclanguage(i.BtnAnterior, i.BtnAnteriorEn, i.BtnAnteriorPt, languajeId),
                    BtnGuardar = Funclanguage(i.BtnGuardar, i.BtnGuardarEn, i.BtnGuardarPt, languajeId),
                    BtnSiguiente = Funclanguage(i.BtnSiguiente, i.BtnSiguienteEn, i.BtnSiguientePt, languajeId),
                    BtnWelcome = Funclanguage(i.BtnWelcome, i.BtnWelcomeEn, i.BtnWelcomePt, languajeId),
                    DescripcionWelcome = Funclanguage(i.DescripcionWelcome, i.DescripcionWelcomeEn, i.DescripcionWelcomePt, languajeId),
                    Id = i.Id,
                    LblStep1Como = i.LblStep1Como,
                    LblStep1Description = Funclanguage(i.LblStep1Description, i.LblStep1DescriptionEn, i.LblStep1DescriptionPt, languajeId),
                    LblStep1Localidad = Funclanguage(i.LblStep1Localidad, i.LblStep1LocalidadEn, i.LblStep1LocalidadPt, languajeId),
                    LblStep1Logo = Funclanguage(i.LblStep1Logo, i.LblStep1LogoEn, i.LblStep1LogoPt, languajeId),
                    LblStep1Pais = Funclanguage(i.LblStep1Pais, i.LblStep1PaisEn, i.LblStep1PaisPt, languajeId),
                    LblStep1PhoneCel = Funclanguage(i.LblStep1PhoneCel, i.LblStep1PhoneCelEn, i.LblStep1PhoneCelPt, languajeId),
                    LblStep1PhoneFijo = Funclanguage(i.LblStep1PhoneFijo, i.LblStep1PhoneFijoEn, i.LblStep1PhoneFijoPt, languajeId),
                    LblStep1Title = Funclanguage(i.LblStep1Title, i.LblStep1TitleEn, i.LblStep1TitlePt, languajeId),
                    LblStep1TypeOrg = Funclanguage(i.LblStep1TypeOrg, i.LblStep1TypeOrgEn, i.LblStep1TypeOrgPt, languajeId),
                    LblStep2Description = Funclanguage(i.LblStep2Description, i.LblStep2DescriptionEn, i.LblStep2DescriptionPt, languajeId),
                    LblStep2HolderDescription = Funclanguage(i.LblStep2HolderDescription, i.LblStep2HolderDescriptionEn, i.LblStep2HolderDescriptionPt, languajeId),
                    LblStep2HolderFacebook = Funclanguage(i.LblStep2HolderFacebook, i.LblStep2HolderFacebookEn, i.LblStep2HolderFacebookPt, languajeId),
                    LblStep2HolderInstagram = Funclanguage(i.LblStep2HolderInstagram, i.LblStep2HolderInstagramEn, i.LblStep2HolderInstagramPt, languajeId),
                    LblStep2HolderLinkedin = Funclanguage(i.LblStep2HolderLinkedin, i.LblStep2HolderLinkedinEn, i.LblStep2HolderLinkedinPt, languajeId),
                    LblStep2HolderTwitter = Funclanguage(i.LblStep2HolderTwitter, i.LblStep2HolderTwitterEn, i.LblStep2HolderTwitterPt, languajeId),
                    LblStep2SocialMedia = Funclanguage(i.LblStep2SocialMedia, i.LblStep2SocialMediaEn, i.LblStep2SocialMediaPt, languajeId),
                    LblStep2TextTips = Funclanguage(i.LblStep2TextTips, i.LblStep2TextTipsEn, i.LblStep2TextTipsPt, languajeId),
                    LblStep2Title = Funclanguage(i.LblStep2Title, i.LblStep2TitleEn, i.LblStep2TitlePt, languajeId),
                    LblStep3Description = Funclanguage(i.LblStep3Description, i.LblStep3DescriptionEn, i.LblStep3DescriptionPt, languajeId),
                    LblStep3HolderDescribe = Funclanguage(i.LblStep3HolderDescribe, i.LblStep3HolderDescribeEn, i.LblStep3HolderDescribePt, languajeId),
                    LblStep3TextTips = Funclanguage(i.LblStep3TextTips, i.LblStep3TextTipsEn, i.LblStep3TextTipsPt, languajeId),
                    LblStep3Title = Funclanguage(i.LblStep3Title, i.LblStep3TitleEn, i.LblStep3TitlePt, languajeId),
                    LblStep4Description = Funclanguage(i.LblStep4Description, i.LblStep4DescriptionEn, i.LblStep4DescriptionPt, languajeId),
                    LblStep4HolderDescribe = Funclanguage(i.LblStep4HolderDescribe, i.LblStep4HolderDescribeEn, i.LblStep4HolderDescribePt, languajeId),
                    Lblstep4TextTips = Funclanguage(i.Lblstep4TextTips, i.Lblstep4TextTipsEn, i.Lblstep4TextTipsPt, languajeId),
                    LblStep4Title = Funclanguage(i.LblStep4Title, i.LblStep4TitleEn, i.LblStep4TitlePt, languajeId),
                    LblTextTips = Funclanguage(i.LblTextTips, i.LblTextTipsEn, i.LblTextTipsPt, languajeId),
                    LblTips = Funclanguage(i.LblTips, i.LblTipsEn, i.LblTipsPt, languajeId),
                    Step1 = Funclanguage(i.Step1, i.Step1En, i.Step1Pt, languajeId),
                    Step2 = Funclanguage(i.Step2, i.Step2En, i.Step2Pt, languajeId),
                    Step3 = Funclanguage(i.Step3, i.Step3En, i.Step3Pt, languajeId),
                    Step4 = Funclanguage(i.Step4, i.Step4En, i.Step4Pt, languajeId),
                    TitleWelcom = Funclanguage(i.TitleWelcom, i.TitleWelcomeEn, i.TitleWelcomePt, languajeId),
                    LblCampoRequerido = Funclanguage(i.LblCampoRequerido, i.LblCampoRequeridoEn, i.LblCampoRequeridoPt, languajeId),
                    LblCompletaste = Funclanguage(i.LblCompletaste, i.LblCompletasteEn, i.LblCompletastePt, languajeId),
                    LblListo = Funclanguage(i.LblListo, i.LblListoEn, i.TitleWelcomePt, languajeId),
                    Lblsubir = Funclanguage(i.Lblsubir, i.LblsubirEn, i.LblsubirPt, languajeId),
                    LblVerservicios = Funclanguage(i.LblVerservicios, i.LblVerserviciosEn, i.LblVerserviciosPt, languajeId)
                                    




                }).FirstOrDefault();

            return service;



        }

        public List<dllCompany> GetDDLCompany()
        {
            

            var service = _context.company
                .Select(i => new dllCompany
                {
                     Id = i.Id,
                     name = i.Name


                }).ToList();

            //service.Add(new dllCompany { Id = 0, name = "Todas las compañias" });

           

            return service;
        }



        //back office anterior
        //public List<biz.matteria.Models.Company.enlistaCompany> GetEnlistaCompanys(string fechaInicial, string FechaFinal, int sector,int pais, string ciudad)
        //{
        //    var service = _context.company
        //        .Where(b => b.Timestamp.Date >= Convert.ToDateTime(fechaInicial).Date && b.Timestamp.Date <= Convert.ToDateTime(FechaFinal).Date)
        //        .Where(k => sector == 0 || k.CompanyTypeId == sector)
        //        .Where(k => pais == 0 || k.CountryId == pais)
        //        .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
        //        .Select(i => new enlistaCompany
        //        {
        //            name = i.Name,
        //            representante = i.User.FirstName + i.User.LastName,
        //            email = i.User.Email,
        //            pais = i.Country.Name,
        //            city = i.City,
        //            sector = i.CompanyType.Name,
        //            openings = i.OpeningsOpenings.Count(),
        //            paquetes = (from a in i.Creditos
        //                        join cm in _context.compraPaquete on a.IdCompra equals cm.Id
        //                        join pa in _context.FrontContentVacantesPaquetes on cm.IdProducto equals pa.Id
        //                        where a.IdCompra != null
        //                        group pa by pa.Id into grop
        //                        select grop).Count(),
        //            prospectos = (from op in i.OpeningsOpenings
        //                          join opc in _context.OpeningsOpeningcandidates on op.Id equals opc.OpeningId
        //                          where op.CompanyId == i.Id
        //                          select opc.CandidateId).Count(),
        //            contact_cellphone_number = i.ContactCellphoneNumber,
        //            id = i.User.Id,
        //            candidateId = i.Id,
        //            nameCountry = i.Country.Name,
        //            logo = i.Logo,
        //            timestamp = i.Timestamp



        //        }).ToList();

        //    return service;
        //}


        public List<biz.matteria.Models.Company.enlistaCompany> GetEnlistaCompanys(string nameCompany,int pais,int tipoOrganizacion,int? aprobadas,int? status)
        {
            var service = _context.company
                .Where(k => string.IsNullOrEmpty(nameCompany) || k.Name == nameCompany)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(k => tipoOrganizacion == 0 || k.CompanyTypeId == tipoOrganizacion)
                .Where(k => aprobadas == null || k.Approve == Convert.ToBoolean(aprobadas))
                .Where(k => status == null || k.Approve == Convert.ToBoolean(status))
                .Select(i => new enlistaCompany
                {
                    name = i.Name,
                    representante = i.User.FirstName + i.User.LastName,
                    email = i.User.Email,
                    pais = i.Country.Name,
                    city = i.City,
                    sector = i.CompanyType.Name,
                    openings = i.OpeningsOpenings.Count(),
                    paquetes = (from a in i.Creditos
                                join cm in _context.compraPaquete on a.IdCompra equals cm.Id
                                join pa in _context.FrontContentVacantesPaquetes on cm.IdProducto equals pa.Id
                                where a.IdCompra != null
                                group pa by pa.Id into grop
                                select grop).Count(),
                    prospectos = (from op in i.OpeningsOpenings
                                  join opc in _context.OpeningsOpeningcandidates on op.Id equals opc.OpeningId
                                  where op.CompanyId == i.Id
                                  select opc.CandidateId).Count(),
                    contact_cellphone_number = i.ContactCellphoneNumber,
                    id = i.User.Id,
                    candidateId = i.Id,
                    nameCountry = i.Country.Name,
                    logo = i.Logo,
                    timestamp = i.Timestamp,
                    asignaciones = i.UserConsultor,
                    statusAsignadas = i.UserConsultor == null ? "Sin asignar":"Asignada"
                    



                }).ToList();

            return service;
        }
    }
}
