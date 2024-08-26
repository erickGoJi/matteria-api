using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentManagerEquipo;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerEquipo
{
    public class FrontContentManagerEquipoRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerEquipo>, IFrontContentManagerEquipo
    {
        public FrontContentManagerEquipoRepository(DbmatteriaContext context) : base(context) { }

        public biz.matteria.Entities.FrontContentManagerEquipoHeader GetEquipoHeader(int languajeid)
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




            var service = _context.equipoHeader
                .Where(x => x.Active == true)
                .Select(i => new biz.matteria.Entities.FrontContentManagerEquipoHeader
                {
                    Active = i.Active,
                    CreatinDate = i.CreatinDate,
                    Id = i.Id,
                    Phrase = Funclanguage(i.Phrase, i.PhraseEn, i.PhrasePt, languajeid),
                     NuestroEquipo = Funclanguage(i.NuestroEquipo, i.NuestroEquipoEn, i.NuestroEquipoPt, languajeid)

                }).FirstOrDefault();

            return service;
            
        }

        public List<biz.matteria.Entities.FrontContentManagerEquipo> GetFrontContentEquipo(int languageId)
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








            var service = _context.FrontContentManagerEquipos
                .Select(i => new biz.matteria.Entities.FrontContentManagerEquipo
                {
                    CreatedById = i.CreatedById,
                    CreationDate = i.CreationDate,
                    Descripcion = Funclanguage(i.Descripcion,i.DescripcionEn,i.DescriptionPt,languageId),
                    DescripcionEn = i.DescripcionEn,
                    DescriptionPt=i.DescriptionPt,
                    Id = i.Id,
                    Imagen = i.Imagen,
                    Linkedin = i.Linkedin,
                    ModificationDate = i.ModificationDate,
                    ModifiedById = i.ModifiedById,
                    Nombre = i.Nombre,
                    Puesto = Funclanguage(i.Puesto, i.PuestoEn, i.PuestoPt, languageId),
                    PuestoEn = i.PuestoEn,
                    PuestoPt=i.PuestoPt,
                    Status = i.Status



                }).ToList();


            return service;
        }
    }
}
