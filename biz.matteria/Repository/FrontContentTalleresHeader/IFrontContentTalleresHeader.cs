using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentTalleresHeader
{
    public interface IFrontContentTalleresHeader: IGenericRepository<biz.matteria.Entities.FrontContentTalleresHeader>
    {

        biz.matteria.Entities.FrontContentTalleresHeader GetFrontTalleresHead(int languajeId);

    }
}
