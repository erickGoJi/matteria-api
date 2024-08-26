using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesCandidateInterest
{
    public interface ICandidatesCandidateInterest: IGenericRepository<biz.matteria.Entities.CandidatesCandidateInterest>
    {
        List<biz.matteria.Entities.CandidatesCandidateInterest> GetCandidateInterestByCandidateId(int canditateId);
    }
}
