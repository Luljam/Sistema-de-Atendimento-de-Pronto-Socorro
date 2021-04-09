using AtendimentoProntoSocorro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Models
{
    public class DadoClinico : BaseModel
    {
        public new int Id { get; set; }
        public int FichaForeignKey { get; set; }
        public Ficha Ficha { get; set; }
        public string RegistroClinico { get; set; }
        public Profissional Profissional { get; set; }

    }
}
