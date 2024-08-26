using biz.matteria.Repository.CandidatesLanguage;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesLanguage
{
    public class CandidatesLanguageRepository: GenericRepository<biz.matteria.Entities.CandidatesLanguage>, ICandidatesLanguage
    {
        public CandidatesLanguageRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CandidatesLanguage> GetAllCandidatesLanguage(int candidateId)
        {
            var service = _context.CandidatesLanguages
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new biz.matteria.Entities.CandidatesLanguage
                {
                    CandidateId = i.CandidateId,
                    CreatedById = i.CreatedById,
                    Id = i.Id,
                    LanguageId = i.LanguageId,
                    OralLevel = i.OralLevel,
                    UpdatedById = i.UpdatedById,
                    WrittenLevel = i.WrittenLevel


                }).ToList();

            return service;
        }
    }
}
