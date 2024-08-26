using biz.matteria.Repository.FrontContentHomeGeneral;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentHomeGeneral
{
    public class FrontContentHomeGeneralRepository : GenericRepository<biz.matteria.Entities.FrontContentHomeGeneral>, IFrontContentHomeGeneral
    {


        public FrontContentHomeGeneralRepository(DbmatteriaContext context) : base(context) { }
        public biz.matteria.Entities.FrontContentHomeGeneral GetHomeGeneral(int languajeid)
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








            var service = _context.homeGeneral
                .Select(i => new biz.matteria.Entities.FrontContentHomeGeneral
                {
                    Active = i.Active,
                    CreationDate = i.CreationDate,
                    Id = i.Id,
                    ImageOrganizacion = i.ImageOrganizacion,
                    ImagePostulante = i.ImagePostulante,
                    LinkMoreOrganizacion = i.LinkMoreOrganizacion,
                    LinkMorePostulante = i.LinkMorePostulante,
                    Video = i.Video,
                    BtnOrganizacionText = Funclanguage(i.BtnOrganizacionText, i.BtnOrganizacionTextEn, i.BtnOrganizacionTextPt, languajeid),
                    BtnOrganizacionTextEn = i.BtnOrganizacionTextEn,
                    BtnOrganizacionTextPt = i.BtnOrganizacionTextPt,
                    BtnPostulanteText = Funclanguage(i.BtnPostulanteText, i.BtnPostulanteTextEn, i.BtnPostulanteTextPt, languajeid),
                    BtnPostulanteTextEn = i.BtnPostulanteTextEn,
                    BtnPostulanteTextPt = i.BtnPostulanteTextPt,
                    Labelimageorganizacion = Funclanguage(i.Labelimageorganizacion, i.LabelimageorganizacionEn, i.LabelimageorganizacionPt, languajeid),
                    LabelimageorganizacionEn = i.LabelimageorganizacionEn,
                    LabelimageorganizacionPt = i.LabelimageorganizacionPt,
                    LabelimagePostulante = Funclanguage(i.LabelimagePostulante, i.LabelimagePostulanteEn, i.LabelimagePostulantePt, languajeid),
                    LabelimagePostulanteEn = i.LabelimagePostulanteEn,
                    LabelimagePostulantePt = i.LabelimagePostulantePt


                }).FirstOrDefault();

            return service;
        }
    }
}
