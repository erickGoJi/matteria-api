using biz.matteria.Entities;
using biz.matteria.Models.responseCreditos;
using biz.matteria.Repository.Creditos;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.Creditos
{
    public class CreditosRepository : GenericRepository<biz.matteria.Entities.Credito>, ICreditos
    {

        public CreditosRepository(DbmatteriaContext context) : base(context) { }

        public List<Credito> GetCreditosByCompraId(int compraId)
        {
            var service = _context.creditos
                .Where(x => x.IdCompra == compraId)
                .Select(i => new biz.matteria.Entities.Credito
                {
                    CreationDate = i.CreationDate,
                    Id = i.Id,
                    DateHighOpening = i.DateHighOpening,
                    IdCompany = i.IdCompany,
                    IdCompra = i.IdCompra,
                    IdEstatus = i.IdEstatus,
                    IdOpening = i.IdOpening,
                    IdProducto = i.IdProducto


                }).ToList();


            return service;
        }

        public List<biz.matteria.Entities.Credito> GetCreditosVacantes(int companyId)
        {
            var service = _context.creditos
                .Where(x => x.IdCompany == companyId && x.IdOpening == null)
                .Select(i => new biz.matteria.Entities.Credito
                {
                    CreationDate = i.CreationDate,
                    Id = i.Id,
                    DateHighOpening = i.DateHighOpening,
                    IdCompany = i.IdCompany,
                    IdCompra = i.IdCompra,
                    IdEstatus = i.IdEstatus,
                    IdOpening = i.IdOpening,
                    IdProducto = i.IdProducto


                }).ToList() ;


            return service;
        }
    }
}
