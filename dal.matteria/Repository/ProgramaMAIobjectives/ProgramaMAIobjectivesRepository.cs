using biz.matteria.Entities;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ProgramaMAIobjectives
{
    public class ProgramaMAIobjectivesRepository: GenericRepository<biz.matteria.Entities.ProgramaMaiobjective>, biz.matteria.Repository.ProgramaMAIobjectives.IProgramaMAIobjectives
    {

        public ProgramaMAIobjectivesRepository(DbmatteriaContext context) : base(context) { }

        public List<ProgramaMaiobjective> GetProgramaMAIObjetives(int languajeId)
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





            var service = _context.programaMAIObjetive
                .Select(x => new ProgramaMaiobjective
                {
                    Active = x.Active,
                    Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languajeId),
                    DescriptionEn = x.DescriptionEn,
                    DescriptionPt = x.DescriptionPt,
                    Id = x.Id,
                    RegistrationDate = x.RegistrationDate
                     

                }).ToList();

            return service;
        }

        
    }
}
