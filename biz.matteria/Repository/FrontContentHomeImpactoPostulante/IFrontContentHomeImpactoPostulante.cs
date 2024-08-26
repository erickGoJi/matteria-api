using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHomeImpactoPostulante
{
    public interface IFrontContentHomeImpactoPostulante: IGenericRepository<biz.matteria.Entities.FrontContentHomeImpactoPostulante>
    {

        biz.matteria.Entities.FrontContentHomeImpactoPostulante GetHomeImpactoPostulante(int languajeid);
    }
}
