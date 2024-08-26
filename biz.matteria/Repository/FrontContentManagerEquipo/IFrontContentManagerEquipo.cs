using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManagerEquipo
{
    public interface IFrontContentManagerEquipo: IGenericRepository<biz.matteria.Entities.FrontContentManagerEquipo>
    {


        biz.matteria.Entities.FrontContentManagerEquipoHeader GetEquipoHeader(int languajeid);
        List<biz.matteria.Entities.FrontContentManagerEquipo> GetFrontContentEquipo(int languageId);
    }
}
