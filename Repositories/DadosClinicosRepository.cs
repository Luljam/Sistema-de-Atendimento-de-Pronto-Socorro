using AtendimentoProntoSocorro.Controllers;
using AtendimentoProntoSocorro.Data;
using AtendimentoProntoSocorro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Repositories
{
    public class DadosClinicosRepository : BaseRepository<DadoClinico>,  IDadosClinicosRepository
    {
        private readonly IFichaRepository _fichaRepository;
        public DadosClinicosRepository(ApplicationDbContext context, IFichaRepository fichaRepository) : base(context)
        {
            _fichaRepository = fichaRepository;
        }
        public DadoClinico GetDadosClinicos(int id_ficha)
        {
            var ficha = _fichaRepository.GetFicha(id_ficha);
            // colocar um if de verificação
            var dadosClinicos = dbSet
                .Where(d => d.Ficha.Id == id_ficha)
                .SingleOrDefault();
            if (dadosClinicos == null)
            {
                dadosClinicos = new DadoClinico
                {
                    Ficha = ficha
                };

                dbSet.Add(dadosClinicos);
                context.SaveChanges();
            }

            return dadosClinicos;
        }
    }
}