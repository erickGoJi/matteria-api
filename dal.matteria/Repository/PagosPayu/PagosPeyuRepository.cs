using biz.matteria.Repository.PagosPayu;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.PagosPayu
{
    public class PagosPeyuRepository: GenericRepository<biz.matteria.Entities.PagosPeyu>, IPagosPayu
    {

        public PagosPeyuRepository(DbmatteriaContext context) : base(context) { }
    }
}
