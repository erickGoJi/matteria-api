using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesLanguage
{
    public interface ICandidatesLanguage: IGenericRepository<biz.matteria.Entities.CandidatesLanguage>
    {
        List<biz.matteria.Entities.CandidatesLanguage> GetAllCandidatesLanguage(int candidateId);
    }
}
