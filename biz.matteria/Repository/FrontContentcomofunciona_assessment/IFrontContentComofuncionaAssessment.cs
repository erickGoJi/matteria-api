using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentcomofunciona_assessment
{
    public interface IFrontContentComofuncionaAssessment: IGenericRepository<biz.matteria.Entities.FrontContentComofuncionaAssessment>
    {
        List<biz.matteria.Entities.FrontContentComofuncionaAssessment> GetFrontContentcomofuncionaAssesment(int languageId);



    }
}
