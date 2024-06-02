using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class ReciboController : Controller
    {
        //CONNECTION
        private readonly IESContext _context;

        public ReciboController(IESContext context)
        {
            this._context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recibos.Include(c => c.Cliente).Include(g => g.Lavagem).
                Include(e => e.Carro).Include(l => l.TipoLavagem).ToListAsync());
        }

        // CREATE
        [Authorize]
        public IActionResult Create()
        {
            //incluir cliente
            var cliente = _context.Clientes.OrderBy(i => i.NomeCliente).ToList();
            cliente.Insert(0, new Cliente() { ClienteID = 0, NomeCliente = "Selecione um Cliente" });
            ViewBag.Clientes = cliente;

            //incluir carro
            var carro = _context.Carros.OrderBy(i => i.MarcaModelo.DescMarcaModelo).ToList();
            carro.Insert(0, new Carro() { CarroID = 0, Placa = "Selecione a placa" });
            ViewBag.Carros = carro;

            //incluir lavagem
            var lavagem = _context.Lavagens.OrderBy(i => i.DataLav).ToList();
            lavagem.Insert(0, new Lavagem() { LavID = 0, DataLav = DateTime.Now });
            ViewBag.Lavagens = lavagem;

            //incluir tipo de lavagem
            var tipoLavagem = _context.TipoLavagens.OrderBy(i => i.DescTipoLav).ToList();
            tipoLavagem.Insert(0, new TipoLavagem() { TipoLavID = 0, DescTipoLav = "Selecione uma Lavagem" });
            ViewBag.TipoLavagens = tipoLavagem;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteID, CarroID, LavID, TipoLavID, LavagemID")] Recibo recibo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(recibo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(recibo);
        }

        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var recibo = await _context.Recibos.SingleOrDefaultAsync(m => m.ReciboID == id);


            if (recibo == null)
            {
                return NotFound();
            }
            ViewBag.Clientes = new SelectList(_context.Clientes.OrderBy(b => b.NomeCliente), "ClienteID", "NomeCliente");
            ViewBag.Carros = new SelectList(_context.Carros.OrderBy(b => b.Placa), "CarroID", "Placa");
            ViewBag.Lavagens = new SelectList(_context.Lavagens.OrderBy(b => b.DataLav), "LavID", "DataLav");
            ViewBag.TipoLavagens = new SelectList(_context.TipoLavagens.OrderBy(b => b.DescTipoLav), "TipoLavID", "DescTipoLav");
            return View(recibo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ReciboID, ClienteID, CarroID, LavagemID, TipoLavagemID ")] Recibo recibo)
        {
            if (id != recibo.ReciboID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(recibo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciboExists(recibo.ReciboID))
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
            return View(recibo);
        }
        private bool ReciboExists(long? id)
        {
            return _context.Recibos.Any(e => e.ReciboID == id);
        }

        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibos.SingleOrDefaultAsync(m => m.ReciboID == id);
            _context.Recibos.Where(i => recibo.ReciboID == i.ReciboID).Load();

            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Carros.Where(i => recibo.CarroID == i.CarroID).Load();

            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Where(i => recibo.LavagemID == i.LavID).Load();

            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            _context.Clientes.Where(i => recibo.ClienteID == i.ClienteID).Load();

            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Where(i => recibo.TipoLavagemID == i.TipoLavID).Load();


            if (recibo == null)
            {
                return NotFound();
            }
            return View(recibo);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var recibo = await _context.Recibos.SingleOrDefaultAsync(m => m.ReciboID == id);
            _context.Recibos.Where(i => recibo.ReciboID == i.ReciboID).Load();

            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Carros.Where(i => recibo.CarroID == i.CarroID).Load();

            var lavagem = await _context.Lavagens.SingleOrDefaultAsync(m => m.LavID == id);
            _context.Lavagens.Where(i => recibo.LavagemID == i.LavID).Load();

            var cliente = await _context.Clientes.SingleOrDefaultAsync(m => m.ClienteID == id);
            _context.Clientes.Where(i => recibo.ClienteID == i.ClienteID).Load();

            var tipolavagem = await _context.TipoLavagens.SingleOrDefaultAsync(m => m.TipoLavID == id);
            _context.TipoLavagens.Where(i => recibo.TipoLavagemID == i.TipoLavID).Load();
            if (recibo == null)
            {
                return NotFound();
            }
            return View(recibo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var recibo = await _context.Recibos.SingleOrDefaultAsync(m => m.ReciboID == id);
            _context.Recibos.Remove(recibo);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
