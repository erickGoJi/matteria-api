using biz.matteria.Entities;
using biz.matteria.Repository.OurServices;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.OurServices
{
    public class OurServicesRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerNuestrosservicio>, IOurServices
    {
        public OurServicesRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentManagerNuestrosservicio> GetOurServices(int languageId)
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











            var service = _context.FrontContentManagerNuestrosservicios
                .Select(i => new FrontContentManagerNuestrosservicio
                {
                    CreatedById = i.CreatedById,
                    CreationDate = i.CreationDate,
                    Descripcion = Funclanguage(i.Descripcion, i.DescripcionEn, i.DescriptionPt, languageId),
                    DescripcionEn = i.DescripcionEn,
                    Id = i.Id,
                    Imagen = i.Imagen,
                    ModificationDate = i.ModificationDate,
                    ModifiedById = i.ModifiedById,
                    Servicio = Funclanguage(i.Servicio, i.ServicioEn, i.ServicioPt, languageId),
                    ServicioEn = i.Servicio,
                    Status = i.Status,
                    Labelourservices = Funclanguage(i.Labelourservices, i.LabelourservicesEn, i.LabelourservicesPt, languageId),
                    MoreInfo = Funclanguage(i.MoreInfo, i.MoreInfoEn, i.MoreInfoPt, languageId),
                    Url = i.Url


                }).ToList();

            return service;
            
        }
    }
}
