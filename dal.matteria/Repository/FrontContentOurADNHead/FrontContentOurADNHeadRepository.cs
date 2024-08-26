using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentOurADNHead;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentOurADNHead
{
    public class FrontContentOurADNHeadRepository : GenericRepository<biz.matteria.Entities.FrontContentOurAdnhead>, IFrontContentOurADNHead
    {

        public FrontContentOurADNHeadRepository(DbmatteriaContext context) : base(context) { }
        public FrontContentOurAdnhead GetOurADNHead(int languageId)
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



            var service = _context.FrontContentOurAdnheads
                .Select(i => new FrontContentOurAdnhead
                {
                    Active = i.Active,
                    Id = i.Id,
                    Phrase = Funclanguage(i.Phrase, i.PhraseEn, i.PhrasePt, languageId),
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId)



                }).FirstOrDefault();

            return service;
        }
    }
}
