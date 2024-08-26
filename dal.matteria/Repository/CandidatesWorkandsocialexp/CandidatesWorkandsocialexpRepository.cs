using biz.matteria.Repository.CandidatesWorkandsocialexp;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesWorkandsocialexp
{
    public class CandidatesWorkandsocialexpRepository: GenericRepository<biz.matteria.Entities.CandidatesWorkandsocialexp>, ICandidatesWorkandsocialexp
    {
        public CandidatesWorkandsocialexpRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CandidatesWorkandsocialexp> getAllCandidatesWorkSocialExp(int candidateId)
        {
            var service = _context.CandidatesWorkandsocialexps
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new biz.matteria.Entities.CandidatesWorkandsocialexp
                {
                    Id = i.Id,
                    ActualJob = i.ActualJob,
                    CandidateId = i.CandidateId,
                    City = i.City,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    Description = i.Description,
                    Name = i.Name,
                    PositiveImpact = i.PositiveImpact,
                    Title = i.Title,
                    UpdatedById = i.UpdatedById,
                    WorkFrom = i.WorkFrom,
                    WorkFromMonth = i.WorkFromMonth,
                    WorkFromYear = i.WorkFromYear,
                    WorkTo = i.WorkTo,
                    WorkToMonth = i.WorkToMonth,
                    WorkToYear = i.WorkToYear,
                    Volunteering = i.Volunteering

                }).ToList();

            return service;
        }
    }
}
