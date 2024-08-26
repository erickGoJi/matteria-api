using biz.matteria.Repository.FontContentContenidoRecursosBlog;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FontContentContenidoRecursosBlog
{
    public class FontContentContenidoRecursosBlogRepository : GenericRepository<biz.matteria.Entities.FontContentContenidoRecursosBlog>, IFontContentContenidoRecursosBlog
    {

        public FontContentContenidoRecursosBlogRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FontContentContenidoRecursosBlog getFontContenidoRecursosBlog(int languageId=1)
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




            var service = _context.FontContentContenidoRecursosBlogs
                .Select(i => new biz.matteria.Entities.FontContentContenidoRecursosBlog
                {
                    Image = i.Image,
                    Active = i.Active,
                    Description = Funclanguage(i.Description, i.DescriptionEn, i.DescriptionPt, languageId),
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    RegistrationDate = i.RegistrationDate,
                    Title = Funclanguage(i.Title, i.TitleEn, i.TitlePt, languageId),
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt,
                    LeerMas = Funclanguage(i.LeerMas, i.LeerMasEn, i.LeerMasPt, languageId),
                    TitleBlog = Funclanguage(i.TitleBlog, i.TitleBogEn, i.TitleBlogPt, languageId),
                    TitleCosejosOrg = Funclanguage(i.TitleCosejosOrg, i.TitleConsejosOrgEn, i.TitleConsejosOrgPt, languageId),
                    TitleConsejosPostulante = Funclanguage(i.TitleConsejosPostulante, i.TitleConsejosPostulanteEn, i.TitleConsejosPostulantePt, languageId),
                    TitleContenido = Funclanguage(i.TitleContenido, i.TitleContenidoEn, i.TitleContenidoPt, languageId),
                    LblActualidad = Funclanguage(i.LblActualidad, i.LblActualidadEn, i.LblActualidadPt, languageId),
                    TextActualidad = Funclanguage(i.TextActualidad, i.TextActualidadEn, i.TextActualidadPt, languageId)


                }).FirstOrDefault();

            return service;

        }
    }
}
