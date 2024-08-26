using biz.matteria.Entities;
using biz.matteria.Repository.EstatusVacantes;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.EstatusVacantes
{
    public class EstatusVacantesRepository : GenericRepository<biz.matteria.Entities.EstatusVacante>, IEstatusVacantes
    {
        public EstatusVacantesRepository(DbmatteriaContext context) : base(context) { }
        public List<EstatusVacante> GetEstatusVacantes() //1:estatus vacante 2:estatus del proceso
        {
            var service = _context.estatusvacantes
                .Select(i => new EstatusVacante
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
