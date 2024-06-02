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
    public class TipoLavagemController : Controller {

        private readonly IESContext _context;

        public TipoLavagemController(IESContext context) {
            this._context = context;
        }

        // GET: TipoLavagemController
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoLavagens.OrderBy(n => n.DescTipoLav).ToListAsync());
        }

        // GET: TipoLavagemController/Create
        public IActionResult Create() {
            return View();
        }

        // POST: TipoLavagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescTipoLav, PrecoTipoLav")] TipoLavagem tipoLavagem) {
            try {
                if (ModelState.IsValid) {
                    _context.Add(tipoLavagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException) {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
                return View(tipoLavagem);
        }


        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipolavagem == null)
            {
                return NotFound();
            }
            return View(tipolavagem);
        }



        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipolavagem == null)
            {
                return NotFound();
            }
            return View(tipolavagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("DescTipoLav, PrecoTipoLav, TipoLavID")] TipoLavagem tipoLavagem)
        {
            if (id != tipoLavagem.TipoLavID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoLavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoLavExists(tipoLavagem.TipoLavID))
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
            return View(tipoLavagem);
        }
        private bool TipoLavExists(long? id)
        {
            return _context.TipoLavagens.Any(e => e.TipoLavID == id);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            if (tipolavagem == null)
            {
                return NotFound();
            }
            return View(tipolavagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Remove(tipolavagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
