using biz.matteria.Entities;
using biz.matteria.Repository.FrontComoFuncionaOnboardingHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontComoFuncionaOnboardingHeader
{
    public class FrontComoFuncionaOnboardingHeaderRepository: GenericRepository<biz.matteria.Entities.FrontContentManagerComofuncionaHeaderOnboarding>, IFrontComoFuncionaOnboardingHeader
    {
        public FrontComoFuncionaOnboardingHeaderRepository(DbmatteriaContext context) : base(context) { }

        public FrontContentManagerComofuncionaHeaderOnboarding GetComoFuncionaOnboardingHeader()
        {
            var service = _context.frontcomofuncionaonboarding
                .Select(i => new FrontContentManagerComofuncionaHeaderOnboarding
                {
                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegisterDate = i.RegisterDate


                }).FirstOrDefault();

            return service;
        }
    }

}
