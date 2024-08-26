using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentHomeHeaderPostulante
{
    public interface IFrontContentHomeHeaderPostulante: IGenericRepository<biz.matteria.Entities.FrontContentHomeHeaderPostulante>
    {

        biz.matteria.Entities.FrontContentHomeHeaderPostulante GetHeaderHomePostulante(int languajeid);

    }
}
