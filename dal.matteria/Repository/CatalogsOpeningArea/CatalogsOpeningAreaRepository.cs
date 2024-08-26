using biz.matteria.Repository.CatalogsOpeningArea;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CatalogsOpeningArea
{
    public class CatalogsOpeningAreaRepository : GenericRepository<biz.matteria.Entities.CatalogsAreaOpening>, ICatalogsOpeningArea
    {
        public CatalogsOpeningAreaRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CatalogsAreaOpening> GetOpeningAreas(int languageId)
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


            var service = _context.areaOpening
                .Select(i => new biz.matteria.Entities.CatalogsAreaOpening
                {

                    Id = i.Id,
                    Name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                    NameEn = i.NameEn,
                    NamePt = i.NamePt,
                    Active = i.Active,
                    RegistrationDate = i.RegistrationDate




                }).ToList();

            return service;
        }
    }
}
