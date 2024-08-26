using biz.matteria.Entities;
using biz.matteria.Models.candidate;
using biz.matteria.Models.CV;
using biz.matteria.Repository.CandidatesCandidate;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesCandidate
{
    public class CandidatesCandidateRepository: GenericRepository<biz.matteria.Entities.CandidatesCandidate>, ICandidatesCandidate
    {
        public CandidatesCandidateRepository(DbmatteriaContext context) : base(context) { }

        public candidatesCandidateService GetCandidatesCV(int userid, int candidateid)
        {

            //var listaareas = _context.CandidatesCandidateExpAreas
            //    .Include(x => x.Area)
            //    .Where(y => y.CandidateId == candidateid)
            //    .Select(j => new candidatesArea
            //    {
            //        candidateid = j.CandidateId,
            //        areaid = j.Area.Id,
            //        name = j.Area.Name

            //    }).ToList();


            var listaInterests = _context.CandidatesCandidateInterests
                .Include(x => x.Interest)
                .Where(y => y.CandidateId == candidateid)
                .Select(j => new candidatesInterestsService
                {
                    candidate_id = j.CandidateId,
                    interest_id = j.Interest.Id,
                    name = j.Interest.Name

                }).ToList();

            var service = _context.CandidatesCandidates
                .Include(x => x.CandidatesCandidateInterests)
                .Include(y => y.CandidatesWorkandsocialexps)
                .Include(z => z.CandidatesEducations)
                .Include(t => t.CandidatesLanguages)
                .Include(v => v.CandidatesCandidateExpSectors)
                .Include(w => w.CandidatesCandidateExpAreas)
                .Include(w => w.User)
                .Include(g => g.Country)
                .Where(c => c.Id == candidateid)
                .Select(i => new candidatesCandidateService
                {
                    Id = i.Id,
                    Birthday = i.Birthday,
                    CellphoneNumber = i.CellphoneNumber,
                    City = i.City,
                    CountryId = i.CountryId,
                    country = i.Country.Name,
                    email = i.User.Email,
                    Genre = i.Genre,
                    Hobbies = i.Hobbies,
                    listEducation = i.CandidatesEducations,
                    listlanguage = i.CandidatesLanguages,
                    listworkandsocialexp = i.CandidatesWorkandsocialexps,
                    name = i.User.FirstName,
                    lastname = i.User.LastName,
                    position = i.Position,
                    Positivechange = i.Positivechange,
                    salary_max = i.SalaryMax,
                    Interest = listaInterests,
                    avatar = i.Avatar,
                    currencyId = i.CurrencyId,
                    listExpSector = i.CandidatesCandidateExpSectors,
                    listAreaExp = i.CandidatesCandidateExpAreas,
                    currency = i.Currency.Name
                    
                    
                    
                   


                }).SingleOrDefault();

            return service;
        }

        public enlistaPostulantesTotales GetCandidatos(string fechaInicial, string FechaFinal, string profesion, int edad, int pais, string ciudad)
        {
            enlistaPostulantesTotales modelResponse = new enlistaPostulantesTotales();
            int promedio = 0;
            int suma = 0;
            int sumaPostulaciones = 0;
            int sumaSesiones = 0;

            var servicetmp = _context.CandidatesCandidates
                .Include(y => y.User)
                .Where(z => z.UserId != null)
                .Where(b => b.Timestamp.Date >= Convert.ToDateTime(fechaInicial).Date && b.Timestamp.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => edad == 0 || DateTime.Now.Year - k.Birthday.Year >= edad && (DateTime.Now.Year - k.Birthday.Year) + 6 <= edad)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
                .Select(x => new enlistaCandidate
                {
                    first_name = x.User.FirstName,
                    last_name = x.User.LastName,
                    email = x.User.Email,
                    country = x.Country.Name,
                    city = x.City,
                    profesion = x.CandidatesEducations.Where(f => f.CandidateId == x.Id).Select(f => f.NameProfession).FirstOrDefault(),
                    edad = DateTime.Now.Year - DateTime.Parse(x.Birthday.ToString()).Year,
                    cellphone_number = x.CellphoneNumber,
                    estatus = x.Status == true ? "Activo" : "Inactivo",
                    postulacionOfertas = x.OpeningsOpeningcandidates.Count,
                    genre = x.Genre,
                    id = x.User.Id,
                    position = x.Position,
                    candidateId = x.Id,
                    postulaciones = x.OpeningsOpeningcandidates,
                    sesiones = x.User.LoginUsers

                }).ToList();

            foreach(var item in servicetmp)
            {
                suma += item.edad;
                sumaPostulaciones += item.postulacionOfertas;
                sumaSesiones += item.sesiones.Count();
            }

            try
            {
                promedio = suma / servicetmp.Count();

            }
            catch (Exception ex)
            {
                promedio = 0;

            }
            

            modelResponse.promedioEdad = promedio;
            modelResponse.totalUsuarios = servicetmp.Count();
            modelResponse.usuariosActivos = servicetmp.Where(q => q.estatus == "Activo").ToList().Count();
            modelResponse.totalPostulaciones = sumaPostulaciones;
            modelResponse.inicioSesion = sumaSesiones;

            return modelResponse;
        }

        public ConfiguracionBusquedaVacantesPostulante GetConfiguracionBusqyedaVcantes(int languajeId)
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

            var service = _context.configBusquedavacantes
                .Select(i => new ConfiguracionBusquedaVacantesPostulante
                {
                    Id = i.Id,
                    LblAreaTrabajo = Funclanguage(i.LblAreaTrabajo, i.LblAreaTrabajoEn, i.LblAreaTrabajoPt, languajeId),
                    LblCopiar = Funclanguage(i.LblCopiar, i.LblCopiarEn, i.LblCopiarPt, languajeId),
                    LblDescripcionResponsabilidade = Funclanguage(i.LblDescripcionResponsabilidade, i.LblDescripcionResponsabilidadeEn, i.LblDescripcionResponsabilidadePt, languajeId),
                    LblDetallesVacante = Funclanguage(i.LblDetallesVacante, i.LblDetallesVacanteEn, i.LblDetallesVacantePt, languajeId),
                    LblFacebook = Funclanguage(i.LblFacebook, i.LblFacebookEn, i.LblFacebookPt, languajeId),
                    LblLinkedin = Funclanguage(i.LblLinkedin, i.LblLinkedinEn, i.LblLinkedinPt, languajeId),
                    LblNivelExperiencia = Funclanguage(i.LblNivelExperiencia, i.LblNivelExperienciaEn, i.LblNivelExperienciaPt, languajeId),
                    LblOrganizacion = Funclanguage(i.LblOrganizacion, i.LblOrganizacionEn, i.LblOrganizacionPt, languajeId),
                    LblPostular = Funclanguage(i.LblPostular, i.LblPostularEn, i.LblPostularPt, languajeId),
                    LblProfesiones = Funclanguage(i.LblProfesiones, i.LblProfesionesEn, i.LblProfesionesPt, languajeId),
                    LblProposito = Funclanguage(i.LblProposito, i.LblPropositoEn, i.LblPropositoPt, languajeId),
                    LblRequisito = Funclanguage(i.LblRequisito, i.LblRequisitoEn, i.LblRequisitoPt, languajeId),
                    LblResponsabilidad = Funclanguage(i.LblResponsabilidad, i.LblResponsabilidadEn, i.LblResponsabilidadPt, languajeId),
                    LblSumarse = Funclanguage(i.LblSumarse, i.LblSumarseEn, i.LblSumarsePt, languajeId),
                    LblTipoContrato = Funclanguage(i.LblTipoContrato, i.LblTipoContratoEn, i.LblTipoContratoPt, languajeId),
                    LblTwitter = Funclanguage(i.LblTwitter, i.LblTwitterEn, i.LblTwitterPt, languajeId),
                    ModalDesde = Funclanguage(i.ModalDesde, i.ModalDesdeEn, i.ModalDesdePt, languajeId),
                    ModalHasta = Funclanguage(i.ModalHasta, i.ModalHastaEn, i.ModalHastaPt, languajeId),
                    ModalLbEnviar = Funclanguage(i.ModalLbEnviar, i.ModalLbEnviarEn, i.ModalLbEnviarPt, languajeId),
                    ModalLbVolver = Funclanguage(i.ModalLbVolver, i.ModalLbVolverEn, i.ModalLbVolverPt, languajeId),
                    ModalMoneda = Funclanguage(i.ModalMoneda, i.ModalMonedaEn, i.ModalMonedaPt, languajeId),
                    ModalSalarial = Funclanguage(i.ModalSalarial, i.ModalSalarialEn, i.ModalSalarialPt, languajeId),
                    PostulacionDes = Funclanguage(i.PostulacionDes, i.PostulacionDesEn, i.PostulacionDesPt, languajeId),
                    PostulacionError = Funclanguage(i.PostulacionError, i.PostulacionErrorEn, i.PostulacionErrorPt, languajeId),
                    PostulacionExito = Funclanguage(i.PostulacionExito, i.PostulacionExitoEn, i.PostulacionExitoPt, languajeId),
                    SmallRequired = Funclanguage(i.SmallRequired, i.SmallRequiredEn, i.SmallRequiredPt, languajeId),
                    Toast = Funclanguage(i.Toast, i.ToastEn, i.ToastPt, languajeId),
                    PostulacionDesError = Funclanguage(i.PostulacionDesError, i.PostulacionDesErrorEn, i.PostulacionDesErrorPt, languajeId),
                    LblFechaPostulado = Funclanguage(i.LblFechaPostulado, i.LblFechaPostuladoEn, i.LblFechaPostuladoPt, languajeId),
                    LblProceso = Funclanguage(i.LblProceso, i.LblProcesoEn, i.LblProcesoPt, languajeId),
                    MenuConfiguracion = Funclanguage(i.MenuConfiguracion, i.MenuConfiguracionEn, i.MenuConfiguracionPt, languajeId),
                    MenuMisPostulaciones = Funclanguage(i.MenuMisPostulaciones, i.MenuMisPostulacionesEn, i.MenuMisPostulacionesPt, languajeId),
                    MenuPerfil = Funclanguage(i.MenuPerfil, i.MenuPerfilEn, i.MenuPerfilPt, languajeId),
                    UrlConfiguracion = i.UrlConfiguracion,
                    UrlMiPerfil = i.UrlMiPerfil






                }).FirstOrDefault();



            return service;


        }

        public ConfiguracionCrearCuentaPostulante GetConfiguracionCrearCuentaPostulante(int languajeId)
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


            var service = _context.crearCtaPostulante
                .Select(i => new ConfiguracionCrearCuentaPostulante
                {
                    ApellidoHolder = Funclanguage(i.ApellidoHolder, i.ApellidoHolderEn, i.ApellidoHolderPt, languajeId),
                    BtnCuenta = Funclanguage(i.BtnCuenta, i.BtnCuentaEn, i.BtnCuentaPt, languajeId),
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeId),
                    EmailNoValido = Funclanguage(i.EmailNoValido, i.EmailNovalidoEn, i.EmailNovalidoPt, languajeId),
                    Id = i.Id,
                    LblApellido = Funclanguage(i.LblApellido, i.LblApellidoEn, i.LblApellidoPt, languajeId),
                    LblContrasena = Funclanguage(i.LblContrasena, i.LblContrasenaEn, i.LblContrasenaPt, languajeId),
                    LblEmail = Funclanguage(i.LblEmail, i.LblEmailEn, i.LblEmailPt, languajeId),
                    LblFechaNacimiento = Funclanguage(i.LblFechaNacimiento, i.LblFechaNacimientoEn, i.LblFechaNacimientoPt, languajeId),
                    LblGenero = Funclanguage(i.LblGenero, i.LblGeneroEn, i.LblGeneroPt, languajeId),
                    LblNombre = Funclanguage(i.LblNombre, i.LblNombreEn, i.LblNombrePt, languajeId),
                    LblRcontrasena = Funclanguage(i.LblRcontrasena, i.LblRcontrasenaEn, i.LblRcontrasenaPt, languajeId),
                    LblRequerido = Funclanguage(i.LblRequerido, i.LblRequeridoEn, i.LblRequeridoPt, languajeId),
                    LblTerminos = Funclanguage(i.LblTerminos, i.LblTerminosEn, i.LblTerminosPt, languajeId),
                    NombreHolder = Funclanguage(i.NombreHolder, i.NombreHolderEn, i.NombreHolderPt, languajeId),
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeId),
                    Btn = Funclanguage(i.Btn, i.BtnEn, i.BtnPt, languajeId),
                    BtnResend = Funclanguage(i.BtnResend, i.BtnResendEn, i.BtnResendPt, languajeId),
                    LbCuenta = Funclanguage(i.LbCuenta, i.LbCuentaEn, i.LbCuentaPt, languajeId),
                    LbListo = Funclanguage(i.LbListo, i.LbListoEn, i.LbListoPt, languajeId),
                    LbMail = Funclanguage(i.LbMail, i.LbMailEn, i.LbMailPt, languajeId),
                    PasswordValid = Funclanguage(i.PasswordValid, i.PasswordValidEn, i.PasswordValidPt, languajeId),
                    RequiereTerminos = Funclanguage(i.RequiereTerminos, i.RequiereTerminosEn, i.RequiereTerminosPt, languajeId)
















                }).FirstOrDefault();


            return service;


        }

        public ConfiguracionMiPerfilPostulante GetConfiguracionPerfilPostulante(int languajeId)
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

            var service = _context.configperfilpost
                .Select(i => new ConfiguracionMiPerfilPostulante
                {

                    Id = i.Id,
                    HobbiesDescipcion = Funclanguage(i.HobbiesDescipcion, i.HobbiesDescipcionEn, i.HobbiesDescipcionPt, languajeId),
                    HobbiesDescipcionHolder = Funclanguage(i.HobbiesDescipcionHolder, i.HobbiesDescipcionHolderEn, i.HobbiesDescipcionHolderPt, languajeId),
                    LblApellido = Funclanguage(i.LblApellido, i.LblApellidoEn, i.LblApellidoPt, languajeId),
                    LblCancelar = Funclanguage(i.LblCancelar, i.LblCancelarEn, i.LblCancelarPt, languajeId),
                    LblCiudadResidencia = Funclanguage(i.LblCiudadResidencia, i.LblCiudadResidenciaEn, i.LblCiudadResidenciaPt, languajeId),
                    LblDatosContacto = Funclanguage(i.LblDatosContacto, i.LblDatosContactoEn, i.LblDatosContactoPt, languajeId),
                    LblDatosPersonales = Funclanguage(i.LblDatosPersonales, i.LblDatosPersonalesEn, i.LblDatosPersonalesPt, languajeId),
                    LblDescripcionOtrosDatos = Funclanguage(i.LblDescripcionOtrosDatos, i.LblDescripcionOtrosDatosEn, i.LblDescripcionOtrosDatosPt, languajeId),
                    LblEdicacion = Funclanguage(i.LblEdicacion, i.LblEdicacionEn, i.LblEdicacionPt, languajeId),
                    LblEditar = Funclanguage(i.LblEditar, i.LblEditarEn, i.LblEditarPt, languajeId),
                    LblEmail = Funclanguage(i.LblEmail, i.LblEmailEn, i.LblEmailPt, languajeId),
                    LblExpecQueCargo = Funclanguage(i.LblExpecQueCargo, i.LblExpecQueCargoEn, i.LblExpecQueCargoPt, languajeId),
                    LblExpectativas = Funclanguage(i.LblExpectativas, i.LblExpectativasEn, i.LblExpectativasPt, languajeId),
                    LblExpecTipo = Funclanguage(i.LblExpecTipo, i.LblExpecTipoEn, i.LblExpecTipoPt, languajeId),
                    LblExperiencias = Funclanguage(i.LblExperiencias, i.LblExperienciasEn, i.LblExperienciasPt, languajeId),
                    LblFechaNac = Funclanguage(i.LblFechaNac, i.LblFechaNacEn, i.LblFechaNacPt, languajeId),
                    LblGenero = Funclanguage(i.LblGenero, i.LblGeneroEn, i.LblGeneroPt, languajeId),
                    LblGuardar = Funclanguage(i.LblGuardar, i.LblGuardarEn, i.LblGuardarPt, languajeId),
                    LblHobbies = Funclanguage(i.LblHobbies, i.LblHobbiesEn, i.LblHobbiesPt, languajeId),
                    LblHolderTelefono = Funclanguage(i.LblHolderTelefono, i.LblHolderTelefonoEn, i.LblHolderTelefonoPt, languajeId),
                    LblIdiomas = Funclanguage(i.LblIdiomas, i.LblIdiomasEn, i.LblIdiomasPt, languajeId),
                    LblMiPerfil = Funclanguage(i.LblMiPerfil, i.LblMiPerfilEn, i.LblMiPerfilPt, languajeId),
                    LblModalExperienciaDesc = Funclanguage(i.LblModalExperienciaDesc, i.LblModalExperienciaDescEn, i.LblModalExperienciaDescPt, languajeId),
                    LblModalExperienciaTitle = Funclanguage(i.LblModalExperienciaTitle, i.LblModalExperienciaTitleEn, i.LblModalExperienciaTitlePt, languajeId),
                    LblModalExpNombreOrg = Funclanguage(i.LblModalExpNombreOrg, i.LblModalExpNombreOrgEn, i.LblModalExpNombreOrgPt, languajeId),
                    LblNombre = Funclanguage(i.LblNombre, i.LblNombreEn, i.LblNombrePt, languajeId),
                    LblOtrasDatos = Funclanguage(i.LblOtrasDatos, i.LblOtrasDatosEn, i.LblOtrasDatosPt, languajeId),
                    LblPaisResidencia = Funclanguage(i.LblPaisResidencia, i.LblPaisResidenciaEn, i.LblPaisResidenciaPt, languajeId),
                    LblTelefono = Funclanguage(i.LblTelefono, i.LblTelefonoEn, i.LblTelefonoPt, languajeId),
                    LblVistaPrevia = Funclanguage(i.LblVistaPrevia, i.LblVistaPreviaEn, i.LblVistaPreviaPt, languajeId),
                    MisMotivaciones = Funclanguage(i.MisMotivaciones, i.MisMotivacionesEn, i.MisMotivacionesPt, languajeId),
                    ModaEduCentroHolder = Funclanguage(i.ModaEduCentroHolder, i.ModaEduCentroHolderEn, i.ModaEduCentroHolderPt, languajeId),
                    ModaEduNivel = Funclanguage(i.ModaEduNivel, i.ModaEduNivelEn, i.ModaEduNivelPt, languajeId),
                    ModaIdiomaTitle = Funclanguage(i.ModaIdiomaTitle, i.ModaIdiomaTitleEn, i.ModaIdiomaTitlePt, languajeId),
                    ModalEduCarrera = Funclanguage(i.ModalEduCarrera, i.ModalEduCarreraEn, i.ModalEduCarreraPt, languajeId),
                    ModalEduCentro = Funclanguage(i.ModalEduCentro, i.ModalEduCentroEn, i.ModalEduCentroPt, languajeId),
                    ModalEduDesc = Funclanguage(i.ModalEduDesc, i.ModalEduDescEn, i.ModalEduDescPt, languajeId),
                    ModalEduTitle = Funclanguage(i.ModalEduTitle, i.ModalEduTitleEn, i.ModalEduTitlePt, languajeId),
                    ModalExpAlPresente = Funclanguage(i.ModalExpAlPresente, i.ModalExpAlPresenteEn, i.ModalExpAlPresentePt, languajeId),
                    ModalExpCargo = Funclanguage(i.ModalExpCargo, i.ModalExpCargoEn, i.ModalExpCargoPt, languajeId),
                    ModalExpDescripcion = Funclanguage(i.ModalExpDescripcion, i.ModalExpDescripcionEn, i.ModalExpDescripcionPt, languajeId),
                    ModalExpFechaFin = Funclanguage(i.ModalExpFechaFin, i.ModalExpFechaFinEn, i.ModalExpFechaFinPt, languajeId),
                    ModalExpFechaInicio = Funclanguage(i.ModalExpFechaInicio, i.ModalExpFechaInicioEn, i.ModalExpFechaInicioPt, languajeId),
                    ModalExpHolderCargo = Funclanguage(i.ModalExpHolderCargo, i.ModalExpHolderCargoEn, i.ModalExpHolderCargoPt, languajeId),
                    ModalExpHolderDescripcion = Funclanguage(i.ModalExpHolderDescripcion, i.ModalExpHolderDescripcionEn, i.ModalExpHolderDescripcionPt, languajeId),
                    ModalExpHolderNombreOrg = Funclanguage(i.ModalExpHolderNombreOrg, i.ModalExpHolderNombreOrgEn, i.ModalExpHolderNombreOrgPt, languajeId),
                    ModalExpLocalidad = Funclanguage(i.ModalExpLocalidad, i.ModalExpLocalidadEn, i.ModalExpLocalidadPt, languajeId),
                    ModalExpNo = Funclanguage(i.ModalExpNo, i.ModalExpNoEn, i.ModalExpNoPt, languajeId),
                    ModalExpPais = Funclanguage(i.ModalExpPais, i.ModalExpPaisEn, i.ModalExpPaisPt, languajeId),
                    ModalExpSi = Funclanguage(i.ModalExpSi, i.ModalExpSiEn, i.ModalExpSiPt, languajeId),
                    ModalExpVoluntario = Funclanguage(i.ModalExpVoluntario, i.ModalExpVoluntarioEn, i.ModalExpVoluntarioPt, languajeId),
                    ModalIdioma = Funclanguage(i.ModalIdioma, i.ModalIdiomaEn, i.ModalIdiomaPt, languajeId),
                    OtrosDatosHolder = Funclanguage(i.OtrosDatosHolder, i.OtrosDatosHolderEn, i.OtrosDatosHolderPt, languajeId),
                    SectorExperiencia = Funclanguage(i.SectorExperiencia, i.SectorExperienciaEn, i.SectorExperienciaPt, languajeId)














                }).FirstOrDefault();

            return service;


        }

        public ConfiguracionPostulante GetConfiguracionPostulante(int languajeId)
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


            var service = _context.configPostulante
                .Select(i => new ConfiguracionPostulante
                {
                    ActualPassword = Funclanguage(i.ActualPassword, i.ActualPasswordEn, i.ActualPasswordPt, languajeId),
                    BtnChangePassword = Funclanguage(i.BtnChangePassword, i.BtnChangePasswordEn, i.BtnChangePasswordPt, languajeId),
                    BtnDelete = Funclanguage(i.BtnDelete, i.BtnDeleteEn, i.BtnDeletePt, languajeId),
                    ConfirmPassword = Funclanguage(i.ConfirmPassword, i.ConfirmPasswordEn, i.ConfirmPasswordPt, languajeId),
                    Id = i.Id,
                    MenuConfiguracion = Funclanguage(i.MenuConfiguracion, i.MenuConfiguracionEn, i.MenuConfiguracionPt, languajeId),
                    MenuMiPerfil = Funclanguage(i.MenuMiPerfil, i.MenuMiPerfilEn, i.MenuMiPerfilPt, languajeId),
                    MenuMisPostulaciones = Funclanguage(i.MenuMisPostulaciones, i.MenuMisPostulacionesEn, i.MenuMisPostulacionesPt, languajeId),
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
                    UrlConfiguracion = i.UrlConfiguracion,
                    UrlMisPostulaciones = i.UrlMisPostulaciones,
                    UrlPerfil = i.UrlPerfil
                     






                }).FirstOrDefault();


            return service;
        }

        public List<enlistaCandidate> GetEnlistaCandidates(string fechaInicial, string FechaFinal,string profesion,int edad,int pais,string ciudad)
        {

            

            

            var service = _context.CandidatesCandidates
                .Include(y => y.User)
                .Where(z => z.UserId !=null)
                .Where(b => b.Timestamp.Date >= Convert.ToDateTime(fechaInicial).Date && b.Timestamp.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(k => edad == 0 || DateTime.Now.Year - k.Birthday.Year  >= edad && DateTime.Now.Year - k.Birthday.Year <= edad + 6)
                .Where(k => pais == 0 || k.CountryId == pais)
                .Where(j => string.IsNullOrEmpty(ciudad) || j.City == ciudad)
                .Select(x => new enlistaCandidate
                {
                    first_name = x.User.FirstName,
                    last_name = x.User.LastName,
                    email = x.User.Email,
                    country = x.Country.Name,
                    city = x.City,
                    profesion = x.CandidatesEducations.Where(f => f.CandidateId == x.Id).Select(f => f.NameProfession).FirstOrDefault(),
                    edad = DateTime.Now.Year - DateTime.Parse(x.Birthday.ToString()).Year,
                    cellphone_number = x.CellphoneNumber,
                    estatus = x.Status == true ? "Activo" : "Inactivo",
                    postulacionOfertas = x.OpeningsOpeningcandidates.Count,
                    genre = x.Genre,
                    id = x.User.Id,
                    position = x.Position,
                    candidateId = x.Id,
                    avatar = x.Avatar,
                    Timestamp = x.Timestamp,
                    listaProfesiones = x.CandidatesEducations.Where(f => f.CandidateId == x.Id).Select(f => f.NameProfession).ToList(),
                    countVisitas = x.VisitasVacantes.Count()


                }).ToList();

            
            foreach(var item in service)
            {
                if(item.listaProfesiones.Count > 0)
                {
                    foreach(var j in item.listaProfesiones)
                    {
                        item.profesion = item.profesion +  j + ",";
                    }

                    item.profesion = item.profesion.TrimEnd(',');

                }

                
            }
            

            return service;
        }

        public enlistaCandidate GetPostulanteById(int id)
        {
            var service = _context.CandidatesCandidates
                .Include(y => y.User)
                .Where(z => z.Id == id )
                .Select(x => new enlistaCandidate
                {

                    cellphone_number = x.CellphoneNumber,
                    city = x.City,
                    email = x.User.Email,
                    first_name = x.User.FirstName,
                    genre = x.Genre,
                    id = x.User.Id,
                    last_name = x.User.LastName,
                    position = x.Position,
                    candidateId = x.Id




                }).FirstOrDefault();

            return service;
        }
    }
}
