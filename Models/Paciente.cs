using AtendimentoProntoSocorro.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Models
{
    public class Paciente : BaseModel
    {
        //A ideia de usar o CPF como chave primária.
        //Decore sua chave com [DatabaseGenerated(DatabaseGeneratedOption.None)] para que o sistema defina a chave primária, e não o banco de dados
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(0, long.MaxValue)]
        public long CPF { get; set; }
        public string RG { get; set; }
        public long CartaoSUS { get; set; }
        public string Nome { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public Etinia EtiniaPaciente { get; set; }
        public string Logradouro { get; set; }
        public string NumeroLogradouro  { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Responsavel { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
        public int NumeroProntuario { get; set; }
        public int RegistroFuncional { get; set; }
        public string InformacaoComplementar { get; set; }
        public Genero GeneroPaciente { get; set; }
        public Origem OrigemFuncionario { get; set; }
    }

    public enum Genero
    {
        Masculino,
        Feminino
    }

    public enum Etinia
    {
        Branca,
        Preta,
        Parda,
        Amarela,
        Indígena
    }

    public enum Origem
    {
        Municipe,
        Funcionario
    }
}
