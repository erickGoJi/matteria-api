using biz.matteria.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.matteria.Models.aliados
{
    public class aliadosResponse
    {
        public FrontContentManagerAliadosHeader aliadosHeader { get; set; }
        public List<FrontContentManagerAliado> listAliados { get; set; }



    }
}
