using biz.matteria.Repository.CandidatesEducation;
using biz.matteria.Repository.Generic;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CandidatesEducation
{
    public class CandidatesEducationRepository: GenericRepository<biz.matteria.Entities.CandidatesEducation>, ICandidatesEducation
    {
        public CandidatesEducationRepository(DbmatteriaContext context) : base(context) { }

        public List<biz.matteria.Entities.CandidatesEducation> GetAllCandidatesEducation(int candidateId)
        {
            var service = _context.CandidatesEducations
                .Where(i => i.CandidateId == candidateId)
                .Select(i => new biz.matteria.Entities.CandidatesEducation
                {
                    ActualStudent = i.ActualStudent,
                    CandidateId = i.CandidateId,
                    City = i.City,
                    CountryId = i.CountryId,
                    CreatedById = i.CreatedById,
                    Discipline = i.Discipline,
                    Grade = i.Grade,
                    GroupAndActivities = i.GroupAndActivities,
                    Id = i.Id,
                    Institution = i.Institution,
                    ProfessionId = i.ProfessionId,
                    StudiedFrom = i.StudiedFrom,
                    StudiedFromMonth = i.StudiedFromMonth,
                    StudiedFromYear = i.StudiedFromYear,
                    StudiedTo = i.StudiedTo,
                    StudiedToMonth = i.StudiedToMonth,
                    StudiedToYear = i.StudiedToYear,
                    UpdatedById = i.UpdatedById,
                    NameProfession = i.NameProfession




                }).ToList();


            return service;

        }
    }
}
