using biz.matteria.Models.MenuPrincipal;
using biz.matteria.Repository.MenuPrincipal;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.MenuPrincipal
{
    public class menuPrincipalRepository:GenericRepository<biz.matteria.Entities.MenuPrincipal>, IMenuPrincipal
    {

        public menuPrincipalRepository(DbmatteriaContext context) : base(context) { }

        public List<menuPrincipalResponse> getMenuPrincipal(int languageId)
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




            var service = _context.menuPrincipal
                .Select(i => new menuPrincipalResponse
                {
                    idmenu = i.Id,
                    nombre = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    type = i.Type,
                    menudetalle = i.MenuPrincipalDetalles.Select(x => new biz.matteria.Entities.MenuPrincipalDetalle{  Description = Funclanguage(x.Description, x.DescriptionEn, x.DescriptionPt, languageId),DescriptionEn = x.DescriptionEn,DescriptionPt=x.DescriptionPt,Url = x.Url }).ToList(),
                    url = i.Url
                    



                }).ToList();


            return service;
                

           
        }
    }
}
