using biz.matteria.Entities;
using biz.matteria.Repository.FrontHeaderOnboarding;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontHeaderOnboarding
{
    public class FrontHeaderOnboardingRepository : GenericRepository<biz.matteria.Entities.FrontContentManagerConsulOnbiardingHeader>, IFrontOnboardingHeader
    {

        public FrontHeaderOnboardingRepository(DbmatteriaContext context) : base(context) { }


        public FrontContentManagerConsulOnbiardingHeader GetContentConultOnboardingHeader()
        {
            var service = _context.frontheaderonboarding
                .Select(i => new FrontContentManagerConsulOnbiardingHeader
                {
                    Active = i.Active,
                    Description = i.Description,
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate,
                    TilePt = i.Title,
                    Title = i.Title,
                    TitleEn = i.TitleEn



                }).FirstOrDefault();

            return service;
        }
    }
}
