using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontHeaderOnboarding
{
    public interface IFrontOnboardingHeader: IGenericRepository<biz.matteria.Entities.FrontContentManagerConsulOnbiardingHeader>
    {

        biz.matteria.Entities.FrontContentManagerConsulOnbiardingHeader GetContentConultOnboardingHeader();


    }
}
