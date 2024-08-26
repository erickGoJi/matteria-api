using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentRecruitingComoEs;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentRecruitingComoEs
{
    public class FrontContentRecruitingComoEsRepository: GenericRepository<biz.matteria.Entities.FrontContentRecruitingComo>, IFrontContentRecruitingComoEs
    {
        public FrontContentRecruitingComoEsRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentRecruitingComo> GetRecruitingComoEs(int languageId)
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

            

           

            var service = _context.FrontContentRecruitingComoes
                .Select(i => new FrontContentRecruitingComo
                {
                    Active = i.Active,
                    ComoesHeaderId = i.ComoesHeaderId,
                    Description = Funclanguage(i.Description,i.DescriptionEn,i.DescriptionPt,languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id


                }).ToList();

            return service;
        }
    }
}
