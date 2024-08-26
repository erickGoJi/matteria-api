using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesCandidateExpArea
{
    public interface ICandidatesCandidateExpArea: IGenericRepository<biz.matteria.Entities.CandidatesCandidateExpArea>
    {

        List<biz.matteria.Entities.CandidatesCandidateExpArea> GetCandidateExpAreByCandidateId(int candidateId);
    }
}
