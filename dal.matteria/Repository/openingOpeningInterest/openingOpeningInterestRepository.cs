using biz.matteria.Repository.openingOpeningInterest;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.openingOpeningInterest
{
    public class openingOpeningInterestRepository : GenericRepository<biz.matteria.Entities.OpeningsOpeningInterest>, IopeningOpeningInterest
    {

        public openingOpeningInterestRepository(DbmatteriaContext context) : base(context) { }
    }
}
