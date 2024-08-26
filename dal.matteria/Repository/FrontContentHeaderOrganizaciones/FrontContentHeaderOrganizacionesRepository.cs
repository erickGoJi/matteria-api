using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentHeaderOrganizaciones;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHeaderOrganizaciones
{
    public class FrontContentHeaderOrganizacionesRepository : GenericRepository<biz.matteria.Entities.FrontContentHeaderOrganizacione>, IFrontContentHeaderOrganizaciones
    {

        public FrontContentHeaderOrganizacionesRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentHeaderOrganizacione> GetFrontContentHeaderOrg(int languajeid)
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






            var service = _context.homeHeaderOrg
                .Select(i => new FrontContentHeaderOrganizacione
                {
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    LinkMoreInfo = i.LinkMoreInfo,
                    LinkSeeMore = Funclanguage(i.LinkSeeMore, i.LinkSeeMoreEn, i.LinkSeeMorePt, languajeid),
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeid),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                     




                }).ToList();

            return service;
        }
    }
}
