using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesWorkandsocialexp
{
    public interface ICandidatesWorkandsocialexp: IGenericRepository<biz.matteria.Entities.CandidatesWorkandsocialexp>
    {

        List<biz.matteria.Entities.CandidatesWorkandsocialexp> getAllCandidatesWorkSocialExp(int candidateId);
    }
}
