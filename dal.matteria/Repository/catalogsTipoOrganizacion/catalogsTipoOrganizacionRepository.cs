using biz.matteria.Entities;
using biz.matteria.Repository.catalogsTipoOrganizacion;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.catalogsTipoOrganizacion
{
    public class catalogsTipoOrganizacionRepository: GenericRepository<biz.matteria.Entities.CatalogsTipoOrganizacion>, IcatalogsTipoOrganizacion
    {
        public catalogsTipoOrganizacionRepository(DbmatteriaContext context) : base(context) { }

        public List<CatalogsTipoOrganizacion> GetAllTipoOrganizacion(int languageId)
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




            var service = _context.cattipoorganizacion
                .Select(i => new CatalogsTipoOrganizacion
                {
                    Active = i.Active,
                    Id = i.Id,
                    Name = Funclanguage(i.Name, i.NameEn, i.NamePt, languageId),
                    RegistrationDate = i.RegistrationDate


                }).ToList();

            return service;
        }
    }
}
