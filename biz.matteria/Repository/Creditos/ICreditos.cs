using biz.matteria.Models.responseCreditos;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.Creditos
{
    public interface ICreditos: IGenericRepository<biz.matteria.Entities.Credito>
    {

        List<biz.matteria.Entities.Credito> GetCreditosVacantes(int companyId);

        List<biz.matteria.Entities.Credito> GetCreditosByCompraId(int compraId);
    }
}
