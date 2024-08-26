using biz.matteria.Repository.FrontContentRecruitingPassive;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentRecruitingPassive
{
    public class FrontContentRecruitingPassiveRepository : GenericRepository<biz.matteria.Entities.FrontContentRecruitingPassive>, IFrontContentRecruitingPassive
    {
        public FrontContentRecruitingPassiveRepository(DbmatteriaContext context) : base(context) { }
        public List<biz.matteria.Entities.FrontContentRecruitingPassive> GetRecruitingPassive(int languajeId)
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



            var service = _context.FrontContentRecruitingPassives
                .Select(i => new biz.matteria.Entities.FrontContentRecruitingPassive
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description,i.DescriptionEn,i.DescriptionPt,languajeId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    PassiveHeadId = i.PassiveHeadId


                }).ToList();

            return service;
        }
    }
}
