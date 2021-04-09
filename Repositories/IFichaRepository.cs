using AtendimentoProntoSocorro.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Repositories
{
    public interface IFichaRepository
    {
        IEnumerable<Ficha> GetFichasAguardando();
        Ficha GetFicha(int id);
    }
}