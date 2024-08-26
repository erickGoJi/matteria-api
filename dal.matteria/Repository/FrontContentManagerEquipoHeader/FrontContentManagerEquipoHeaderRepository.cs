using biz.matteria.Repository.FrontContentManagerEquipoHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.FrontContentManagerEquipoHeader
{
    public class FrontContentManagerEquipoHeaderRepository: GenericRepository<biz.matteria.Entities.FrontContentManagerEquipoHeader>, IFrontContentManagerEquipoHeader
    {

        public FrontContentManagerEquipoHeaderRepository(DbmatteriaContext context) : base(context) { }
    }
}
