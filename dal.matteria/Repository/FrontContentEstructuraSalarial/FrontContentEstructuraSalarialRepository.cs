using biz.matteria.Repository.FrontContentEstructuraSalarial;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentEstructuraSalarial
{
    public class FrontContentEstructuraSalarialRepository : GenericRepository<biz.matteria.Entities.FrontContentEstructuraSalarial>, IFrontContentEstructuraSalarial
    {

        public FrontContentEstructuraSalarialRepository(DbmatteriaContext context) : base(context) { }
        public biz.matteria.Entities.FrontContentEstructuraSalarial GetEstructuraSalarial(int languageId)
        {
            //type 1 objetivos especificos
            //type 2 impacto


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




            var service = _context.estructurasalarial
                .Select(i => new biz.matteria.Entities.FrontContentEstructuraSalarial
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPoliticas = Funclanguage(i.DescriptionPoliticas, i.DescriptionPoliticasEn, i.DescriptionPoliticasPt, languageId),
                    DescriptionPoliticasEn = i.DescriptionPoliticasEn,
                    DescriptionPoliticasPt = i.DescriptionPoliticasPt,
                    DescriptionPoliticasShort = Funclanguage(i.DescriptionPoliticasShort, i.DescriptionPoliticasShortEn, i.DescriptionPoliticasShortPt, languageId),
                    DescriptionPoliticasShortEn = i.DescriptionPoliticasShortEn,
                    DescriptionPoliticasShortPt = i.DescriptionPoliticasShortPt,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    ImageObjetivos = i.ImageObjetivos,
                    ImagePoliticas = i.ImagePoliticas,
                    ImgImpacto = i.ImgImpacto,
                    LinkMaterial = i.LinkMaterial,
                    Title = Funclanguage(i.Title, i.DescriptionPoliticasEn, i.DescriptionPoliticasPt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePoliticas = Funclanguage(i.TitlePoliticas, i.TitlePoliticasEn, i.TitlePoliticasPt, languageId),
                    TitlePoliticasEn = i.TitlePoliticasEn,
                    TitlePoliticasPt = i.TitlePoliticasPt,
                    TitlePt = i.TitlePt,
                    TitleImpacto = Funclanguage(i.TitleImpacto, i.TitleImpactoEn, i.TitleImpactoPt, languageId),
                    TitleImpactoEn = i.TitleImpactoEn,
                    TitleImpactoPt = i.TitleImpactoPt,
                    TitleObjetivos = Funclanguage(i.TitleObjetivos, i.TitleObjetivosEn, i.TitleObjetivosPt, languageId),
                    TitleObjetivosEn = i.TitleObjetivosEn,
                    TitleObjetivosPt = i.TitleObjetivosPt,
                    FrontContentEstructuraSalarialDetalles = i.FrontContentEstructuraSalarialDetalles,
                     BtnDownload = Funclanguage(i.BtnDownload, i.BtnDownloadEn, i.BtnDownloadPt, languageId)


                }).FirstOrDefault();

            return service;
        }
    }
}
