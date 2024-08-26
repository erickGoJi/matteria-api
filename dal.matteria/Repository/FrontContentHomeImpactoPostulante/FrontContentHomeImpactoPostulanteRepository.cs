using biz.matteria.Repository.FrontContentHomeImpactoPostulante;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHomeImpactoPostulante
{
    public class FrontContentHomeImpactoPostulanteRepository : GenericRepository<biz.matteria.Entities.FrontContentHomeImpactoPostulante>, IFrontContentHomeImpactoPostulante
    {
        public FrontContentHomeImpactoPostulanteRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentHomeImpactoPostulante GetHomeImpactoPostulante(int languajeid)
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




            var service = _context.homeimpactopostulante
                .Select(i => new biz.matteria.Entities.FrontContentHomeImpactoPostulante
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeid),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    Image = i.Image,
                    Mentoria = Funclanguage(i.Mentoria, i.MentoriaEn, i.MentoriaPt, languajeid),
                    MoreInfo = Funclanguage(i.MoreInfo, i.MoreInfoEn, i.MoreInfoPt, languajeid)
                     


                }).FirstOrDefault();

            return service;
        }
    }
}
