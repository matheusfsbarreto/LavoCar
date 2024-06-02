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
    public class LavagemController : Controller
    {
        // GET: LavagemController
        private readonly IESContext _context;

        public LavagemController(IESContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Lavagens.Include(t => t.TipoLavagem).OrderBy(c => c.DataLav).ToListAsync());
        }

        // GET: LavagemController/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Where(i => lavagem.LavID == i.LavID).Load();

            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Carros.Where(i => lavagem.CarroID == i.CarroID).Load();

            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Where(i => lavagem.TipoLavagemID == i.TipoLavID).Load();

            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioID == id);
            _context.Funcionarios.Where(i => lavagem.FuncionarioID == i.FuncionarioID).Load();

            if (lavagem == null)
            {
                return NotFound();
            }
            return View(lavagem);
        }

        // GET: LavagemController/Create
        public IActionResult Create()         
        {
            var carro = _context.Carros.OrderBy(i => i.Placa).ToList();
            carro.Insert(0, new Carro() { CarroID = 0, Placa = "Selecione o carro" });
            ViewBag.Carros = carro;

            var tipoLavagem = _context.TipoLavagens.OrderBy(i => i.DescTipoLav).ToList();
            tipoLavagem.Insert(0, new TipoLavagem() { TipoLavID = 0, DescTipoLav = "Selecione uma Lavagem" });
            ViewBag.TipoLavagens = tipoLavagem;

            var funcionario = _context.Funcionarios.OrderBy(i => i.NomeFuncionario).ToList();
            funcionario.Insert(0, new Funcionario() { FuncionarioID = 0, NomeFuncionario = "Selecione um Funcionário" });
            ViewBag.Funcionarios = funcionario;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataLav, CarroID, TipoLavagemID, FuncionarioID")] Lavagem lavagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lavagem);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(lavagem);
        }

        // GET: LavagemController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            if (lavagem == null)
            {
                return NotFound();
            }
            ViewBag.Carros = new SelectList(_context.Carros.OrderBy(b => b.Placa), "CarroID", "Placa");

            ViewBag.TipoLavagens = new SelectList(_context.TipoLavagens.OrderBy(b => b.DescTipoLav), "TipoLavID", "DescTipoLav");

            ViewBag.Funcionarios = new SelectList(_context.Funcionarios.OrderBy(b => b.NomeFuncionario), "FuncionarioID", "NomeFuncionario");
            
            return View(lavagem);

        }

        // POST: LavagemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long? id, [Bind("LavID, DataLav, CarroID, TipoLavagemID, FuncionarioID")] Lavagem lavagem)
        {

            if (id != lavagem.LavID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lavagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LavagemExists(lavagem.LavID))
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
        return View(lavagem);
        }

        private bool LavagemExists(long? id)
        {
            return _context.Lavagens.Any(e => e.LavID == id);
        }

        // GET: LavagemController/Delete/5
        public  async Task<IActionResult> Delete(long? id)
        {
        if (id == null)
        {
            return NotFound();
        }
        var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
        _context.TipoLavagens.Where(i => lavagem.TipoLavagemID == i.TipoLavID).Load();
        if (lavagem == null)
        {
            return NotFound();
        }
        return View(lavagem);
    }

        // POST: LavagemController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Remove(lavagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
