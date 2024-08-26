using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesExpSector
{
    public interface ICandidatesExpSector: IGenericRepository<biz.matteria.Entities.CandidatesCandidateExpSector>
    {
        List<biz.matteria.Entities.CandidatesCandidateExpSector> getAllCandidatesExpSector(int candidateId);
    }
}
