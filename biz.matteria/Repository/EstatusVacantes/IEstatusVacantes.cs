using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.EstatusVacantes
{
    public interface IEstatusVacantes: IGenericRepository<biz.matteria.Entities.EstatusVacante>
    {

        List<biz.matteria.Entities.EstatusVacante> GetEstatusVacantes();

        
    }
}
