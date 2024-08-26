using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentManagerAliados;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerAliados
{
    public class FrontContentManagerAliadosRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerAliado>, IFrontContentManagerAliados
    {

        public FrontContentManagerAliadosRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentManagerAliado> GetAliados(int languajeid)
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







            var service = _context.aliado
                .Select(i => new FrontContentManagerAliado
                {
                    AliadoUrl = i.AliadoUrl,
                    CreatedById = i.CreatedById,
                    CreationDate = i.CreationDate,
                    Descripcion = Funclanguage(i.Descripcion, i.DescripcionEn, i.DescripcionEn, languajeid),
                    DescripcionEn = i.DescripcionEn,
                    Empresa = i.Empresa,
                    Id = i.Id,
                    Imagen = i.Imagen,
                    ModificationDate = i.ModificationDate,
                    ModifiedById = i.ModifiedById,
                    Status = i.Status


                }).ToList();

            return service;
        }

        public FrontContentManagerAliadosHeader getAliadosHeader(int languajeid)
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




            var service = _context.aliadoHeader
                .Select(i => new FrontContentManagerAliadosHeader
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Id = i.Id,
                    Phrase = Funclanguage(i.Phrase, i.PhraseEn, i.PhrasePt, languajeid),
                    PhraseEn = i.PhraseEn,
                    PhrasePt = i.PhrasePt


                }).FirstOrDefault();

            return service;
        }
    }
}
