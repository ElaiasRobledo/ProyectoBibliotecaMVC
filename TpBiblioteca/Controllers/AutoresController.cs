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
    public class AutoresController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment env;

        public AutoresController(IWebHostEnvironment env)
        {
            _context = new AppDbContext();
            this.env = env;
        }

        // GET: Autores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Autores.ToListAsync());
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autores = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autores == null)
            {
                return NotFound();
            }

            return View(autores);
        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Biografia,Foto")] Autores autores)
        {
            if (ModelState.IsValid)
            {
                var fotoAutor = HttpContext.Request.Form.Files;
                if(fotoAutor != null && fotoAutor.Count > 0)
                {
                    var archivoFoto = fotoAutor[0];
                    var pathDestino = Path.Combine(env.WebRootPath, "imagenes\\Fotos");

                    if(archivoFoto.Length > 0)
                    {
                        var archivoDestino = Guid.NewGuid().ToString();
                        archivoDestino = archivoDestino.Replace("-", "");
                        archivoDestino += Path.GetExtension(archivoFoto.FileName);

                        var rutaDestino = Path.Combine(pathDestino, archivoDestino);
                        using (var filestream = new FileStream(rutaDestino, FileMode.Create))
                        {
                            archivoFoto.CopyTo(filestream);
                            autores.Foto = archivoDestino;
                        };


                    }

                }
                _context.Add(autores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autores);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autores = await _context.Autores.FindAsync(id);
            if (autores == null)
            {
                return NotFound();
            }
            return View(autores);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Biografia,Foto")] Autores autores)
        {
            if (id != autores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresExists(autores.Id))
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
            return View(autores);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autores == null)
            {
                return NotFound();
            }

            var autores = await _context.Autores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autores == null)
            {
                return NotFound();
            }

            return View(autores);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autores == null)
            {
                return Problem("Entity set 'AppDbContext.Autores'  is null.");
            }
            var autores = await _context.Autores.FindAsync(id);
            if (autores != null)
            {
                _context.Autores.Remove(autores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoresExists(int id)
        {
          return _context.Autores.Any(e => e.Id == id);
        }
    }
}
