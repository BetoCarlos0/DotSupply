using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoMercadoria.Models;

namespace GerenciamentoMercadoria.Controllers
{
    public class MercadoriaController : Controller
    {
        private readonly GerenciamentoMercadoriaContext _context;

        public MercadoriaController(GerenciamentoMercadoriaContext context)
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

            return View(mercadoria);
        }

        // GET: Mercadoria/Create
        public IActionResult Create()
        {
            return View();
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
            return View(mercadoria);
        }

        // GET: Mercadoria/Edit/5
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
            return View(mercadoria);
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
            return View(mercadoria);
        }

        // GET: Mercadoria/Delete/5
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

            return View(mercadoria);
        }

        // POST: Mercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mercadoria == null)
            {
                return Problem("Entity set 'GerenciamentoMercadoriaContext.Mercadoria'  is null.");
            }
            var mercadoria = await _context.Mercadoria.FindAsync(id);
            if (mercadoria != null)
            {
                _context.Mercadoria.Remove(mercadoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercadoriaExists(int id)
        {
            return (_context.Mercadoria?.Any(e => e.MercadoriaId == id)).GetValueOrDefault();
        }
    }
}
