using biz.matteria.Repository.FrontContentManagerFaq;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerFaq
{
    public class FrontContentManagerFaqRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerFaq>, IFrontContentManagerFaq
    {

        public FrontContentManagerFaqRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.FrontContentManagerFaq> GetFrontContentFaqsAndAnswers(int languageId)
        {



            //type 1 = postulantes type 2 = organizaciones

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



            var service = _context.faqs
                .Select(i => new biz.matteria.Entities.FrontContentManagerFaq
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Id = i.Id,
                    Pregunta = Funclanguage(i.Pregunta,i.PreguntaEn,i.PreguntaPt,languageId),
                    PreguntaEn = i.PreguntaEn,
                    PreguntaPt = i.PreguntaPt,
                    Type = i.Type,
                    FrontContentAnswers = i.FrontContentAnswers.Select(x => new biz.matteria.Entities.FrontContentAnswer { Respuesta = Funclanguage(x.Respuesta,x.RespuestaEn,x.RespuestaPt,languageId),RespuestaEn = x.RespuestaEn,RespuestaPt = x.RespuestaPt,PreguntaId =x.PreguntaId,Id=x.Id }).ToList(),
                     Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId)


                }).ToList();


            return service;
        }
    }
}
