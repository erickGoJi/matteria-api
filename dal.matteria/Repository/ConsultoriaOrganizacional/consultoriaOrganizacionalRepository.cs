using biz.matteria.Models.consultoriaOrganizacional;
using biz.matteria.Repository.ConsultoriaOrganizacional;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.ConsultoriaOrganizacional
{
    public class consultoriaOrganizacionalRepository : GenericRepository<biz.matteria.Entities.FrontContentConsultoriaOrganizacional>, IConsultoriaOrganizacional
    {
        public consultoriaOrganizacionalRepository(DbmatteriaContext context) : base(context) { }
        public consultoriaOrganizacionalService GetConsultoriaOrganizacional(int lenguajeId)
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





            var service = _context.consultoriaOrganizacional
                .Select(i => new consultoriaOrganizacionalService
                {
                       Id = i.Id,
                       Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, lenguajeId),
                       Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, lenguajeId),
                       BtnLink = i.BtnLink,
                       Image = i.Image,
                       LabelBtn = Funclanguage(i.LabelBtn, i.LabelBtnEn, i.LabelBtnPt, lenguajeId),
                       consultoriaDetalle = i.FrontContentConsultoriaOrganizacionalDetalles



                }).FirstOrDefault();

            return service;
        }
    }
}
