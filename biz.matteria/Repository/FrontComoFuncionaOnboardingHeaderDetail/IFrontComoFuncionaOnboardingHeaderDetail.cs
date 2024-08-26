using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontComoFuncionaOnboardingHeaderDetail
{
    public interface IFrontComoFuncionaOnboardingHeaderDetail: IGenericRepository<biz.matteria.Entities.FrontContentComofuncionaDetailOnboarding>
    {

        

        List<biz.matteria.Entities.FrontContentComofuncionaDetailOnboarding> GetComoFuncionaOnboardingDetail();
    }
}
