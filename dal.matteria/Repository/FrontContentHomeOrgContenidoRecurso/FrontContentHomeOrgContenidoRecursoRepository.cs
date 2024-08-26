using biz.matteria.Repository.FrontContentHomeOrgContenidoRecurso;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHomeOrgContenidoRecurso
{
    public class FrontContentHomeOrgContenidoRecursoRepository : GenericRepository<biz.matteria.Entities.FrontContentHomeOrgContenidoRecurso>, IFrontContentHomeOrgContenidoRecurso
    {

        public FrontContentHomeOrgContenidoRecursoRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.FrontContentHomeOrgContenidoRecurso> GetFrontContentHomeOrgContenidoRecurso(int languajeid)
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





            var service = _context.homeorgcontenidorecurso
                .Select(i => new biz.matteria.Entities.FrontContentHomeOrgContenidoRecurso
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    DateContent = i.DateContent,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    LinkReadMore = i.LinkReadMore,
                    Share = i.Share,
                    Blog = Funclanguage(i.Blog, i.BlogEn, i.BlogPt, languajeid),
                    BlogEn = i.BlogEn,
                    BlogPt = i.BlogPt,
                    ContenidoRecurso = Funclanguage(i.ContenidoRecurso, i.ContenidoRecursoEn, i.ContenidoRecursoPt, languajeid),
                    ContenidoRecursoEn = i.ContenidoRecursoEn,
                    ContenidoRecursoPt = i.ContenidoRecursoPt,
                    LeerMas = Funclanguage(i.LeerMas, i.LeerMasEn, i.LeerMasPt, languajeid),
                    LeerMasEn = i.LeerMasEn,
                    LeerMasPt = i.LeerMasPt

                }).ToList();

            return service;
        }
    }
}
