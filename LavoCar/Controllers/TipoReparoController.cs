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
    public class TipoReparoController : Controller {

        private readonly IESContext _context;

        public TipoReparoController(IESContext context) {
            this._context = context;
        }

        // GET: TipoReparoController
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoReparos.OrderBy(n => n.DescTipoReparo).ToListAsync());
        }

        // GET: TipoReparoController/Create
        public IActionResult Create() {
            return View();
        }

        // POST: TipoReparoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescTipoReparo, PrecoTipoReparo")] TipoReparo tipoReparo) {
            try {
                if (ModelState.IsValid) {
                    _context.Add(tipoReparo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
                return View(tipoReparo);
        }


        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipoReparo = await _context.TipoReparos.SingleOrDefaultAsync(m => m.TipoReparoID == id);
            if (tipoReparo == null)
            {
                return NotFound();
            }
            return View(tipoReparo);
        }

        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipoReparo = await _context.TipoReparos.SingleOrDefaultAsync(m => m.TipoReparoID == id);
            if (tipoReparo == null)
            {
                return NotFound();
            }
            return View(tipoReparo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DescTipoReparo, PrecoTipoReparo, TipoReparoID")] TipoReparo tipoReparo)
        {
            if (id != tipoReparo.TipoReparoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoReparo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoReparoExists(tipoReparo.TipoReparoID))
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
            return View(tipoReparo);
        }
        private bool TipoReparoExists(long? id)
        {
            return _context.TipoReparos.Any(e => e.TipoReparoID == id);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipoReparo = await _context.TipoReparos.SingleOrDefaultAsync(m => m.TipoReparoID == id);
            if (tipoReparo == null)
            {
                return NotFound();
            }
            return View(tipoReparo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var tipoReparo = await _context.TipoReparos.SingleOrDefaultAsync(m => m.TipoReparoID == id);
            _context.TipoReparos.Remove(tipoReparo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
