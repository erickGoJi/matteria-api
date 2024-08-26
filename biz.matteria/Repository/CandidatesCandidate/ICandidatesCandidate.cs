using biz.matteria.Models.candidate;
using biz.matteria.Models.CV;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CandidatesCandidate
{
    public interface ICandidatesCandidate: IGenericRepository<biz.matteria.Entities.CandidatesCandidate>
    {

        candidatesCandidateService GetCandidatesCV(int userid,int candidateid);

        List<enlistaCandidate> GetEnlistaCandidates(string fechaInicial, string FechaFinal, string profesion, int edad, int pais, string ciudad);

        enlistaCandidate GetPostulanteById(int id);

        enlistaPostulantesTotales GetCandidatos(string fechaInicial, string FechaFinal, string profesion, int edad, int pais, string ciudad);

        biz.matteria.Entities.ConfiguracionCrearCuentaPostulante GetConfiguracionCrearCuentaPostulante(int languajeId);

        biz.matteria.Entities.ConfiguracionMiPerfilPostulante GetConfiguracionPerfilPostulante(int languajeId);

        biz.matteria.Entities.ConfiguracionBusquedaVacantesPostulante GetConfiguracionBusqyedaVcantes(int languajeId);

        biz.matteria.Entities.ConfiguracionPostulante GetConfiguracionPostulante(int languajeId);

    }
}
