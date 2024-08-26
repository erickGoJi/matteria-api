using biz.matteria.Models.openingCubiertas;
using biz.matteria.Models.OpeningPostulationsCandidate;
using biz.matteria.Models.OpeningPostulatios;
using biz.matteria.Models.Openings;
using biz.matteria.Models.VisitaOpening;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.openingsOpening
{
    public interface IopeningsOpening: IGenericRepository<biz.matteria.Entities.OpeningsOpening>
    {
        OpenignRptVacantes GetOpeningsTotalesRptVacantes(string fechaInicial, string fechaFinal, int companyId, string descripcion, int sector, int pais, string ciudad, int status, int companyTypeId, string jornada, int tipoContratoId);

        List<openingServiceBackOffice> GetOpeningsFilterSearch(string fechaInicial,string fechaFinal,int companyId,string descripcion, int sector, int pais, string ciudad, int status, int companyTypeId, string jornada, int tipoContratoId);
        List<OpeningsService> GetOpeningsByCompanyId(int companyId, string name, int status);

        List<OpeningsService> GetAllOpenings(int candidateId=0);

        List<OpeningsService> GetAllOpeningsDestacadas();

        OpeningsService GetOpeningById(int id);

        List<OpeningsService> GetOpeningsByCandidateId(int candidateId);

        List<userOpening> GetPostulationsAndCandidates(int openingId);

        List<openingCubiertas> GetOpeningCubiertas();

        List<openingddl> GetAllOpeningsDDL();

        List<userOpening> GetPostulacionesCandidatos();

        List<openingCompanyCandidate> GetOpeningCandidatesCompany(int companyId);

        List<OpeningsService> GetOpeningAllCloseCaducidad();

        List<OpeningsService> GetVacantesVisitadas(int pstulanteId);

        List<visitaOpening> GetPopUpVacantesVisitadas(int openingId);

        List<biz.matteria.Entities.OpeningsOpeningInterest> GetOpeningInterest(int openingId);
    }
}
