using biz.matteria.Repository.FrontContentTalleresHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentTalleresHeader
{
   public class FrontContentTalleresHeaderRepository: GenericRepository<biz.matteria.Entities.FrontContentTalleresHeader>, IFrontContentTalleresHeader
    {

        public FrontContentTalleresHeaderRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentTalleresHeader GetFrontTalleresHead(int languageId)
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






            var service = _context.FrontContentTalleresHeaders
                .Select(i => new biz.matteria.Entities.FrontContentTalleresHeader
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    BtnContactanos = Funclanguage(i.BtnContactanos, i.BtnContactanosEn, i.BtnContactanosPt, languageId)
                     



                }).FirstOrDefault();

            return service;
        }
    }
}
