using biz.matteria.Entities;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeaderDetail;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontComoFuncionaOnboardingDetail
{
    public class FrontComoFuncionaOnboardingDetailRepository : GenericRepository<biz.matteria.Entities.FrontContentComofuncionaDetailOnboarding>, IFrontComoFuncionaOnboardingHeaderDetail
    {

        public FrontComoFuncionaOnboardingDetailRepository(DbmatteriaContext context) : base(context) { }

        public List<FrontContentComofuncionaDetailOnboarding> GetComoFuncionaOnboardingDetail()
        {
            var service = _context.frontcomofuncionaonboardingDetail
                //.Where(x => x.HeaderonboardingId == frontOnboardingId)
                .Select(i => new FrontContentComofuncionaDetailOnboarding
                {
                    Description = i.Description,
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    HeaderonboardingId = i.HeaderonboardingId,
                    Id = i.Id,
                    Title = i.Title,
                    TitleEn = i.TitleEn,
                    TitlePt = i.TitlePt


                }).ToList();

            return service;
        }
    }
}
