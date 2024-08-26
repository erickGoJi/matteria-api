using biz.matteria.Repository.Pagos;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.Pagos
{
    public class PagosRepository: GenericRepository<biz.matteria.Entities.Pago>, IPagos
    {
        public PagosRepository(DbmatteriaContext context) : base(context) { }
    }
}
