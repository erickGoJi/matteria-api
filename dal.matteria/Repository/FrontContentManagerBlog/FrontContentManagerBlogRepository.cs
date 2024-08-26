using biz.matteria.Repository.FrontContentManagerBlog;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerBlog
{
    public class FrontContentManagerBlogRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerBlog>, IFrontContentManagerBlog
    {

        public FrontContentManagerBlogRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.FrontContentManagerBlog> GetFrontManagerBlog(int languajeid, int type)
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



            var service = _context.FrontContentManagerBlogs
                .Where(x => x.Type == type)
                .Select(i => new biz.matteria.Entities.FrontContentManagerBlog
                {
                    ArticuloUrl = i.ArticuloUrl,
                    CreatedById = i.CreatedById,
                    CreationDate = i.CreationDate,
                    Descripcion = Funclanguage(i.Descripcion, i.DescriptionEn, i.DescriptionPt, languajeid),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Imagen = i.Imagen,
                    ModificationDate = i.ModificationDate,
                    ModifiedById = i.ModifiedById,
                    Status = i.Status,
                    Titulo = Funclanguage(i.Titulo, i.TituloEn, i.TituloPt, languajeid),
                    TituloEn = i.TituloEn,
                    TituloPt = i.TituloPt,
                    Type = i.Type,
                    Blog = Funclanguage(i.Blog, i.BlogEn, i.BlogPt, languajeid),
                    ContenidoRecurso = Funclanguage(i.ContenidoRecurso, i.ContenidoRecursoEn, i.ContenidoRecursoPt, languajeid),
                    LeerMas = Funclanguage(i.LeerMas, i.LeerMasEn, i.LeerMasPt, languajeid)


                }).ToList();

            return service;
        }

        

        public biz.matteria.Entities.FrontContentManagerBlog GetFrontManagerBlogById(int languageId, int blogId)
        {
            var service = _context.FrontContentManagerBlogs
                .Where(x => x.Id == blogId)
                .Select(i => new biz.matteria.Entities.FrontContentManagerBlog
                {
                    ArticuloUrl = i.ArticuloUrl,
                    CreatedById = i.CreatedById,
                    CreationDate = i.CreationDate,
                    Descripcion = i.Descripcion,
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Imagen = i.Imagen,
                    ModificationDate = i.ModificationDate,
                    ModifiedById = i.ModifiedById,
                    Status = i.Status,
                    Titulo = i.Titulo,
                    TituloEn = i.TituloEn,
                    TituloPt = i.TituloPt


                }).FirstOrDefault();

            return service;
        }
    }
}
