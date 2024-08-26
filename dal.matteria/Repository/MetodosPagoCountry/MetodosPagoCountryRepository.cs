using biz.matteria.Entities;
using biz.matteria.Models.MetodosPagoCountry;
using biz.matteria.Repository.MetodosPagoCountry;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.MetodosPagoCountry
{
    public class MetodosPagoCountryRepository : GenericRepository<biz.matteria.Entities.MetodosPagosCountry>, IMetodosPagoCountry
    {

        public MetodosPagoCountryRepository(DbmatteriaContext context) : base(context) { }

        public List<MetodosPago> GetMetodosPago()
        {
            var service = _context.metodopago
                .Where(j => j.Active == true)
                .Select(i => new MetodosPago
                {
                    Active = i.Active,
                    Id = i.Id,
                    Name = i.Name,
                    Prefix = i.Prefix,
                    RegistrationDate = i.RegistrationDate


                }).ToList();

            return service;
        }

        public List<MetodosPagoCountryModel> GetMetodosPagoCountry()
        {
            var service = _context.CatalogsCountrys
                .Select(i => new MetodosPagoCountryModel
                {
                    country = i.Name,
                    countryImage = i.Image,
                    Id = i.Id,
                    listMetodosPago = (from mpc in _context.metodopagocountry
                                       join mp in _context.metodopago on mpc.MetodoPagoId equals mp.Id
                                       where mpc.CountryId == i.Id && mp.Active == true
                                       select mp).ToList()


                }).ToList();

            return service;
            
        }
    }
}
