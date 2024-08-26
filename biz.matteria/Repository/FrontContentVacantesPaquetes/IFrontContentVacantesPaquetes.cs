using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentVacantesPaquetes
{
    public interface IFrontContentVacantesPaquetes: IGenericRepository<biz.matteria.Entities.FrontContentVacantesPaquete>
    {
        List<biz.matteria.Entities.FrontContentVacantesPaquete> GetFrontVacantesPaquetes(int languajeId);

        List<biz.matteria.Models.paquetes.paquetes> GetPaquetes(string codeCountry,int languajeId);


        biz.matteria.Entities.FrontContentVacantesPaquete GetFrontVacantesPaquetesById(int paqueteId);


    }
}
