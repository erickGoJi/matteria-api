using biz.matteria.Repository.PagosPayPal;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.PagosPayPal
{
    public class PagosPayPalRepository: GenericRepository<biz.matteria.Entities.PagosPayPal>, IPagosPayPal
    {


        public PagosPayPalRepository(DbmatteriaContext context) : base(context) { }
    }
}
