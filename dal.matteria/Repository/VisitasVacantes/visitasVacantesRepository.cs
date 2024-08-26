using biz.matteria.Repository.visitasVacantes;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.VisitasVacantes
{
    public class visitasVacantesRepository: GenericRepository<biz.matteria.Entities.VisitasVacante>, IvisitasVacantes
    {

        public visitasVacantesRepository(DbmatteriaContext context) : base(context) { }

    }
}
