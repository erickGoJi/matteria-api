using biz.matteria.Repository.EstatusVacantesProceso;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.EstatusVacantesProceso
{
    public class EstatusVacantesProcesoRepository : GenericRepository<biz.matteria.Entities.EstatusVacantesProceso>, IEstatusVacantesProceso
    {

        public EstatusVacantesProcesoRepository(DbmatteriaContext context) : base(context) { }
        

        List<biz.matteria.Entities.EstatusVacantesProceso> IEstatusVacantesProceso.GetEstatusVacantesProceso()
        {
            var service = _context.statusProceso
                .Select(i => new biz.matteria.Entities.EstatusVacantesProceso
                {
                    Active = i.Active,
                    Id = i.Id,
                    Name = i.Name,
                    Color = i.Color


                }).ToList();

            return service;
        }

        
    }
}
