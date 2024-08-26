using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentTalleresObjetivos;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentTalleresObjetivos
{
    public class FrontContentTalleresObjetivosRepository : GenericRepository<biz.matteria.Entities.FrontContentTalleresObjetivo>, IFrontContentTalleresObjetivos
    {
        public FrontContentTalleresObjetivosRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentTalleresObjetivo> GetFrontTalleresObjetivos(int languageId)
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




            var service = _context.FrontContentTalleresObjetivos
                .Select(i => new FrontContentTalleresObjetivo
                {
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    LblTitle = Funclanguage(i.LblTitle, i.LblTitleEn, i.LblTitlePt, languageId)
                    
                      
                }).ToList();

            return service;
        }
    }
}
