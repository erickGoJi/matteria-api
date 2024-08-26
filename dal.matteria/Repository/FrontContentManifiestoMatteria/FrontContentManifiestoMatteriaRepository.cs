using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentManifiestoMatteria;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManifiestoMatteria
{
    public class FrontContentManifiestoMatteriaRepository: GenericRepository<biz.matteria.Entities.FrontContentManifiestoMatterium>, IFrontContentManifiestoMatteria
    {
        public FrontContentManifiestoMatteriaRepository(DbmatteriaContext context) : base(context) { }

        public FrontContentManifiestoMatterium GetManifiestoMatteria(int languajeid)
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




            var service = _context.FrontContentManifiestoMatterium
                .Select(i => new FrontContentManifiestoMatterium
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    ImageCeo = i.ImageCeo,
                    Linkedin = i.Linkedin,
                    MarketStall = Funclanguage(i.MarketStall, i.MarketStallEn, i.MarketStallPt, languajeid),
                    Name = i.Name,
                    Phrase = Funclanguage(i.Phrase, i.PhraseEn, i.PhrasePt, languajeid),
                    RegistrationDate = i.RegistrationDate,
                    TitleHeader = Funclanguage(i.TitleHeader, i.TitleHeaderEn, i.TitleHeaderPt, languajeid),
                    TitleHeaderEn = i.TitleHeaderEn,
                    TitleHeaderPt = i.TitleHeaderPt,
                    RazonSer = Funclanguage(i.RazonSer, i.RazonSerEn, i.RazonSerPt, languajeid),
                    BtnOurAdn = Funclanguage(i.BtnOurAdn, i.BtnOurAdnEn, i.BtnOurAdnPt, languajeid)



                }).FirstOrDefault();

            return service;
        }
    }
}
