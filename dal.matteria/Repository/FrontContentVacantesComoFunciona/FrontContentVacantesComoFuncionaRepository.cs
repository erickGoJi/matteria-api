using biz.matteria.Repository.FrontContentVacantesComoFunciona;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentVacantesComoFunciona
{
    public class FrontContentVacantesComoFuncionaRepository : GenericRepository<biz.matteria.Entities.FrontContentVacantesComoFunciona>, IFrontContentVacantesComoFunciona
    {

        public FrontContentVacantesComoFuncionaRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.FrontContentVacantesComoFunciona> GetFrontVacantesComoFunciona(int languageId)
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


            var service = _context.FrontContentVacantesComoFuncionas
                .Select(i => new biz.matteria.Entities.FrontContentVacantesComoFunciona
                {
                    Active = i.Active,
                    Comofuncionaheaderid = i.Comofuncionaheaderid,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    RegistrationDate = i.RegistrationDate


                }).ToList();

            return service;
        }
    }
}
