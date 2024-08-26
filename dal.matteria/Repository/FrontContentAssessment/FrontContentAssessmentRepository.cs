using biz.matteria.Repository.FrontContentAssessment;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentAssessment
{
    public class FrontContentAssessmentRepository : GenericRepository<biz.matteria.Entities.FrontContentAssessment>, IFrontContentAssessment
    {
        public FrontContentAssessmentRepository(DbmatteriaContext context) : base(context) { }
        public biz.matteria.Entities.FrontContentAssessment GetFrontContentAssessmentHeader(int languageId)
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





            var service = _context.FrontContentAssessments
                .Select(i => new biz.matteria.Entities.FrontContentAssessment

                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    BtnDownload = Funclanguage(i.BtnDownload, i.BtnDownloadEn, i.BtnDownloadPt, languageId),
                    TitleComoFunciona = Funclanguage(i.TitleComoFunciona, i.TitleComoFuncionaEn, i.TitleComoFuncionaPt, languageId)

                }).FirstOrDefault();

            return service;
            
        }
    }
}
