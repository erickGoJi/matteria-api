using biz.matteria.Models.comprasadmin;
using biz.matteria.Repository.CompraPaquetes;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dal.matteria.Repository.CompraPaquetes
{
    public class CompraPaquetesRepository: GenericRepository<biz.matteria.Entities.ComprasPaquete>, ICompraPaquetes
    {
        public CompraPaquetesRepository(DbmatteriaContext context) : base(context) { }

        public comprasDetalleAdmin GetCompraById(int compraId)
        {
            var service = _context.compraPaquete
                .Where(x => x.MetodoPagoId != null && x.Id == compraId)
                .Select(i => new comprasDetalleAdmin
                {
                    id = i.Id,
                    title = i.IdProductoNavigation.Title,
                    numberCredits = i.IdProductoNavigation.NumberCredits,
                    consumidos = (from cr in _context.creditos
                                  where cr.IdOpening != null && cr.IdCompra == i.Id
                                  select cr.IdOpening).Count(),
                    disponibles = i.IdProductoNavigation.NumberCredits - (from cr in _context.creditos
                                                                          where cr.IdOpening != null && cr.IdCompra == i.Id
                                                                          select cr.IdOpening).Count(),
                    fechaCompra = i.CreationDate,
                    metodoPago = i.MetodoPago.Name,
                     company = (from cm in i.Creditos
                                join em in _context.company on cm.IdCompany  equals em.Id
                                where cm.IdCompra == i.Id
                                select em.Name).FirstOrDefault(),
                      vacantes =(from cm in i.Creditos
                                 join op in _context.OpeningsOpenings on cm.IdOpening equals op.Id
                                 where cm.IdCompra == i.Id
                                 select op).ToList()



                }).FirstOrDefault();

            return service;

        }

        public comprasAdminRpt getComprasAdminRpt(int companyId, int metodoPagoId, string fechaInicial, string FechaFinal, int paisId, int productoId,string ciudad)
        {
            int numeroCompradores = 0;
            int sumaDisponibles = 0;
            int sumaCreditos = 0;
            decimal sumaMonto = 0;
            int avisoFull = 0;
            int paquete3 = 0;
            comprasAdminRpt modelResponse = new comprasAdminRpt();

            var service = _context.compraPaquete
                .Where(x => x.MetodoPagoId != null)
                .Where(b => b.CreationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.CreationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(e => productoId == 0 || e.IdProducto == productoId)
                .Where(k => metodoPagoId == 0 || k.MetodoPagoId == metodoPagoId)
                .Where(j => companyId == 0 || j.Creditos.Where(jj => jj.IdCompany == companyId).FirstOrDefault().IdCompany == companyId)
                .Where(l => paisId == 0 || l.User.CompaniesCompanyUsers.Where(j => j.CountryId == paisId).FirstOrDefault().CountryId == paisId)
                .Where(m => string.IsNullOrEmpty(ciudad) || m.User.CompaniesCompanyUsers.Where(j => j.City == ciudad).FirstOrDefault().City == ciudad)
                .Select(i => new comprasAdmin
                {
                    id = i.Id,
                    title = i.IdProductoNavigation.Title,
                    numberCredits = i.IdProductoNavigation.NumberCredits,
                    consumidos = (from cr in _context.creditos
                                  where cr.IdOpening != null && cr.IdCompra == i.Id
                                  select cr.IdOpening).Count(),
                    disponibles = i.IdProductoNavigation.NumberCredits - (from cr in _context.creditos
                                                                          where cr.IdOpening != null && cr.IdCompra == i.Id
                                                                          select cr.IdOpening).Count(),
                    fechaCompra = i.CreationDate,
                    metodoPago = i.MetodoPago.Name,
                    monto = i.IdProductoNavigation.PackagePrice,
                    nameCompany = (from cr in _context.creditos
                                   join comp in _context.company on cr.IdCompany equals comp.Id
                                   where cr.IdCompra == i.Id
                                   select comp.Name).SingleOrDefault(),
                    logo = (from cr in _context.creditos
                            join comp in _context.company on cr.IdCompany equals comp.Id
                            where cr.IdCompra == i.Id
                            select comp.Logo).SingleOrDefault(),
                    paquete = i.IdProductoNavigation.Id


                }).ToList();



            foreach(var item in service)
            {
                sumaCreditos += item.numberCredits;
                sumaDisponibles += item.disponibles;
                sumaMonto += item.monto;
            }

            avisoFull = service.Where(x => x.paquete == 1).Count();
            paquete3 = service.Where(z => z.paquete == 2).Count();

            if(service.Count() > 0)
            {
                numeroCompradores = service.GroupBy(y => y.nameCompany).Count();
            }
            

            modelResponse.totalCompras = service.Count();
            modelResponse.creditosDisponibles =  sumaDisponibles.ToString() + "/" + sumaCreditos.ToString();
            modelResponse.ingresoUsd = sumaMonto;
            modelResponse.numCompradores = numeroCompradores;
            modelResponse.paquetemascomprado = avisoFull > paquete3 ? "Aviso Full" : "Paquete de 3 Avisos";



            return modelResponse;

        }

        public List<comprasAdmin> getComprasAdmin(int companyId, int metodoPagoId, string fechaInicial, string FechaFinal, int paisId, int productoId,string ciudad)
        {


            var service = _context.compraPaquete
                .Where(x => x.MetodoPagoId != null)
                .Where(b => b.CreationDate.Date >= Convert.ToDateTime(fechaInicial).Date && b.CreationDate.Date <= Convert.ToDateTime(FechaFinal).Date)
                .Where(e => productoId == 0 || e.IdProducto == productoId)
                .Where(k => metodoPagoId == 0 || k.MetodoPagoId == metodoPagoId)
                .Where(j => companyId == 0 || j.Creditos.Where(jj => jj.IdCompany == companyId).FirstOrDefault().IdCompany == companyId)
                .Where(l => paisId == 0 || l.User.CompaniesCompanyUsers.Where(j => j.CountryId == paisId).FirstOrDefault().CountryId == paisId)
                .Where(m => string.IsNullOrEmpty(ciudad) || m.User.CompaniesCompanyUsers.Where(j => j.City == ciudad).FirstOrDefault().City == ciudad)
                .Select(i => new comprasAdmin
                {
                    id = i.Id,
                    title = i.IdProductoNavigation.Title,
                    numberCredits = i.IdProductoNavigation.NumberCredits,
                    consumidos = (from cr in _context.creditos
                                  where cr.IdOpening != null && cr.IdCompra == i.Id
                                  select cr.IdOpening).Count(),
                    disponibles = i.IdProductoNavigation.NumberCredits - (from cr in _context.creditos
                                                                          where cr.IdOpening != null && cr.IdCompra == i.Id
                                                                          select cr.IdOpening).Count(),
                    fechaCompra = i.CreationDate,
                    metodoPago = i.MetodoPago.Name,
                    monto = i.IdProductoNavigation.PackagePrice,
                    nameCompany = (from cr in _context.creditos
                                   join comp in _context.company on cr.IdCompany equals comp.Id
                                   where cr.IdCompra == i.Id
                                   select comp.Name).SingleOrDefault(),
                    logo = (from cr in _context.creditos
                            join comp in _context.company on cr.IdCompany equals comp.Id
                            where cr.IdCompra == i.Id
                            select comp.Logo).SingleOrDefault(),
                    email = i.User.Email,
                    paisOrganizacion = (from cr in _context.creditos
                                        join comp in _context.company on cr.IdCompany equals comp.Id
                                        join p in _context.CatalogsCountrys on comp.CountryId equals p.Id 
                                        where cr.IdCompra == i.Id
                                        select p.Name).SingleOrDefault(),
                    ciudadOrganizacion = (from cr in _context.creditos
                                        join comp in _context.company on cr.IdCompany equals comp.Id
                                        where cr.IdCompra == i.Id
                                        select comp.City).SingleOrDefault()


                }).ToList();

            return service;
        }

        public List<comprasCompany> GetPaquetesByCompany(int companyId)
        {
            var service = _context.creditos
                .Where(x => x.IdCompra != null && x.IdCompany == companyId)
                .Select(i => new comprasCompany
                {
                    paqueteId = i.IdProductoNavigation.Id,
                    fechaCompra = i.IdCompraNavigation.CreationDate,
                    name = i.IdProductoNavigation.Title,
                     creditos = i.IdProductoNavigation.NumberCredits,
                       creditosUsados  = (from cr in _context.creditos
                                                      where cr.IdOpening != null && cr.IdCompra == i.Id
                                                      select cr.IdOpening).Count(),
                     creditosDisponibles=i.IdProductoNavigation.NumberCredits - (from cr in _context.creditos
                                                            where cr.IdOpening != null && cr.IdCompra == i.Id
                                                            select cr.IdOpening).Count(),
                     metodoPago = i.IdCompraNavigation.MetodoPago.Name




                }).ToList();




            return service.GroupBy(x => x.paqueteId).Select(y => y.First()).ToList();
        }
    }
}
