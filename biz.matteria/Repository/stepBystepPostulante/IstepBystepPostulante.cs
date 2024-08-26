using biz.matteria.Models.stepBystepPostulante;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.stepBystepPostulante
{
    public interface IstepBystepPostulante: IGenericRepository<biz.matteria.Entities.StepByStepPostulant>
    {
        List<ResponsestepbystepPostulante> getstepByStepPostulantConfiguration(int languageId);

    }
}
