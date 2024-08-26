using biz.matteria.Models.stepBystepPostulante;
using biz.matteria.Repository.stepBystepPostulante;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.stepBystepPostulante
{
    public class stepBystepPostulanteRepository : GenericRepository<biz.matteria.Entities.StepByStepPostulant>, IstepBystepPostulante
    {

        public stepBystepPostulanteRepository(DbmatteriaContext context) : base(context) { }
        public List<ResponsestepbystepPostulante> getstepByStepPostulantConfiguration(int languageId)
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




            var service = _context.stepByStepPostulante
                .Select(i => new ResponsestepbystepPostulante
                {

                     stepId = i.Id,
                     step = i.Step,
                     name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                     stepbystepDetail = i.StepByStepPostulantDetails.Select(x => new biz.matteria.Entities.StepByStepPostulantDetail { Name = Funclanguage(x.Name, x.NameEn, x.NamePt, languageId), NameEn = x.NameEn, NamePt = x.NamePt,StepId = x.StepId,Id=x.Id,PlaceHolder = Funclanguage(x.PlaceHolder, x.PlaceHolderEn, x.PlaceHolderPt, languageId) }).ToList(),


                }).ToList();

            return service;
        }
    }
}
