using biz.matteria.Models.CatalogsOralLevel;
using biz.matteria.Repository.CtalogOralLevel;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogOralLevel
{
    public class CatalogOralLevelRepository: GenericRepository<biz.matteria.Entities.CatalogOralLevel>, ICatalogOralLevel
    {
        public CatalogOralLevelRepository(DbmatteriaContext context) : base(context) { }
        public List<CatalogsOralLevelService> GetAllCatalogOralLevel(int languageId)
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





            var service = _context.CatalogOralLevels
                .Select(i => new CatalogsOralLevelService
                {
                    Id = i.Id,
                    name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                    NameEn = i.NameEn,
                    NamePt = i.NamePt


                }).ToList();

            return service;
        }

        
    }
}
