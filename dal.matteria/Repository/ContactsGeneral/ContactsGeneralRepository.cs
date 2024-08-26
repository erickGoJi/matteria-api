using biz.matteria.Entities;
using biz.matteria.Repository.ContactsGeneral;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ContactsGeneral
{
    public class ContactsGeneralRepository: GenericRepository<biz.matteria.Entities.ContactsGeneral>, IContactsGeneral
    {
        public ContactsGeneralRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.ContactsGeneral> GetAllContacsGeneral()
        {
            var service = _context.contactsGeneral
                .Select(i => new biz.matteria.Entities.ContactsGeneral
                {
                    Comments = i.Comments,
                    Email = i.Email,
                    Id = i.Id,
                    Name = i.Name,
                    NameCompany = i.NameCompany,
                    Phone = i.Phone,
                    RegistrationDate = i.RegistrationDate,
                    Type = i.Type,
                    Respuesta = i.Respuesta



                }).ToList();

            return service;
        }

        public ContactoGeneralConfiguracion GetContactoGeneralConfiguracion(int languageId)
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




            var service = _context.contactoGeneralConfiguracion
                .Select(i => new ContactoGeneralConfiguracion
                {
                    Id = i.Id,
                    Boton = Funclanguage(i.Boton, i.BotonEn, i.BotonPt, languageId),
                    BotonEnviar = Funclanguage(i.BotonEnviar, i.BotonEnviarEn, i.BotonEnviarPt, languageId),
                    Comentarios = Funclanguage(i.Comentarios, i.ComentariosEn, i.ComentariosPt, languageId),
                    ComentariosHolder = Funclanguage(i.ComentariosHolder, i.ComentariosHolderEn, i.ComentariosHolderPt, languageId),
                    Email = Funclanguage(i.Email, i.EmailEn, i.EmailPt, languageId),
                    EmailHolder = Funclanguage(i.EmailHolder, i.EmailHolderEn, i.EmailHolderPt, languageId),
                    LabelTelefono = Funclanguage(i.LabelTelefono, i.LabelTelefonoEn, i.LabelTelefonoPt, languageId),
                    Mensaje = Funclanguage(i.Mensaje, i.MensajeEn, i.MensajePt, languageId),
                    Name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                    OrganizacionPertenece = Funclanguage(i.OrganizacionPertenece, i.OrganizacionPerteneceEn, i.OrganizacionPertenecePt, languageId),
                    OrganizacionPerteneceHolder = Funclanguage(i.OrganizacionPerteneceHolder, i.OrganizacionPerteneceHoderEn, i.OrganizacionPerteneceHolderPt, languageId),
                    SoyOrganizacion = Funclanguage(i.SoyOrganizacion, i.SoyOrganizacionEn, i.SoyOrganizacionPt, languageId),
                    SoyPostulante = Funclanguage(i.SoyPostulante, i.SoyPostulanteEn, i.SoyPostulantePt, languageId),
                    Title = Funclanguage(i.Title, i.TitleEn, i.SoyPostulantePt, languageId),
                    SmallRequired = Funclanguage(i.SmallRequired, i.SmallRequiredEn, i.SmallRequiredPt, languageId)


                }).FirstOrDefault();

            return service;
        }
    }
}
