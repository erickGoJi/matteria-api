using biz.matteria.Entities;
using biz.matteria.Models.FrontContentManager_clientes;
using biz.matteria.Repository.FrontContentManagerClientes;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerClientes
{
    public class FrontContentManagerClientesRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerCliente>, IFrontContentManagerClientes
    {
        public FrontContentManagerClientesRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentManagerClientesService> GetAllClientes(int type)
        {
            //type=1 sector privado, type=2 sector publico

            var service = _context.FrontContentManagerCliente
                .Where(x => x.Type == type)
                .Select(i => new FrontContentManagerClientesService
                {
                    Id = i.Id,
                    Empresa = i.Empresa,
                    Imagen = i.Imagen,
                    ClienteWebsiteUrl = i.ClienteWebsiteUrl,
                    Status = i.Status

                }).ToList();

            return service;
        }

        public FrontContentManagerNuestrosclientesinfo getClientesHeader(int languajeid)
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





            var service = _context.clientesinfo
                .Select(i => new FrontContentManagerNuestrosclientesinfo
                {
                     MensajeImagen = Funclanguage(i.MensajeImagen, i.MensajeImagenEn, i.MensajeImagenPt, languajeid),
                     SectorCivil = Funclanguage(i.SectorCivil, i.SectorCivilEn, i.SectorCivilPt, languajeid),
                     SectorPrivado = Funclanguage(i.SectorPrivado, i.SectorPrivadoEn, i.SectorPrivadoPt, languajeid),


                }).FirstOrDefault();

            return service;
        }
    }
}
