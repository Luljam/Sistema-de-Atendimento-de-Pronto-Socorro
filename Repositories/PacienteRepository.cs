using AtendimentoProntoSocorro.Data;
using AtendimentoProntoSocorro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Repositories
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        public async Task<Paciente> GetPaciente(long cpf)
        {   
            var paciente = await dbSet
                .Where(p => p.CPF == cpf)
                .SingleOrDefaultAsync();

            if (paciente == null)
            {
                return paciente;
            }
            return paciente;
        }

        public async Task<IEnumerable<Paciente>> ListaPaciente(string nome)
        {
            if (!String.IsNullOrEmpty(nome))
            {
                var pacientes = await dbSet
                    .Where(p => p.Nome.ToUpper().Contains(nome.ToUpper())).ToListAsync();
                return pacientes;
            }
            return null;
        }
    }
}