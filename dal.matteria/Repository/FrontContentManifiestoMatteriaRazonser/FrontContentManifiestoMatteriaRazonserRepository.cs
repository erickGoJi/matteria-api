using biz.matteria.Repository.FrontContentManifiestoMatteriaRazonser;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManifiestoMatteriaRazonser
{
    public class FrontContentManifiestoMatteriaRazonserRepository : GenericRepository<biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser>, IFrontContentManifiestoMatteriaRazonser
    {

        public FrontContentManifiestoMatteriaRazonserRepository(DbmatteriaContext context) : base(context) { }
        public List<biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser> GetManifiestoMatteriaRazondeSer(int languajeid)
        {


            string languaje(string es, string en, string pt, int lenguajeId)
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


            var service = _context.FrontContentManifiestoMatteriaRazonsers
                .Select(i => new biz.matteria.Entities.FrontContentManifiestoMatteriaRazonser
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeid),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt
                     
                     


                }).ToList();

            return service;
        }
    }
}
