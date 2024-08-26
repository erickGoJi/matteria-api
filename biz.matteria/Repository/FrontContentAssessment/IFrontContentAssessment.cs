using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentAssessment
{
    public interface IFrontContentAssessment: IGenericRepository<biz.matteria.Entities.FrontContentAssessment>
    {
        biz.matteria.Entities.FrontContentAssessment GetFrontContentAssessmentHeader(int languageId);
    }
}
