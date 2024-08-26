using biz.matteria.Repository.openingsOpeningcandidate;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.openingsOpeningCandidate
{
    public class openingsOpeningCandidateRepository : GenericRepository<biz.matteria.Entities.OpeningsOpeningcandidate>, IopeningsOpeningcandidate
    {

        public openingsOpeningCandidateRepository(DbmatteriaContext context) : base(context) { }
    }
}
