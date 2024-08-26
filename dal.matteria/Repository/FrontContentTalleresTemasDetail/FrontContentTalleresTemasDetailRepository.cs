using biz.matteria.Repository.FrontContentTalleresTemasDetail;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentTalleresTemasDetail
{
    public class FrontContentTalleresTemasDetailRepository : GenericRepository<biz.matteria.Entities.FrontContentTalleresTemasDetail>, IFrontContentTalleresTemasDetail
    {

        public FrontContentTalleresTemasDetailRepository(DbmatteriaContext context) : base(context) { }
        public List<biz.matteria.Entities.FrontContentTalleresTemasDetail> GetFrontTalleresTemasDetail(int languageId)
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


            var service = _context.FrontContentTalleresTemasDetails
                .Select(i => new biz.matteria.Entities.FrontContentTalleresTemasDetail
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    Id = i.Id,
                    RegisterDate = i.RegisterDate,
                    TemasHeadId = i.TemasHeadId
                     


                }).ToList();

            return service;
        }
    }
}
