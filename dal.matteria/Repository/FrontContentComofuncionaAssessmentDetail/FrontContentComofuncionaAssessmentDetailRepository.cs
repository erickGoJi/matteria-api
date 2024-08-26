using biz.matteria.Repository.FrontContent_comofunciona_assessment_detail;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentComofuncionaAssessmentDetail
{
    public class FrontContentComofuncionaAssessmentDetailRepository : GenericRepository<biz.matteria.Entities.FrontContentComofuncionaAssessmentDetail>, IFrontContentComofuncionaAssessmentDetail
    {

        public FrontContentComofuncionaAssessmentDetailRepository(DbmatteriaContext context) : base(context) { }
        public List<biz.matteria.Entities.FrontContentComofuncionaAssessmentDetail> GetFrontComoFuncionaAssessmentDetail()
        {
            var service = _context.FrontContentComofuncionaAssessmentsDetails
                .Select(i => new biz.matteria.Entities.FrontContentComofuncionaAssessmentDetail
                {
                    Id = i.Id,
                    ComoAssessmentId = i.ComoAssessmentId,
                    Description = i.Description
                    

                }).ToList();

            return service;
        }
    }
}
