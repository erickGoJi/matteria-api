using biz.matteria.Repository.FrontContentHomeHeaderPostulante;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHomeHeaderPostulante
{
    public class FrontContentHomeHeaderPostulanteRepository : GenericRepository<biz.matteria.Entities.FrontContentHomeHeaderPostulante>, IFrontContentHomeHeaderPostulante
    {

        public FrontContentHomeHeaderPostulanteRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentHomeHeaderPostulante GetHeaderHomePostulante(int languajeid)
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






            var service = _context.homeheaderpostulante
                .Select(i => new biz.matteria.Entities.FrontContentHomeHeaderPostulante
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    LinkVacantes = i.LinkVacantes,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeid),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    Destacada = Funclanguage(i.Destacada, i.DestacadaEn, i.DestacadaPt, languajeid),
                    VerVacantes = Funclanguage(i.VerVacantes, i.VerVacantesEn, i.VerVacantesPt, languajeid)

                }).FirstOrDefault();

            return service;
        }
    }
}
