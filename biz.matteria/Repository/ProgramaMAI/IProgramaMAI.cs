using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ProgramaMAI
{
    public interface IProgramaMAI: IGenericRepository<biz.matteria.Entities.ProgramaMai>
    {
        biz.matteria.Entities.ProgramaMai GetProgramaMAI(int languajeId);

    }
}
