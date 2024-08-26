using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentADN;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentADN
{
   public class FrontContentADNRepository : GenericRepository<biz.matteria.Entities.FrontContentAdnHeader>, IFrontContentADN
    {

        public FrontContentADNRepository(DbmatteriaContext context) : base(context) { }
        public FrontContentAdnHeader GetFrontADNHeader(int languajeId)
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




            var service = _context.FrontContentAdnHeaders
                .Select(i => new FrontContentAdnHeader
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    BtnDownload = Funclanguage(i.BtnDownload, i.BtnDownloadEn, i.BtnDownloadPt, languajeId)



                }).FirstOrDefault();

            return service;
            
        }
    }
}
