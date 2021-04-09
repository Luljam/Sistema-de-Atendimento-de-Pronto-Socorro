using System.Collections.Generic;
using System.Threading.Tasks;
using AtendimentoProntoSocorro.Models;

namespace AtendimentoProntoSocorro.Repositories
{
    public interface IPacienteRepository
    {
       Task<Paciente> GetPaciente(long cpf);
       Task<IEnumerable<Paciente>> ListaPaciente(string nome);
    }
}