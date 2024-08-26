using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentcomofunciona_assessment;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentComoFuncionaAssessment
{
    public class FontContentComoFuncionaAssessmentRepository : GenericRepository<biz.matteria.Entities.FrontContentComofuncionaAssessment>, IFrontContentComofuncionaAssessment
    {
        public FontContentComoFuncionaAssessmentRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentComofuncionaAssessment> GetFrontContentcomofuncionaAssesment(int languageId)
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









            var service = _context.FrontContentComofuncionaAssessments
                .Select(i => new FrontContentComofuncionaAssessment
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt

                }).ToList();

            return service;
        }
    }
}
