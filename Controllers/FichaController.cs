using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtendimentoProntoSocorro.Data;
using AtendimentoProntoSocorro.Models;
using AtendimentoProntoSocorro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoProntoSocorro.Controllers
{
    public class FichaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPacienteRepository pacienteRepository;
        
        private readonly IFichaRepository fichaRepository;

        public FichaController(ApplicationDbContext context, IPacienteRepository pacienteRepository, IFichaRepository fichaRepository)
        {
            _context = context;
            this.pacienteRepository = pacienteRepository;
            this.fichaRepository = fichaRepository;
        }

        public  IActionResult  Aguardando()
        {
            var fichas = fichaRepository.GetFichasAguardando();
            return View(fichas);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AberturaDeFicha(long cpf)
        {
            Paciente paciente = await pacienteRepository.GetPaciente(cpf);
            Ficha ficha = new Ficha
            {
                Paciente = paciente
            };
            return View(ficha);
        }

        [HttpPost]
        public async Task<IActionResult> CadastroFichaAsync(Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                Paciente paciente = ficha.Paciente = await pacienteRepository.GetPaciente(ficha.Paciente.CPF);
                ficha.Paciente = paciente;
                ficha.DataFicha = DateTime.Now;

                _context.Add(ficha);
                await _context.SaveChangesAsync();

                TempData["AlertMessage"] = "registro salvo com sucesso";

                return RedirectToAction("Index", "Paciente");
            }
            return View(ficha);
        }
    }
}