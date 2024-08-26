using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentReruitingPorQueContratarnos;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentReruitingPorQueContratarnos
{
    public class FrontContentReruitingPorQueContratarnosRepository : GenericRepository<biz.matteria.Entities.FrontContentReruitingPorQueContratarno>, IFrontContentReruitingPorQueContratarnos
    {
        public FrontContentReruitingPorQueContratarnosRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentReruitingPorQueContratarno> GetRecruitingPorQueContratarnos(int languajeId)
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


            var service = _context.FrontContentReruitingPorQueContratarnos
                .Select(i => new FrontContentReruitingPorQueContratarno
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    LblPorque = Funclanguage(i.LblPorque, i.LblPorqueEn, i.LblPorquePt, languajeId)



                }).ToList();

            return service;
        }
    }
}
