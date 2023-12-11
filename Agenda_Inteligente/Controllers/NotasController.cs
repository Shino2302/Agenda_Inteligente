using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda_Inteligente.Data;
using Agenda_Inteligente.Models;

namespace Agenda_Inteligente.Controllers
{
    public class NotasController : Controller
    {
        private readonly Agenda_InteligenteContext _context;

        public NotasController(Agenda_InteligenteContext context)
        {
            _context = context;
        }

        // GET: Notas
        public async Task<IActionResult> Index()
        {
            var agenda_InteligenteContext = _context.Notas.Include(n => n.Usuario);
            return View(await agenda_InteligenteContext.ToListAsync());
        }

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notas == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNota,IndexNota,Nota,CreacionDeNota,IdUsuario1")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", notas.IdUsuario1);
            return View(notas);
        }

        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notas == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas.FindAsync(id);
            if (notas == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", notas.IdUsuario1);
            return View(notas);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,IndexNota,Nota,CreacionDeNota,IdUsuario1")] Notas notas)
        {
            if (id != notas.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotasExists(notas.IdNota))
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
            ViewData["IdUsuario1"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", notas.IdUsuario1);
            return View(notas);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notas == null)
            {
                return NotFound();
            }

            var notas = await _context.Notas
                .Include(n => n.Usuario)
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notas == null)
            {
                return NotFound();
            }

            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notas == null)
            {
                return Problem("Entity set 'Agenda_InteligenteContext.Notas'  is null.");
            }
            var notas = await _context.Notas.FindAsync(id);
            if (notas != null)
            {
                _context.Notas.Remove(notas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotasExists(int id)
        {
          return (_context.Notas?.Any(e => e.IdNota == id)).GetValueOrDefault();
        }
    }
}
