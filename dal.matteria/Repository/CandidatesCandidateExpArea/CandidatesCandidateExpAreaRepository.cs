using biz.matteria.Repository.CandidatesCandidateExpArea;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesCandidateExpArea
{
    public class CandidatesCandidateExpAreaRepository: GenericRepository<biz.matteria.Entities.CandidatesCandidateExpArea>, ICandidatesCandidateExpArea
    {
        public CandidatesCandidateExpAreaRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CandidatesCandidateExpArea> GetCandidateExpAreByCandidateId(int candidateId)
        {
            var service = _context.CandidatesCandidateExpAreas
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new biz.matteria.Entities.CandidatesCandidateExpArea
                {
                     CandidateId = i.CandidateId,
                      ExpareaId = i.ExpareaId,
                       Id = i.Id

                }).ToList();

            return service;
        }
    }
}
