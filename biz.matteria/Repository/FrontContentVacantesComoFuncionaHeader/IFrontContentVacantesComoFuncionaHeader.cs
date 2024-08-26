using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentVacantesComoFuncionaHeader
{
    public interface IFrontContentVacantesComoFuncionaHeader: IGenericRepository<biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader>
    {
        biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader GetFrontVacantesComoFuncionaHeader(int languajeId);
    }
}
