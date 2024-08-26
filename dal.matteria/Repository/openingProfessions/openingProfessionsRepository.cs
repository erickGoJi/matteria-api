using biz.matteria.Entities;
using biz.matteria.Repository.OpeningProfessions;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.openingProfessions
{
    public class openingProfessionsRepository : GenericRepository<biz.matteria.Entities.OpeningsOpeningProfession>, IopeningProfessions
    {
        public openingProfessionsRepository(DbmatteriaContext context) : base(context) { }
        public List<OpeningsOpeningProfession> openingsOpeningProfessions(int openingId)
        {
            var service = _context.OpeningProfessions
                .Where(x => x.OpeningId == openingId)
                .Select(i => new OpeningsOpeningProfession
                {
                    Id = i.Id,
                    OpeningId = i.OpeningId,
                    ProfessionId = i.ProfessionId

                }).ToList();

            return service;
        }
    }
}
