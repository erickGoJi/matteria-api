using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentObjetivosADNHeader;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentObjetivosADNHeader
{
    public class FrontContentObjetivosADNHeaderRepository : GenericRepository<biz.matteria.Entities.FrontContentObjetivosAdnHeader>, IFrontContentObjetivosADNHeader
    {
        public FrontContentObjetivosADNHeaderRepository(DbmatteriaContext context) : base(context) { }
        public FrontContentObjetivosAdnHeader GetHeaderObjetivosADN()
        {
            var service = _context.FrontContentObjetivosAdnHeaders
                .Select(i => new FrontContentObjetivosAdnHeader
                {

                    Active = i.Active,
                    Id = i.Id,
                    Image = i.Image,
                    RegistrationDate = i.RegistrationDate

                }).FirstOrDefault();

            return service;
        }
    }
}
