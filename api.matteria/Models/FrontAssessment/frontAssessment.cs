using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontAssessment
{
    public class frontAssessment
    {
        public FrontContentAssessment frontheaderassessment { get; set; }

        public List<FrontContentComofuncionaAssessment> frontcomofuncionaAssesment { get; set; }

        public List<FrontContentComofuncionaAssessmentDetail> frontcomofuncionaAssessmentDetail { get; set; }


    }
}
