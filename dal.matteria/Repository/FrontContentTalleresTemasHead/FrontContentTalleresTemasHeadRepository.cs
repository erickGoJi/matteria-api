using biz.matteria.Repository.FrontContentTalleresTemasHead;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentTalleresTemasHead
{
    public class FrontContentTalleresTemasHeadRepository : GenericRepository<biz.matteria.Entities.FrontContentTalleresTemasHead>, IFrontContentTalleresTemasHead
    {

        public FrontContentTalleresTemasHeadRepository(DbmatteriaContext context) : base(context) { }
        public biz.matteria.Entities.FrontContentTalleresTemasHead GetFrontTalleresTemasHead(int languajeId)
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


            var service = _context.FrontContentTalleresTemasHeads
                .Select(i => new biz.matteria.Entities.FrontContentTalleresTemasHead
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate,
                     Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeId),
                      SubTitle = Funclanguage(i.SubTitle, i.SubTitleEn, i.SubTitlePt, languajeId),
                       Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeId)

                }).FirstOrDefault();

            return service;


        }
    }
}
