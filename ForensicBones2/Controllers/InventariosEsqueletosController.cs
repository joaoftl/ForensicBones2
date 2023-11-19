using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForensicBones2.Models;

namespace ForensicBones2.Controllers
{
    public class InventariosEsqueletosController : Controller
    {
        private readonly AppDbContext _context;

        public InventariosEsqueletosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InventariosEsqueletos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.InventariosEsqueletos.Include(i => i.Relatorio);
            return View(await appDbContext.ToListAsync());
        }

        // GET: InventariosEsqueletos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventariosEsqueletos == null)
            {
                return NotFound();
            }

            var inventarioEsqueleto = await _context.InventariosEsqueletos
                .Include(i => i.Relatorio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioEsqueleto == null)
            {
                return NotFound();
            }

            return View(inventarioEsqueleto);
        }

        // GET: InventariosEsqueletos/Create
        public IActionResult Create()
        {
            ViewData["RelatorioId"] = new SelectList(_context.Relatorios, "Id", "Codigo");
            return View();
        }

        // POST: InventariosEsqueletos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Observacoes,RelatorioId")] InventarioEsqueleto inventarioEsqueleto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioEsqueleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RelatorioId"] = new SelectList(_context.Relatorios, "Id", "Codigo", inventarioEsqueleto.RelatorioId);
            return View(inventarioEsqueleto);
        }

        // GET: InventariosEsqueletos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventariosEsqueletos == null)
            {
                return NotFound();
            }

            var inventarioEsqueleto = await _context.InventariosEsqueletos.FindAsync(id);
            if (inventarioEsqueleto == null)
            {
                return NotFound();
            }
            ViewData["RelatorioId"] = new SelectList(_context.Relatorios, "Id", "Codigo", inventarioEsqueleto.RelatorioId);
            return View(inventarioEsqueleto);
        }

        // POST: InventariosEsqueletos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Observacoes,RelatorioId")] InventarioEsqueleto inventarioEsqueleto)
        {
            if (id != inventarioEsqueleto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioEsqueleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioEsqueletoExists(inventarioEsqueleto.Id))
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
            ViewData["RelatorioId"] = new SelectList(_context.Relatorios, "Id", "Codigo", inventarioEsqueleto.RelatorioId);
            return View(inventarioEsqueleto);
        }

        // GET: InventariosEsqueletos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventariosEsqueletos == null)
            {
                return NotFound();
            }

            var inventarioEsqueleto = await _context.InventariosEsqueletos
                .Include(i => i.Relatorio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioEsqueleto == null)
            {
                return NotFound();
            }

            return View(inventarioEsqueleto);
        }

        // POST: InventariosEsqueletos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventariosEsqueletos == null)
            {
                return Problem("Entity set 'AppDbContext.InventariosEsqueletos'  is null.");
            }
            var inventarioEsqueleto = await _context.InventariosEsqueletos.FindAsync(id);
            if (inventarioEsqueleto != null)
            {
                _context.InventariosEsqueletos.Remove(inventarioEsqueleto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioEsqueletoExists(int id)
        {
          return _context.InventariosEsqueletos.Any(e => e.Id == id);
        }
    }
}
