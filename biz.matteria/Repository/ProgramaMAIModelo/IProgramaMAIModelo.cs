using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.ProgramaMAIModelo
{
    public interface IProgramaMAIModelo: IGenericRepository<biz.matteria.Entities.ProgramaMaimodelo>
    {

        List<biz.matteria.Entities.ProgramaMaimodelo> GetProrgramaMAIModelo(int languajeId);

    }
}
