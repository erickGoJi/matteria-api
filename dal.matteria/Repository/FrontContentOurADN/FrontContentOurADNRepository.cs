using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentOurADN;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentOurADN
{
    public class FrontContentOurADNRepository : GenericRepository<biz.matteria.Entities.FrontContentOurAdn>, IFrontContentOurADN
    {
        public FrontContentOurADNRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentOurAdn> GetOurADN(int languageId)
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




            var servicio = _context.FrontContentOurAdns
                .Select(i => new FrontContentOurAdn
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description,i.DescriptionEn,i.DescriptionPt,languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt

                }).ToList();

            return servicio;
        }
    }
}
