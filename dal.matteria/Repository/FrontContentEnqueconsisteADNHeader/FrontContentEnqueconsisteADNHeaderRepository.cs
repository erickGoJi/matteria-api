using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentEnqueconsisteADNHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentEnqueconsisteADNHeader
{
    public class FrontContentEnqueconsisteADNHeaderRepository: GenericRepository<biz.matteria.Entities.FrontContentEnqueconsisteAdnHeader>, IFrontContentEnqueconsisteADNHeader
    {
        public FrontContentEnqueconsisteADNHeaderRepository(DbmatteriaContext context) : base(context) { }

        public FrontContentEnqueconsisteAdnHeader GetHeadEnqueConsisteADN(int languajeId)
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



            var service = _context.FrontContentEnqueconsisteAdnHeaders
                .Select(i => new FrontContentEnqueconsisteAdnHeader
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                     LblEnqueConsiste = Funclanguage(i.LblEnqueConsiste, i.LblEnqueConsisteEn, i.LblEnqueConsistePt, languajeId)

                }).FirstOrDefault();

            return service;
        }
    }
}
