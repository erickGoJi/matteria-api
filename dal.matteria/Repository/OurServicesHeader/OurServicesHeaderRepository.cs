using biz.matteria.Entities;
using biz.matteria.Repository.OurServicesHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.OurServicesHeader
{
    public class OurServicesHeaderRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerNuestrosserviciosHeader>, IOurServicesHeader
    {
        public OurServicesHeaderRepository(DbmatteriaContext context) : base(context) { }
        public FrontContentManagerNuestrosserviciosHeader GetOurServicesHeader(int languageId)
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







            var service = _context.FrontContentManagerNuestrosserviciosHeaders
                .Select(i => new FrontContentManagerNuestrosserviciosHeader
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    Id = i.Id,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    Image = i.Image,
                    BtnContacto = Funclanguage(i.BtnContacto, i.BtnContactoEn, i.BtnContactoPt, languageId)



                }).FirstOrDefault();

            return service;
            
        }
    }
}
