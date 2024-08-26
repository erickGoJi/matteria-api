using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ProgramaMAIobjectives
{
    public interface IProgramaMAIobjectives: IGenericRepository<biz.matteria.Entities.ProgramaMaiobjective>
    {
        List<biz.matteria.Entities.ProgramaMaiobjective> GetProgramaMAIObjetives(int languajeId);
    }
}
