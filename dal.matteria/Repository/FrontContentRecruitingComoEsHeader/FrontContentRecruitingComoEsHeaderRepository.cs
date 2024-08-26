using biz.matteria.Repository.FrontContentRecruitingComoEsHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentRecruitingComoEsHeader
{
   public  class FrontContentRecruitingComoEsHeaderRepository : GenericRepository<biz.matteria.Entities.FrontContentRecruitingComoEsHeader>, IFrontContentRecruitingComoEsHeader
    {
        public FrontContentRecruitingComoEsHeaderRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.FrontContentRecruitingComoEsHeader> GetRecruitingComoEsHeader(int languageId)
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


            var service = _context.FrontContentRecruitingComoEsHeaders
                .Select(i => new biz.matteria.Entities.FrontContentRecruitingComoEsHeader
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    FrontContentRecruitingComos = i.FrontContentRecruitingComos.Select(x => new biz.matteria.Entities.FrontContentRecruitingComo { Active = x.Active, ComoesHeaderId = x.ComoesHeaderId, Id = x.Id, Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languageId), DescriptionEn = x.DescriptionEn, DescriptionPt = x.DescriptionPt }).ToList(),
                    TitleComoes = Funclanguage(i.TitleComoes, i.TitleComoesEn, i.TitleComoesPt, languageId)



                }).ToList();

            return service;


        }
    }
}
