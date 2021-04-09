using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtendimentoProntoSocorro.Data;
using AtendimentoProntoSocorro.Models;
using AtendimentoProntoSocorro.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtendimentoProntoSocorro.Controllers
{
    public class DadosClinicosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDadosClinicosRepository dadosClinicosRepository;

        public DadosClinicosController(ApplicationDbContext context,  IDadosClinicosRepository dadosClinicosRepository)
        {
            _context = context;
            this.dadosClinicosRepository = dadosClinicosRepository;
        }

        public IActionResult Atender(int idFicha)
        {
            if (ModelState.IsValid)
            {
                var dados = dadosClinicosRepository.GetDadosClinicos(idFicha);
                return View(dados);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GravarDadosClinicos(DadoClinico dadosClinicos)
        {
            if (ModelState.IsValid)
            {
                //var _idFicha = 
                //Ficha ficha = fichaRepository.GetFicha(_idFicha);

                _context.Add(dadosClinicos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Aguardando", "Ficha");
            }

            return View(dadosClinicos);
        }
        // GET: DadosClinicos
        public ActionResult Index()
        {
            return View();
        }
    }
}