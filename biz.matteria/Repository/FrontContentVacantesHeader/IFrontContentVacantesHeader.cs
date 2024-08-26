using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentVacantesHeader
{
    public interface IFrontContentVacantesHeader: IGenericRepository<biz.matteria.Entities.FrontContentVacantesHeader>
    {

        biz.matteria.Entities.FrontContentVacantesHeader GetFrontVacantesHeader(int languajeId);


    }
}
