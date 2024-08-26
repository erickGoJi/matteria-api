using biz.matteria.Entities;
using biz.matteria.Models.paquetes;
using biz.matteria.Repository.FrontContentVacantesPaquetes;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentVacantesPaquetes
{
    public class FrontContentVacantesPaquetesRepository : GenericRepository<biz.matteria.Entities.FrontContentVacantesPaquete>, IFrontContentVacantesPaquetes
    {

        public FrontContentVacantesPaquetesRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentVacantesPaquete> GetFrontVacantesPaquetes(int languageId)
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



            var service = _context.FrontContentVacantesPaquetes
                .Select(i => new FrontContentVacantesPaquete
                {
                    Active = i.Active,
                    AplicaIva = i.AplicaIva,
                    CurrencyId = i.CurrencyId,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    PackagePrice = i.PackagePrice,
                    RealPrice = i.RealPrice,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    NumberCredits = i.NumberCredits,
                    Savemoney = i.Savemoney,
                    LblAhorra = Funclanguage(i.LblAhorra, i.LblAhorraEn, i.LblAhorraPt, languageId),
                    LblPrecio = Funclanguage(i.LblPrecio, i.LblPrecioEn, i.LblPrecioPt, languageId)


                }).ToList();

            return service;
        }

        public FrontContentVacantesPaquete GetFrontVacantesPaquetesById(int paqueteId)
        {
            var service = _context.FrontContentVacantesPaquetes
                .Where(x => x.Id == paqueteId)
                .Select(i => new FrontContentVacantesPaquete
                {
                    Active = i.Active,
                    AplicaIva = i.AplicaIva,
                    CurrencyId = i.CurrencyId,
                    Description = i.Description,
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    PackagePrice = i.PackagePrice,
                    RealPrice = i.RealPrice,
                    RegistrationDate = i.RegistrationDate,
                    Title = i.Title,
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    NumberCredits = i.NumberCredits,
                    Savemoney = i.Savemoney
                }).FirstOrDefault();

            return service;
        }

        public List<paquetes> GetPaquetes(string codeCountry, int languajeId)
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


            var service = _context.FrontContentVacantesPaquetes
                .Select(i => new paquetes
                {
                    Active = i.Active,
                    AplicaIva = i.AplicaIva,
                    CurrencyId = i.CurrencyId,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    PackagePrice = i.PackagePrice,
                    RealPrice = i.RealPrice,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languajeId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    NumberCredits = i.NumberCredits,
                    Savemoney = i.Savemoney,
                    precioPaqueteMonedaLocal = i.RealPrice * (from ctry in _context.CatalogsCountrys
                                               where ctry.CodeCountry == codeCountry
                                               select ctry.AmountMoney).FirstOrDefault(),
                    lblAhorra = Funclanguage(i.LblAhorra, i.LblAhorraEn, i.LblAhorraPt, languajeId),
                    lblPrecio = Funclanguage(i.LblPrecio, i.LblPrecioEn, i.LblPrecioEn, languajeId)

                }).ToList();

            return service;
        }
    }
}
