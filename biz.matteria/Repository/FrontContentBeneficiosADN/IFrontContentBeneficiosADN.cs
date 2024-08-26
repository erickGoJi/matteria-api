using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentBeneficiosADN
{
    public interface IFrontContentBeneficiosADN: IGenericRepository<biz.matteria.Entities.FrontContentBeneficiosAdn>
    {

        List<biz.matteria.Entities.FrontContentBeneficiosAdn> GetBeneficiosADN(int languajeId);

    }
}
