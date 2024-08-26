using biz.matteria.Repository.FrontContentRecruitingPassiveHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentRecruitingPassiveHeader
{
    public class FrontContentRecruitingPassiveHeaderRepository : GenericRepository<biz.matteria.Entities.FrontContentRecruitingPassiveHeader>, IFrontContentRecruitingPassiveHeader
    {

        public FrontContentRecruitingPassiveHeaderRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentRecruitingPassiveHeader GetRecruitingPassiveHeader(int languageId)
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





            var service = _context.FrontContentRecruitingPassiveHeaders
                .Select(i => new biz.matteria.Entities.FrontContentRecruitingPassiveHeader
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    BtnContact = Funclanguage(i.BtnContact, i.BtnContactEn, i.BtnContactPt, languageId),
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId)

                }).FirstOrDefault();

            return service;
        }
    }
}
