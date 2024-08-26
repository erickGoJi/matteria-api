using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentVacantesComoFunciona
{
    public interface IFrontContentVacantesComoFunciona: IGenericRepository<biz.matteria.Entities.FrontContentVacantesComoFunciona>
    {
        List<biz.matteria.Entities.FrontContentVacantesComoFunciona> GetFrontVacantesComoFunciona(int languajeId);
    }
}
