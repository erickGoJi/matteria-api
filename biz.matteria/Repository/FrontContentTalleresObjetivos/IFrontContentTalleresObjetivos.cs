using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentTalleresObjetivos
{
    public interface IFrontContentTalleresObjetivos: IGenericRepository<biz.matteria.Entities.FrontContentTalleresObjetivo>
    {
        List<biz.matteria.Entities.FrontContentTalleresObjetivo> GetFrontTalleresObjetivos(int languajeId);

    }
}
