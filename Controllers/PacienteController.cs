using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtendimentoProntoSocorro.Data;
using AtendimentoProntoSocorro.Models;
using AtendimentoProntoSocorro.Repositories;

namespace AtendimentoProntoSocorro.Controllers
{

    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPacienteRepository pacienteRepository;

        public PacienteController(ApplicationDbContext context, IPacienteRepository pacienteRepository)
        {
            _context = context;
            this.pacienteRepository = pacienteRepository;
        }

        public async Task<IActionResult> Busca(string searchString)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjax)
            {
                var pacientes = await pacienteRepository.ListaPaciente(searchString);
                //if (pacientes != null)
                //{
                if (pacientes.Count() == 0)
                {
                    TempData["AlertMessage"] = "Nenhum registro encontrado!";
                }

                return PartialView("_Busca", pacientes.ToList());
                //}
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Lista(long cpf)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            /// uma das formas de fazer consulta
            var paciente = await pacienteRepository.GetPaciente(cpf); //_context.Paciente.Where(m => m.CPF == cpf).FirstOrDefault();
            if (paciente == null)
            {
                return RedirectToAction(nameof(Create));
            }
            return View(paciente);
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(long cpf)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            /// uma das formas de fazer consulta
            var paciente = await pacienteRepository.GetPaciente(cpf); //_context.Paciente.Where(m => m.CPF == cpf).FirstOrDefault();
            if (paciente == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CPF,RG,CartaoSUS,Nome,DataNascimento,Sexo,RacaId,Logradouro,NumeroLogradouro,Complemento,Bairro,Municipio,UF,CEP,NomeMae,NomePai,Responsavel,Telefone1,Telefone2,Email,NumeroProntuario,RegistroFuncional,InformacaoComplementar,GeneroPaciente,EtiniaPaciente,OrigemFuncionario")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CPF,RG,CartaoSUS,Nome,DataNascimento,Sexo,RacaId,Logradouro,NumeroLogradouro,Complemento,Bairro,Municipio,UF,CEP,NomeMae,NomePai,Responsavel,Telefone1,Telefone2,Email,NumeroProntuario,RegistroFuncional,InformacaoComplementar")] Paciente paciente)
        {
            if (id != paciente.CPF)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.CPF))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(long? cpf)
        {
            if (cpf == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .FirstOrDefaultAsync(m => m.CPF == cpf);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(long id)
        {
            return _context.Pacientes.Any(e => e.CPF == id);
        }
    }
}
