using AtendimentoProntoSocorro.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Models
{
    public class Ficha : BaseModel
    {
        public new int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataFicha { get; set; }
        public string Queixa { get; set; }
        public string InformacaoResgate { get; set; }
        public int StatusDaFicha { get; set; }
        public Especialidade Especialidade { get; set; }
        public Procedencia Procedencia { get; set; }
        public DadoClinico DadoClinico { get; set; }
    }

    public  enum Especialidade
    {
        BucoMaxilo,
        CirurgiaGeral,
        ClínicaMédica,
        COVID,
        Neurocirugia,
        Pediatria,
        Traumatologia,
        Obstetrícia
    }

    public enum Procedencia
    {
        Espontânea,
        Bombeiro,
        PolíciaMilitar,
        GCM,
        Metrô,
        AMASÉ,
        SAMU,
        AmbulânciaPartilular
    }
}