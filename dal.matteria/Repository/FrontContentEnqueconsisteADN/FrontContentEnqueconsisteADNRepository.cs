using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentEnqueconsisteADN;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentEnqueconsisteADN
{
    public class FrontContentEnqueconsisteADNRepository : GenericRepository<biz.matteria.Entities.FrontContentEnqueconsisteAdn>, IFrontContentEnqueconsisteADN
    {

        public FrontContentEnqueconsisteADNRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentEnqueconsisteAdn> getEnqueConsisteADN(int languajeId)
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



            var service = _context.FrontContentEnqueconsisteAdns
                .Select(i => new FrontContentEnqueconsisteAdn
                {
                    Active = i.Active,
                    AdnHeaderId = i.AdnHeaderId,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt,languajeId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    RegistrationDate = i.RegistrationDate,
                    TileEn = i.TileEn,
                    Title = Funclanguage(i.Title, i.TileEn, i.TitlePt, languajeId),
                    TitlePt = i.TitlePt
                     


                }).ToList();

            return service;
            
        }
    }
}
