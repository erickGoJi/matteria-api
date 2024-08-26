using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentPorQueMatteria;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentPorQueMatteria
{
    public class FrontContentPorqueMatteriaRepository : GenericRepository<biz.matteria.Entities.FrontContentPorqueMatterium>, IFrontContentPorQueMatteria
    {

        public FrontContentPorqueMatteriaRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentPorqueMatterium> GetFrontContentPorqueMatteria(int languajeid)
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




            //type 1 tecnicas 2 humanas 3 emprendedoras
            var service = _context.porquematteria
                .Select(i => new FrontContentPorqueMatterium
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    DescriptionProfesionales = Funclanguage(i.DescriptionProfesionales, i.DescriptionProfesionalesEn, i.DescriptionProfesionalesPt, languajeid),
                    DescriptionProfesionalesEn = i.DescriptionProfesionalesEn,
                    DescriptionProfesionalesPt = i.DescriptionProfesionalesPt,
                    Id = i.Id,
                    Image = i.Image,
                    Phrase = Funclanguage(i.Phrase, i.PhraseEn, i.PhrasePt, languajeid),
                    PhraseEn = i.PhraseEn,
                    PhrasePt = i.PhrasePt,
                    TitlePhrase = Funclanguage(i.TitlePhrase, i.TitlePhraseEn, i.TitlePhrasePt, languajeid),
                    TitlePhraseEn = i.TitlePhraseEn,
                    TitlePhrasePt = i.TitlePhrasePt,
                    TitleProfesionales = Funclanguage(i.TitleProfesionales, i.TitleProfesionalesEn, i.TitleProfesionalesPt, languajeid),
                    TitleProfesionalesEn = i.TitleProfesionalesEn,
                    TitleProfesionalesPt = i.TitleProfesionalesPt,
                    TitleSeccion = Funclanguage(i.TitleSeccion, i.TitleSeccionEn, i.TitleSeccionPt, languajeid),
                    FrontContentPorqueMatteriaDetalles = i.FrontContentPorqueMatteriaDetalles.Select(x => new biz.matteria.Entities.FrontContentPorqueMatteriaDetalle { Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languajeid), DescriptionEn = x.DescriptionEn, DescriptionPt = x.DescriptionPt, PorquematteriaId = x.PorquematteriaId }).ToList(),
                    ImageSeccion = i.ImageSeccion,
                    LblVacantes = Funclanguage(i.LblVacantes, i.LblVacantesEn, i.LblVacantesPt, languajeid)


                }).ToList();

            return service;
        }
    }
}
