using GerenciamentoMercadoria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;

namespace GerenciamentoMercadoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GerenciamentoMercadoriaContext _context;

        public HomeController(ILogger<HomeController> logger, GerenciamentoMercadoriaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Grafic()
        {
            //var produtos = await _context.Mercadoria.ToListAsync();
            //var mes = await _context.EntradaMercadoria.ToListAsync();

            var data = _context.EntradaMercadoria.GroupBy(x => new { x.MercadoriaId, x.Data.Month }).Select(x => 
                new ViewModelData {
                    Nome = x.First().Mercadoria.Nome,
                    Quantidade = x.Sum(x => x.Quantidade)
                }).ToList();

            ViewBag.qntMercadoria = data.Count();

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}