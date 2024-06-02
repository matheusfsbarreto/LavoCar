using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    [Authorize]
    public class ReparoController : Controller
    {
        // GET: ReparoController
        private readonly IESContext _context;

        public ReparoController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reparos.Include(t => t.TipoReparo).OrderBy(c => c.DataReparo).ToListAsync());
        }

        // GET: ReparoController/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reparo = await _context.Reparos.SingleOrDefaultAsync(m => m.ReparoID == id);
            _context.Reparos.Where(i => reparo.ReparoID == i.ReparoID).Load();

            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Carros.Where(i => reparo.CarroID == i.CarroID).Load();

            var tipoReparo = await _context.TipoReparos.SingleOrDefaultAsync(m => m.TipoReparoID == id);
            _context.TipoReparos.Where(i => reparo.TipoReparoID == i.TipoReparoID).Load();

            if (reparo == null)
            {
                return NotFound();
            }
            return View(reparo);
        }

        // GET: ReparoController/Create
        public IActionResult Create()
        {
            var carro = _context.Carros.OrderBy(i => i.Placa).ToList();
            carro.Insert(0, new Carro() { CarroID = 0, Placa = "Selecione o carro" });
            ViewBag.Carros = carro;

            var tipoReparo = _context.TipoReparos.OrderBy(i => i.DescTipoReparo).ToList();
            tipoReparo.Insert(0, new TipoReparo() { TipoReparoID = 0, DescTipoReparo = "Selecione um Reparo" });
            ViewBag.TipoReparos = tipoReparo;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataReparo, CarroID, TipoReparoID")] Reparo reparo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(reparo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(reparo);
        }

        // GET: ReparoController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reparo = await _context.Reparos.SingleOrDefaultAsync(m => m.ReparoID == id);
            if (reparo == null)
            {
                return NotFound();
            }
            ViewBag.Carros = new SelectList(_context.Carros.OrderBy(b => b.Placa), "CarroID", "Placa");

            ViewBag.TipoReparos = new SelectList(_context.TipoReparos.OrderBy(b => b.DescTipoReparo), "TipoReparoID", "DescTipoReparo");

            return View(reparo);

        }

        // POST: ReparoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id, [Bind("ReparoID, DataReparo, CarroID, TipoReparoID")] Reparo reparo)
        {

            if (id != reparo.ReparoID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reparo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReparoExists(reparo.ReparoID))
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
            return View(reparo);
        }

        private bool ReparoExists(long? id)
        {
            return _context.Reparos.Any(e => e.ReparoID == id);
        }

        // GET: ReparoController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reparo = await _context.Reparos.SingleOrDefaultAsync(m => m.ReparoID == id);
            _context.TipoReparos.Where(i => reparo.TipoReparoID == i.TipoReparoID).Load();
            if (reparo == null)
            {
                return NotFound();
            }
            return View(reparo);
        }

        // POST: ReparoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var reparo = await _context.Reparos.SingleOrDefaultAsync(m => m.ReparoID == id);
            _context.Reparos.Remove(reparo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
