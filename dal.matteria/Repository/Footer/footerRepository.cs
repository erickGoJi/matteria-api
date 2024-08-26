using biz.matteria.Models.Footer;
using biz.matteria.Repository.Footer;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.Footer
{
    public class footerRepository: GenericRepository<biz.matteria.Entities.Footer>, IFooter
    {

        public footerRepository(DbmatteriaContext context) : base(context) { }

        public List<footerResponse> GetFooter(int languageId)
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



            var service = _context.footer
                .Select(i => new footerResponse
                {
                    id = i.Id,
                    nombre = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    FooterDetails = i.FooterDetails.Select(x => new biz.matteria.Entities.FooterDetail { Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languageId), DescriptionEn = x.DescriptionEn, DescriptionPt = x.DescriptionPt,Url = x.Url }).ToList(),
                    url = i.Url




                }).ToList();

            return service;
            
        }
    }
}
