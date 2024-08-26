using biz.matteria.Entities;
using biz.matteria.Repository.FrontContentObjetivosADN;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.FrontContentObjetivosADN
{
    public class FrontContentObjetivosADNRepository : GenericRepository<biz.matteria.Entities.FrontContentObjetivosAdn>, IFrontContentObjetivosADN
    {

        public FrontContentObjetivosADNRepository(DbmatteriaContext context) : base(context) { }
        public List<FrontContentObjetivosAdn> GetObjetivosADN()
        {
            var service = _context.FrontContentObjetivosAdns
                .Select(i => new FrontContentObjetivosAdn
                {
                    Active = i.Active,
                    AdbobjetivosheaderId = i.AdbobjetivosheaderId,
                    Description = i.Description,
                    DescriptionEn = i.DescriptionEn,
                    DescriptionPt = i.DescriptionPt,
                    Id = i.Id,
                    RegistrationDate = i.RegistrationDate

                }).ToList();

            return service;

        }
    }
}
