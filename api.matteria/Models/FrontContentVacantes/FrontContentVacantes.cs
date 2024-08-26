using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.FrontContentVacantes
{
    public class FrontContentVacantes
    {
       public  List<biz.matteria.Entities.FrontContentVacantesComoFunciona> comofunciona { get; set; }

        public biz.matteria.Entities.FrontContentVacantesComoFuncionaHeader comofuncionaHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentVacantesComoPublicar> comoPublicar { get; set; }

        public biz.matteria.Entities.FrontContentVacantesHeader vacantesHeader { get; set; }

        public List<biz.matteria.Entities.FrontContentVacantesPaquete> vacantesPaquetes { get; set; }



    }
}
