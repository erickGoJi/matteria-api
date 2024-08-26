using biz.matteria.Repository.CandidatesCandidateInterest;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesCandidateInterest
{
    public class CandidatesCandidateInterestRepository: GenericRepository<biz.matteria.Entities.CandidatesCandidateInterest>, ICandidatesCandidateInterest
    {
        public CandidatesCandidateInterestRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CandidatesCandidateInterest> GetCandidateInterestByCandidateId(int canditateId)
        {
            var service = _context.CandidatesCandidateInterests
                .Where(i => i.CandidateId == canditateId)
                .Select(i => new biz.matteria.Entities.CandidatesCandidateInterest
                {
                    CandidateId = i.CandidateId,
                    Id = i.Id,
                    InterestId = i.InterestId


                }).ToList();

            return service;
        }
    }
}
