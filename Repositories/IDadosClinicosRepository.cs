using AtendimentoProntoSocorro.Models;

namespace AtendimentoProntoSocorro.Controllers
{
    public interface IDadosClinicosRepository
    {
        public DadoClinico GetDadosClinicos(int id_ficha);
    }
}