using Microsoft.AspNetCore.Http;
using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LavoCar.Controllers
{
    [Authorize]
    public class MarcaModeloController : Controller {

        private readonly IESContext _context;

        public MarcaModeloController(IESContext context) {
            this._context = context;
        }

        // GET: MarcaModeloController
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarcaModelos.OrderBy(n => n.DescMarcaModelo).ToListAsync());
        }

        // GET: MarcaModeloController/Create
        public IActionResult Create() {
            return View();
        }

        // POST: MarcaModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescMarcaModelo")] MarcaModelo marcaModelo) {
            try {
                if (ModelState.IsValid) {
                    _context.Add(marcaModelo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
                return View(marcaModelo);
        }


        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marcaModelo = await _context.MarcaModelos.SingleOrDefaultAsync(m => m.MarcaModeloID == id);
            if (marcaModelo == null)
            {
                return NotFound();
            }
            return View(marcaModelo);
        }



        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marcaModelo = await _context.MarcaModelos.SingleOrDefaultAsync(m => m.MarcaModeloID == id);
            if (marcaModelo == null)
            {
                return NotFound();
            }
            return View(marcaModelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DescMarcaModelo, MarcaModeloID")] MarcaModelo marcaModelo)
        {
            if (id != marcaModelo.MarcaModeloID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcaModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaModeloExists(marcaModelo.MarcaModeloID))
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
            return View(marcaModelo);
        }
        private bool MarcaModeloExists(long? id)
        {
            return _context.MarcaModelos.Any(e => e.MarcaModeloID == id);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marcaModelo = await _context.MarcaModelos.SingleOrDefaultAsync(m => m.MarcaModeloID == id);
            if (marcaModelo == null)
            {
                return NotFound();
            }
            return View(marcaModelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var marcaModelo = await _context.MarcaModelos.SingleOrDefaultAsync(m => m.MarcaModeloID == id);
            _context.MarcaModelos.Remove(marcaModelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
