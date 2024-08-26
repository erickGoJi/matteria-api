using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentVacantesComoPublicar
{
    public interface IFrontContentVacantesComoPublicar: IGenericRepository<biz.matteria.Entities.FrontContentVacantesComoPublicar>
    {
        List<biz.matteria.Entities.FrontContentVacantesComoPublicar> GetFrontVacantesComoPublicar(int languajeId);
    }
}
