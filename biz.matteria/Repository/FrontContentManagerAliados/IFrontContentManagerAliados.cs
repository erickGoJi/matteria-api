using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManagerAliados
{
    public interface IFrontContentManagerAliados: IGenericRepository<biz.matteria.Entities.FrontContentManagerAliado>
    {
        biz.matteria.Entities.FrontContentManagerAliadosHeader getAliadosHeader(int languajeid);

        List<biz.matteria.Entities.FrontContentManagerAliado> GetAliados(int languajeid);

    }
}
