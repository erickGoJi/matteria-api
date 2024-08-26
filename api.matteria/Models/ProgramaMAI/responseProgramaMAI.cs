using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.ProgramaMAI
{
    public class responseProgramaMAI
    {
        public biz.matteria.Entities.ProgramaMai prorgramaMAI { get; set; }

        public List<biz.matteria.Entities.ProgramaMaiobjective> prorgramaMAIObjectives { get; set; }

        public List<biz.matteria.Entities.ProgramaMaimodelo> programaMAIModelo { get; set; }
    }
}
