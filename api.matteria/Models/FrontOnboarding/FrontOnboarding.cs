using dal.matteria.Repository.FrontComoFuncionaOnboardingDetail;
using dal.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using dal.matteria.Repository.FrontHeaderOnboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontOnboarding
{
    public class FrontOnboarding
    {
        public biz.matteria.Entities.FrontContentManagerConsulOnbiardingHeader headOnboardingfront { get; set; }

        public biz.matteria.Entities.FrontContentManagerComofuncionaHeaderOnboarding frontcomofuncionaOnboarding { get; set; }
        public List<biz.matteria.Entities.FrontContentComofuncionaDetailOnboarding> frontcomofuncionaOnboardingdetail { get; set; }


    }
}
