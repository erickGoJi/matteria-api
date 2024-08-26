using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontComoFuncionaOnboardingHeader
{
    public interface IFrontComoFuncionaOnboardingHeader: IGenericRepository<biz.matteria.Entities.FrontContentManagerComofuncionaHeaderOnboarding>
    {
        biz.matteria.Entities.FrontContentManagerComofuncionaHeaderOnboarding GetComoFuncionaOnboardingHeader();

    }
}
