using biz.matteria.Entities;
using biz.matteria.Repository.ProgramaMAIModelo;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ProgramaMAIModelo
{
    public class ProgramaMAIModeloRepository : GenericRepository<biz.matteria.Entities.ProgramaMaimodelo>, IProgramaMAIModelo
    {
        public ProgramaMAIModeloRepository(DbmatteriaContext context) : base(context) { }
        public List<ProgramaMaimodelo> GetProrgramaMAIModelo(int languajeId)
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






            var service = _context.programaMAIModelo
                .Select(x => new ProgramaMaimodelo
                {
                    Active = x.Active,
                    Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languajeId),
                    DescriptionEn = x.DescriptionEn,
                    DescriptionPt = x.DescriptionPt,
                    Id = x.Id,
                    Image = x.Image,
                    RegistrationDate = x.RegistrationDate,
                    Title = Funclanguage(x.Title, x.TitleEn, x.TitlePt, languajeId),
                    TitleEn = x.TitleEn,
                    TitlePt = x.TitlePt
                     

                }).ToList();

            return service;
        }
    }
}
