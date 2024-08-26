using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentPoliticasPrivacidad
{
    public interface IFrontContentPoliticasPrivacidad: IGenericRepository<biz.matteria.Entities.FrontContentPoliticasPrivacidad>
    {

        biz.matteria.Entities.FrontContentPoliticasPrivacidad GetPoliticasPrivacidad(int languajeId);
    }
}
