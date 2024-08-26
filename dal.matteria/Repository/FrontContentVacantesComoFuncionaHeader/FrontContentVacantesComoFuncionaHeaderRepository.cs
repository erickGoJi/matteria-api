using biz.matteria.Repository.FrontContentVacantesComoFuncionaHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentVacantesComoFuncionaHeader
{
    public class FrontContentVacantesComoFuncionaHeaderRepository : GenericRepository<biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader>, IFrontContentVacantesComoFuncionaHeader
    {

        public FrontContentVacantesComoFuncionaHeaderRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader GetFrontVacantesComoFuncionaHeader(int languageId)
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


            var service = _context.FrontContentVacantesComoFuncionaHeaders
                .Select(i => new biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    BtnPublicar = Funclanguage(i.BtnPublicar, i.BtnPublicarEn, i.BtnPublicarPt, languageId),
                    LblComoPublicar = Funclanguage(i.LblComoPublicar, i.LblComoPublicarEn, i.LblComoPublicarPt, languageId),
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId)

                }).FirstOrDefault();

            return service;
        }
    }
}
