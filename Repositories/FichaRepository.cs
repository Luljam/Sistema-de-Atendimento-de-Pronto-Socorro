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
    public class FichaRepository : BaseRepository<Ficha>, IFichaRepository
    {
        // para acessar o objeto da sessão utilizamos o componente httpContextAccessor
        private readonly IHttpContextAccessor contextAccessor;
        public FichaRepository(ApplicationDbContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            this.contextAccessor = contextAccessor;
        }

        public Ficha GetFicha()
        {
            var fichaId = GetFichaId();
            var ficha = dbSet
                .Where(f => f.Id == fichaId)
                .SingleOrDefault();

            SetFichaId(ficha.Id);
            return ficha;
        }
        public Ficha GetFicha(int id)
        {
            var ficha = dbSet
                .Where(f => f.Id == id)
                .FirstOrDefault();
            return ficha;
        }

        public IEnumerable<Ficha> GetFichasAguardando()
        {
            var fichas = dbSet
                .Include(p => p.Paciente)
                .Where(f => f.StatusDaFicha == 0);
            return fichas;
        }

        private int? GetFichaId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("fichaId");
        }

        // gravar paciente na Sessão
        private void SetFichaId(int pacienteCpf)
        {
            contextAccessor.HttpContext.Session.SetInt32("fichaId", pacienteCpf);
        }
    }
}
