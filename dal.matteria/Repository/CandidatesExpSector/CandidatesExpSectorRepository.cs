using biz.matteria.Entities;
using biz.matteria.Repository.CandidatesExpSector;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesExpSector
{
    public class CandidatesExpSectorRepository : GenericRepository<biz.matteria.Entities.CandidatesCandidateExpSector>, ICandidatesExpSector
    {
        public CandidatesExpSectorRepository(DbmatteriaContext context) : base(context) { }
        public List<CandidatesCandidateExpSector> getAllCandidatesExpSector(int candidateId)
        {
            var service = _context.CandidatesCandidateExpSectors
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new biz.matteria.Entities.CandidatesCandidateExpSector
                {
                    CandidateId = i.CandidateId,
                    ExpsectorId = i.ExpsectorId,
                    Id = i.Id

                }).ToList();

            return service;

        }
    }
}
