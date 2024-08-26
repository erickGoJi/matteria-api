using biz.matteria.Models.CatalogWrittenLevel;
using biz.matteria.Repository.CatalogWrittenLevel;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogWrittenLevel
{
    public class CatalogWrittenLevelRepository: GenericRepository<biz.matteria.Entities.CatalogWrittenLevel>, ICatalogWrittenLevel
    {
        public CatalogWrittenLevelRepository(DbmatteriaContext context) : base(context) { }

        public List<CatalogWrittenLevelService> GetAllCatalogWrittenLevel(int languageId)
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




            var service = _context.CatalogWrittenLevels
                .Select(i => new CatalogWrittenLevelService
                {
                    Id = i.Id,
                    Name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                    NameEn = i.NameEn,
                    NamePt = i.NamePt

                }).ToList();

            return service;
        }
    }
}
