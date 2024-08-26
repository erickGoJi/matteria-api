using biz.matteria.Repository.FrontContentVacantesComoPublicar;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentVacantesComoPublicar
{
    public class FrontContentVacantesComoPublicarRepository : GenericRepository<biz.matteria.Entities.FrontContentVacantesComoPublicar>, IFrontContentVacantesComoPublicar
    {


        public FrontContentVacantesComoPublicarRepository(DbmatteriaContext context) : base(context) { }
        public List<biz.matteria.Entities.FrontContentVacantesComoPublicar> GetFrontVacantesComoPublicar(int languageId)
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



            var service = _context.FrontContentVacantesComoPublicars
                .Select(i => new biz.matteria.Entities.FrontContentVacantesComoPublicar
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate



                }).ToList();

            return service;
        }
    }
}
