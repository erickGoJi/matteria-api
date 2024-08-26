using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.stepBystepPostulante
{
    public class ResponsestepbystepPostulante
    {

        public int stepId { get; set; }

        public string step { get; set; }

        public string name { get; set; }

        public ICollection<biz.matteria.Entities.StepByStepPostulantDetail> stepbystepDetail { get; set; }

    }
}
