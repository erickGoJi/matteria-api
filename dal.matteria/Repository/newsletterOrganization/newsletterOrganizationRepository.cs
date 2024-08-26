using biz.matteria.Entities;
using biz.matteria.Models.newsletterOrganization;
using biz.matteria.Repository.newsletterOrganization;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.newsletterOrganization
{
    public class newsletterOrganizationRepository : GenericRepository<biz.matteria.Entities.NewsletterOrganization>, InewsletterOrganization
    {
        public newsletterOrganizationRepository(DbmatteriaContext context) : base(context) { }

        public newsletterOrganizationService AddNewletterOrganization(NewsletterOrganization request)
        {
            throw new NotImplementedException();
        }

        public NewsletterOrganizationFrontConfiguration getFrontConfigurtionNewsLetterOrganizacion(int languajeid)
        {

            string languaje(string es, string en, string pt, int lenguajeId)
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





            var service = _context.letterconfigurationOrg
                .Select(i => new NewsletterOrganizationFrontConfiguration
                {

                    Descripcion = Funclanguage(i.Descripcion, i.Descripcion, i.DescripcionPt, languajeid),
                    Email = Funclanguage(i.Email, i.EmailEn, i.EmailPt, languajeid),
                    Enviar = Funclanguage(i.Enviar, i.EnviarEn, i.EnviarPt, languajeid),
                    Exito = Funclanguage(i.Exito, i.ExitoEn, i.ExitoPt, languajeid),
                    Id = i.Id,
                    Nombre = Funclanguage(i.Nombre, i.NombreEn, i.NombrePt, languajeid),
                    Organizacion = Funclanguage(i.Organizacion, i.OrganizacionEn, i.OrganizacionPt, languajeid),
                    Suscribete = Funclanguage(i.Suscribete, i.SuscribeteEn, i.SuscribetePt, languajeid),
                    ValidaEmail = Funclanguage(i.ValidaEmail, i.ValidaEmailEn, i.ValidaEmailPt, languajeid),
                    ValidaEmailFormato = Funclanguage(i.ValidaEmailFormato, i.ValidaEmailFormatoEn, i.ValidaEmailFormatoPt, languajeid),
                    ValidaNombre = Funclanguage(i.ValidaNombre, i.ValidaNombreEn, i.ValidaNombrePt, languajeid),
                    ValidaOrganizacion = Funclanguage(i.ValidaOrganizacion, i.ValidaOrganizacionEn, i.ValidaOrganizacionPt, languajeid)


                }).FirstOrDefault();

            return service;
        }
    }
}
