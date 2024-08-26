using biz.matteria.Entities;
using biz.matteria.Repository.ProgramaMAI;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ProgramaMAI
{
    public class ProgramaMAIRepository : GenericRepository<biz.matteria.Entities.ProgramaMai>, IProgramaMAI
    {
        public ProgramaMAIRepository(DbmatteriaContext context) : base(context) { }
        public ProgramaMai GetProgramaMAI(int languajeId)
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




            var service = _context.programaMai
                .Select(x => new ProgramaMai
                {
                    Active = x.Active,
                    DescriptionMai = Funclanguage(x.DescriptionMai, x.DescriptionMaiEn, x.DescriptionMaiPt, languajeId),
                    DescriptionMaiEn = x.DescriptionMaiEn,
                    DescriptionMaiPt = x.DescriptionMaiPt,
                    DescriptionManaged = Funclanguage(x.DescriptionManaged, x.DescriptionManagedEn, x.DescriptionManagedPt, languajeId),
                    DescriptionManagedEn = x.DescriptionManagedEn,
                    DescriptionManagedPt = x.DescriptionManagedPt,
                    ImageManaged = x.ImageManaged,
                    ImageObjectives = x.ImageObjectives,
                    LinkMaterial = x.LinkMaterial,
                    RegisterDate = x.RegisterDate,
                    TitleMai = Funclanguage(x.TitleMai, x.TitleMaiEn, x.TitleMaiPt, languajeId),
                    TitleMaiEn = x.TitleMaiEn,
                    TitleMaiPt = x.TitleMaiPt,
                    TitleManaged = Funclanguage(x.TitleManaged, x.TitleManagedEn, x.TitleManagedPt, languajeId),
                    TitleManagedEn = x.TitleManagedEn,
                    TitleManagedPt = x.TitleManagedPt,
                    Video = x.Video,
                    BtnDownload = Funclanguage(x.BtnDownload, x.BtnDownloadEn, x.BtnDownloadPt, languajeId),
                    Id = x.Id,
                    LblTitleObjetivos = Funclanguage(x.LblTitleObjetivos, x.LblTitleObjetivosEn, x.LblTitleObjetivosPt, languajeId)





                }).FirstOrDefault();

            return service;
        }
    }
}
