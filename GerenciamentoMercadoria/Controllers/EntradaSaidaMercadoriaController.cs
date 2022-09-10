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
    public class EntradaSaidaMercadoriaController : Controller
    {
        private readonly GerenciamentoMercadoriaContext _context;

        public EntradaSaidaMercadoriaController(GerenciamentoMercadoriaContext context)
        {
            _context = context;
        }

        // GET: EntradaSaidaMercadoria
        public async Task<IActionResult> EntradaMercadoria()
        {
            return _context.entradaSaidaMercadorias != null ?
                View(await _context.entradaSaidaMercadorias.ToListAsync()) :
                Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
        }

        public async Task<IActionResult> SaidaMercadoria()
        {
            return _context.entradaSaidaMercadorias != null ?
                        View(await _context.entradaSaidaMercadorias.ToListAsync()) :
                        Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
        }


        // GET: EntradaSaidaMercadoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.entradaSaidaMercadorias == null)
            {
                return NotFound();
            }

            var entradaSaidaMercadoria = await _context.entradaSaidaMercadorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }

            return View(entradaSaidaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EntradaSaidaMercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InfoCadastro,Quantidade,Data,Local")] EntradaSaidaMercadoria entradaSaidaMercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaSaidaMercadoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entradaSaidaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.entradaSaidaMercadorias == null)
            {
                return NotFound();
            }

            var entradaSaidaMercadoria = await _context.entradaSaidaMercadorias.FindAsync(id);
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }
            return View(entradaSaidaMercadoria);
        }

        // POST: EntradaSaidaMercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InfoCadastro,Quantidade,Data,Local")] EntradaSaidaMercadoria entradaSaidaMercadoria)
        {
            if (id != entradaSaidaMercadoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaSaidaMercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaSaidaMercadoriaExists(entradaSaidaMercadoria.Id))
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
            return View(entradaSaidaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.entradaSaidaMercadorias == null)
            {
                return NotFound();
            }

            var entradaSaidaMercadoria = await _context.entradaSaidaMercadorias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }

            return View(entradaSaidaMercadoria);
        }

        // POST: EntradaSaidaMercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.entradaSaidaMercadorias == null)
            {
                return Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
            }
            var entradaSaidaMercadoria = await _context.entradaSaidaMercadorias.FindAsync(id);
            if (entradaSaidaMercadoria != null)
            {
                _context.entradaSaidaMercadorias.Remove(entradaSaidaMercadoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaSaidaMercadoriaExists(int id)
        {
            return (_context.entradaSaidaMercadorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
