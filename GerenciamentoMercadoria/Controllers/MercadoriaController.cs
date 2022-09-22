using DotSupply.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotSupply.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly DotSupplyContext _context;

        public MercadoriaController(DotSupplyContext context)
        {
            _context = context;
        }

        // GET: Mercadoria
        public async Task<IActionResult> Index()
        {
            return _context.Mercadoria != null ?
                        View(await _context.Mercadoria.ToListAsync()) :
                        Problem("Entity set 'GerenciamentoMercadoriaContext.Mercadoria'  is null.");
        }

        // GET: Mercadoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.MercadoriaId == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return PartialView("detailModalPartial", mercadoria);
        }

        // GET: Mercadoria/Create
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("CreateModalPartial");
        }

        // POST: Mercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MercadoriaId,Nome,NumRegistro,Fabricante,Tipo,Descricao")] Mercadoria mercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Mercadoria/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria.FindAsync(id);
            if (mercadoria == null)
            {
                return NotFound();
            }
            return PartialView("EditModalPartial", mercadoria);
        }

        // POST: Mercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MercadoriaId,Nome,NumRegistro,Fabricante,Tipo,Descricao")] Mercadoria mercadoria)
        {
            if (id != mercadoria.MercadoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercadoriaExists(mercadoria.MercadoriaId))
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
            return RedirectToAction(nameof(Index));
        }

        //GET: Mercadoria/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mercadoria == null)
            {
                return NotFound();
            }

            var mercadoria = await _context.Mercadoria
                .FirstOrDefaultAsync(m => m.MercadoriaId == id);
            if (mercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DeleteModalPartial", mercadoria);
        }

        // POST: Mercadoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Mercadoria merc)
        {
            if (_context.Mercadoria == null)
            {
                return Problem("Entity set 'GerenciamentoMercadoriaContext.Mercadoria'  is null.");
            }
            var mercadoria = await _context.Mercadoria.FindAsync(merc.MercadoriaId);
            if (mercadoria != null)
            {
                _context.Mercadoria.Remove(mercadoria);
            }

            await _context.SaveChangesAsync();
            return PartialView("DeleteModalPartial", mercadoria);
        }

        private bool MercadoriaExists(int id)
        {
            return (_context.Mercadoria?.Any(e => e.MercadoriaId == id)).GetValueOrDefault();
        }
    }
}
