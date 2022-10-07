using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpBiblioteca.Models;

namespace TpBiblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _context;

        public LibrosController()
        {
            _context = new AppDbContext();
        }

        // GET: Libros
        public async Task<IActionResult> Index()
        {
              return View(await _context.Libros_1.ToListAsync());
        }

        // GET: Libros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros_1 == null)
            {
                return NotFound();
            }

            var libros = await _context.Libros_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // GET: Libros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Resumen,FechaPublicacion,ImagenPortada")] Libros libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libros);
        }

        // GET: Libros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros_1 == null)
            {
                return NotFound();
            }

            var libros = await _context.Libros_1.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }
            return View(libros);
        }

        // POST: Libros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Resumen,FechaPublicacion,ImagenPortada")] Libros libros)
        {
            if (id != libros.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrosExists(libros.Id))
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
            return View(libros);
        }

        // GET: Libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros_1 == null)
            {
                return NotFound();
            }

            var libros = await _context.Libros_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros_1 == null)
            {
                return Problem("Entity set 'AppDbContext.Libros_1'  is null.");
            }
            var libros = await _context.Libros_1.FindAsync(id);
            if (libros != null)
            {
                _context.Libros_1.Remove(libros);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrosExists(int id)
        {
          return _context.Libros_1.Any(e => e.Id == id);
        }
    }
}
