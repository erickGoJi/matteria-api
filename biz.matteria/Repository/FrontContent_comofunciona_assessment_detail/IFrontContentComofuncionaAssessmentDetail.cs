using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContent_comofunciona_assessment_detail
{
    public interface IFrontContentComofuncionaAssessmentDetail: IGenericRepository<biz.matteria.Entities.FrontContentComofuncionaAssessmentDetail>
    {
        List<biz.matteria.Entities.FrontContentComofuncionaAssessmentDetail> GetFrontComoFuncionaAssessmentDetail();
    }
}
