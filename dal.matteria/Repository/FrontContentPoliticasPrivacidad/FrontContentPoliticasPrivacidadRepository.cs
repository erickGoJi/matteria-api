using biz.matteria.Repository.FrontContentPoliticasPrivacidad;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentPoliticasPrivacidad
{
    public class FrontContentPoliticasPrivacidadRepository : GenericRepository<biz.matteria.Entities.FrontContentPoliticasPrivacidad>, IFrontContentPoliticasPrivacidad
    {

        public FrontContentPoliticasPrivacidadRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentPoliticasPrivacidad GetPoliticasPrivacidad(int languajeId)
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



            var service = _context.politicasPrivacidad
                .Select(i => new biz.matteria.Entities.FrontContentPoliticasPrivacidad
                {
                    Contenido = Funclanguage(i.Contenido,i.ContenidoEn,i.ContenidoPt,languajeId),
                    ContenidoEn = i.ContenidoEn,
                    ContenidoPt = i.ContenidoPt,
                    CreationDate = i.CreationDate,
                    Id = i.Id

                }).FirstOrDefault();

            return service;
        }
    }
}
