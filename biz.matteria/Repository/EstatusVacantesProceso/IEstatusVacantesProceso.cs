using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.EstatusVacantesProceso
{
    public interface IEstatusVacantesProceso: IGenericRepository<biz.matteria.Entities.EstatusVacantesProceso>
    {
        List<biz.matteria.Entities.EstatusVacantesProceso> GetEstatusVacantesProceso();
    }
}
