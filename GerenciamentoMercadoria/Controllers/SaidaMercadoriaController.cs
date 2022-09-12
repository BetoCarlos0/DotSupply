using GerenciamentoMercadoria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoMercadoria.Controllers
{
    public class SaidaMercadoriaController : Controller
    {
        private readonly GerenciamentoMercadoriaContext _context;

        public SaidaMercadoriaController(GerenciamentoMercadoriaContext context)
        {
            _context = context;
        }

        // GET: SaidaMercadoria
        public async Task<IActionResult> Index()
        {
            return _context.EntradaMercadoria != null ?
                View(await _context.SaidaMercadoria
                    .Include(x => x.Mercadoria).ToListAsync()) :
                Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
        }

        // GET: SaidaMercadoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaidaMercadoria == null)
            {
                return NotFound();
            }

            var saidaMercadoria = await _context.SaidaMercadoria
                .Include(s => s.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saidaMercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DetailModalPartial", saidaMercadoria);
        }

        // GET: SaidaMercadoria/Create
        public IActionResult Create()
        {
            ViewBag.Mercadorias = new SelectList(_context.Mercadoria, "MercadoriaId", "Nome");
            return PartialView("CreateModalPartial");
        }

        // POST: SaidaMercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,Data,Local,MercadoriaId")] SaidaMercadoria saidaMercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saidaMercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saidaMercadoria);
        }

        // GET: SaidaMercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaidaMercadoria == null)
            {
                return NotFound();
            }

            var saidaMercadoria = await _context.SaidaMercadoria
                .Include(x => x.Mercadoria).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (saidaMercadoria == null)
            {
                return NotFound();
            }
            ViewBag.Mercadorias = new SelectList(_context.Mercadoria, "MercadoriaId", "Nome");
            return PartialView("EditModalPartial", saidaMercadoria);
        }

        // POST: SaidaMercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,Data,Local,MercadoriaId")] SaidaMercadoria saidaMercadoria)
        {
            if (id != saidaMercadoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saidaMercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaMercadoriaExists(saidaMercadoria.Id))
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
            return View(saidaMercadoria);
        }

        // GET: SaidaMercadoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaidaMercadoria == null)
            {
                return NotFound();
            }

            var saidaMercadoria = await _context.SaidaMercadoria
                .Include(s => s.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saidaMercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DeleteModalPartial", saidaMercadoria);
        }

        // POST: SaidaMercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaidaMercadoria == null)
            {
                return Problem("Entity set 'GerenciamentoMercadoriaContext.SaidaMercadoria'  is null.");
            }
            var saidaMercadoria = await _context.SaidaMercadoria.FindAsync(id);
            if (saidaMercadoria != null)
            {
                _context.SaidaMercadoria.Remove(saidaMercadoria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidaMercadoriaExists(int id)
        {
          return (_context.SaidaMercadoria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
