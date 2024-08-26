using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesEducation
{
    public interface ICandidatesEducation: IGenericRepository<biz.matteria.Entities.CandidatesEducation>
    {
        List<biz.matteria.Entities.CandidatesEducation> GetAllCandidatesEducation(int candidateId);

    }
}
