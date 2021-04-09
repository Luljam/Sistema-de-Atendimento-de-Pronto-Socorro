using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Models.ViewModels
{
    public class PacienteViewModel
    {
        public PacienteViewModel(IList<Paciente> pacientes)
        {
            Pacientes = pacientes;
        }
        public IList<Paciente> Pacientes { get; }

        public string Nome { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}
