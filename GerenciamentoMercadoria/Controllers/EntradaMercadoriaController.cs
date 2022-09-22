using DotSupply.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DotSupply.Controllers
{
    public class EntradaMercadoriaController : Controller
    {
        private readonly DotSupplyContext _context;

        public EntradaMercadoriaController(DotSupplyContext context)
        {
            _context = context;
        }

        // GET: EntradaSaidaMercadoria
        public async Task<IActionResult> Index()
        {
            return _context.EntradaMercadoria != null ? 
                View(await _context.EntradaMercadoria
                    .Include(x => x.Mercadoria).ToListAsync()) :
                Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
        }

        // GET: EntradaSaidaMercadoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaMercadoria == null)
            {
                return NotFound();
            }

            var entradaMercadoria = await _context.EntradaMercadoria
                .Include(x => x.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaMercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DetailModalPartial", entradaMercadoria);
        }

        // GET: EntradaMercadoria/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Mercadorias = new SelectList(_context.Mercadoria, "MercadoriaId", "Nome");

            return PartialView("CreateModalPartial");
        }

        // POST: EntradaMercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,Data,Local, MercadoriaId")] EntradaMercadoria entradaMercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaMercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView("CreateModalPartial", entradaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaMercadoria == null)
            {
                return NotFound();
            }

            var entradaMercadoria = await _context.EntradaMercadoria
                .Include(x => x.Mercadoria).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entradaMercadoria == null)
            {
                return NotFound();
            }
            ViewBag.Mercadorias = new SelectList(_context.Mercadoria, "MercadoriaId", "Nome");
            return PartialView("EditModalPartial", entradaMercadoria);
        }

        // POST: EntradaSaidaMercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,Data,Local, MercadoriaId")] EntradaMercadoria entradaMercadoria)
        {
            if (id != entradaMercadoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaMercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaSaidaMercadoriaExists(entradaMercadoria.Id))
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
            return View(entradaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaMercadoria == null)
            {
                return NotFound();
            }

            var entradaMercadoria = await _context.EntradaMercadoria
                .Include(x => x.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaMercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DeleteModalPartial", entradaMercadoria);
        }

        // POST: EntradaSaidaMercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaMercadoria == null)
            {
                return Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
            }
            var entradaMercadoria = await _context.EntradaMercadoria.FindAsync(id);
            if (entradaMercadoria != null)
            {
                _context.EntradaMercadoria.Remove(entradaMercadoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaSaidaMercadoriaExists(int id)
        {
            return (_context.EntradaMercadoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
