using biz.matteria.Models.comprasadmin;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CompraPaquetes
{
    public interface ICompraPaquetes: IGenericRepository<biz.matteria.Entities.ComprasPaquete>
    {

        List<comprasAdmin> getComprasAdmin(int companyId, int metodoPagoId,string fechaInicial, string FechaFinal,int paisId,int productoId,string ciudad);

        comprasDetalleAdmin GetCompraById(int compraId);

        List<comprasCompany> GetPaquetesByCompany(int companyId);
        comprasAdminRpt getComprasAdminRpt(int companyId, int metodoPagoId, string fechaInicial, string FechaFinal, int paisId, int productoId,string ciudad);

    }
}
