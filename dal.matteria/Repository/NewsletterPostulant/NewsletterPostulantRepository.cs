using biz.matteria.Entities;
using biz.matteria.Models.NewsletterPostulant;
using biz.matteria.Repository.NewsletterPostulant;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.NewsletterPostulant
{
    public class NewsletterPostulantRepository : GenericRepository<biz.matteria.Entities.NewsletterPostulant>, INewsletterPostulant
    {
        public NewsletterPostulantRepository(DbmatteriaContext context) : base(context) { }
        public NewsletterPostulantService addNewsletterPostulant(biz.matteria.Entities.NewsletterPostulant request)
        {
            throw new NotImplementedException();
        }

        public NewsletterPostulantFrontConfiguration GetNewsletterPostulantConfiguration(int languajeid)
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





            var service = _context.letterconfigurationPostulant
                .Select(i => new NewsletterPostulantFrontConfiguration
                {

                    Descripcion = Funclanguage(i.Descripcion, i.DescripcionEn, i.DescripcionPt, languajeid),
                    Email = Funclanguage(i.Email, i.EmailEn, i.EmailPt, languajeid),
                    Enviar = Funclanguage(i.Enviar, i.EnviarEn, i.EnviarPt, languajeid),
                    Id = i.Id,
                    Nombre = Funclanguage(i.Nombre, i.NombreEn, i.NombrePt, languajeid),
                    Suscribete = Funclanguage(i.Suscribete, i.SuscribeteEn, i.SuscribetePt, languajeid),
                    ValidaEmail = Funclanguage(i.ValidaEmail, i.ValidaEmailEn, i.ValidaEmailPt, languajeid),
                    ValidaNombre = Funclanguage(i.ValidaNombre, i.ValidaNombreEn, i.ValidaNombrePt, languajeid),
                    EmailValido = Funclanguage(i.EmailValido, i.EmailValidoEn, i.EmailValidoPt, languajeid)




                }).FirstOrDefault();

            return service;
        }
    }
}
