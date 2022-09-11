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
        [Route("/entrada-mercadoria")]
        public async Task<IActionResult> EntradaMercadoria()
        {
            ViewBag.infoCadastro = "entrada";
            return _context.entradaSaidaMercadorias != null ? 
                View(await _context.entradaSaidaMercadorias
                    .Where(x => x.InfoCadastro == "entrada")
                    .Include(x => x.Mercadoria).ToListAsync()) :
                Problem("Entity set 'GerenciamentoMercadoriaContext.entradaSaidaMercadorias'  is null.");
        }

        [Route("/saida-mercadoria")]
        public async Task<IActionResult> SaidaMercadoria()
        {
            return _context.entradaSaidaMercadorias != null ?
                View(await _context.entradaSaidaMercadorias
                    .Where(x => x.InfoCadastro == "saida")
                    .Include(x => x.Mercadoria).ToListAsync()) :
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
                .Include(x => x.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }

            return PartialView("DetailModalPartial", entradaSaidaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Create
        public async Task<IActionResult> Create(string info)
        {
            var allMercadoria = await _context.Mercadoria.ToListAsync();

            ViewBag.Mercadorias = new SelectList(allMercadoria, "MercadoriaId", "Nome");
            ViewBag.info = info;

            return PartialView("CreateModalPartial");
        }

        // POST: EntradaSaidaMercadoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InfoCadastro,Quantidade,Data,Local, MercadoriaId")] EntradaSaidaMercadoria entradaSaidaMercadoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaSaidaMercadoria);
                await _context.SaveChangesAsync();

                if (entradaSaidaMercadoria.InfoCadastro == "entrada")
                    return RedirectToAction(nameof(EntradaMercadoria));
                else
                    return RedirectToAction(nameof(SaidaMercadoria));
            }
            return PartialView("CreateModalPartial", entradaSaidaMercadoria);
        }

        // GET: EntradaSaidaMercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.entradaSaidaMercadorias == null)
            {
                return NotFound();
            }

            var allMercadoria = await _context.Mercadoria.ToListAsync();

            ViewBag.Mercadorias = new SelectList(allMercadoria, "MercadoriaId", "Nome");

            var entradaSaidaMercadoria = await _context.entradaSaidaMercadorias.Include(x => x.Mercadoria).FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }
            return PartialView("EditModalPartial", entradaSaidaMercadoria);
        }

        // POST: EntradaSaidaMercadoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InfoCadastro,Quantidade,Data,Local, MercadoriaId")] EntradaSaidaMercadoria entradaSaidaMercadoria)
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
                if (entradaSaidaMercadoria.InfoCadastro == "entrada")
                    return RedirectToAction(nameof(EntradaMercadoria));
                else
                    return RedirectToAction(nameof(SaidaMercadoria));
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
                .Include(x => x.Mercadoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaSaidaMercadoria == null)
            {
                return NotFound();
            }
            return PartialView("DeleteModalPartial", entradaSaidaMercadoria);
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
            if (entradaSaidaMercadoria.InfoCadastro == "entrada")
                return RedirectToAction(nameof(EntradaMercadoria));
            else
                return RedirectToAction(nameof(SaidaMercadoria));
        }

        private bool EntradaSaidaMercadoriaExists(int id)
        {
            return (_context.entradaSaidaMercadorias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
