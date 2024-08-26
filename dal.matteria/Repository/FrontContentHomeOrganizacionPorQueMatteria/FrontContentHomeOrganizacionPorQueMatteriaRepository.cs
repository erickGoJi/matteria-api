using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHomeOrganizacionPorQueMatteria
{
    public class FrontContentHomeOrganizacionPorQueMatteriaRepository : GenericRepository<biz.matteria.Entities.FrontContentHomeOrganizacionPorQueMatterium>, IFrontContentHomeOrganizacionPorQueMatteria
    {

        public FrontContentHomeOrganizacionPorQueMatteriaRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentHomeOrganizacionPorQueMatterium> GetFrontContentHoeOrgPorqueMatterria(int languajeid)
        {
            string languaje(string es, string en, string pt, int lenguajeId)
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






            var service = _context.homeorgproquematerria
                .Select(i => new FrontContentHomeOrganizacionPorQueMatterium
                {
                    Active = i.Active,
                    CreateDate = i.CreateDate,
                    DescriptionLong = Funclanguage(i.DescriptionLong, i.DescriptionLongEn, i.DescriptionLongPt, languajeid),
                    DescriptionLongEn = i.DescriptionLongEn,
                    DescriptionLongPt = i.DescriptionLongPt,
                    DescriptionShort = Funclanguage(i.DescriptionShort, i.DescriptionShortEn, i.DescriptionShortPt, languajeid),
                    DescriptionShortEn = i.DescriptionShortEn,
                    DescriptionShortPt = i.DescriptionShortPt,
                    Id = i.Id,
                    Number = i.Number,
                    LabelDistintos = Funclanguage(i.LabelDistintos, i.LabelDistintosEn, i.LabelDistintosPt, languajeid),
                    LabelDistintosEn = i.LabelDistintosEn,
                    LabelDistintosPt = i.LabelDistintosPt,
                    LabelPorque = Funclanguage(i.LabelPorque, i.LabelPorqueEn, i.LabelPorquePt, languajeid),
                    LabelPorqueEn = i.LabelPorqueEn,
                    LabelPorquePt = i.LabelPorquePt,
                    MoreInfo = Funclanguage(i.MoreInfo, i.MoreInfoEn, i.MoreInfoPt, languajeid)


                }).ToList();

            return service;
        }
    }
}
