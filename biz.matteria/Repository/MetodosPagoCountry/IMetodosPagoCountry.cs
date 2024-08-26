using biz.matteria.Models.MetodosPagoCountry;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.MetodosPagoCountry
{
    public interface IMetodosPagoCountry: IGenericRepository<biz.matteria.Entities.MetodosPagosCountry>
    {

        List<MetodosPagoCountryModel> GetMetodosPagoCountry();

        List<biz.matteria.Entities.MetodosPago> GetMetodosPago();
    }
}
