using biz.matteria.Models.Company;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CompaniesCompany
{
    public interface ICompaniesCompany: IGenericRepository<biz.matteria.Entities.CompaniesCompany>
    {

        List<enlistaCompany> GetEnlistaCompanys(string nameCompany, int pais, int tipoOrganizacion, int? aprobadas, int? status);

        biz.matteria.Models.Company.companyService GetCompanyById(int companyId);

        List<biz.matteria.Models.ddlCompanys.dllCompany> GetDDLCompany();

        enlistaCompanysTotales GetCompanysReport(string nameCompany, int pais, int tipoOrganizacion, int? aprobadas, int? status);

        biz.matteria.Entities.CrearCuentaOrganizacionConfiguracion GetConfiguracionCrearCuentaOrganizacion(int languaje);

        biz.matteria.Entities.IngresoOrganizacionConfiguracion GetConfiguracionIngresoOrganizacion(int languaje);

        biz.matteria.Entities.ConfiguracionMisVacantesOrganizacion GetConfiguracionMisVacantes(int languajeId);

        biz.matteria.Entities.ConfiguracionPerfilOrganizacion GetConfiguracionPerfilOrganizacion(int languajeId);

        biz.matteria.Entities.ConfiguracionStepByStepOrganizacion GetConfiguracionStepByStepOrganizacion(int languajeId);

        biz.matteria.Entities.ConfiguracionOrganizacion GetConfiguracionOrganizacion(int languajeId);

        biz.matteria.Entities.ConfiguracionPublicaVacantesOrganizacion GetConfiguracionPublicarVacante(int languajeId);

    }
}
