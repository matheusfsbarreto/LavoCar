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
    public class CarroController : Controller
    {
        //CONNECTION
        private readonly IESContext _context;

        public CarroController(IESContext context)
        {
            this._context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.Include(c => c.Cliente).OrderBy(n => n.MarcaModelo).ToListAsync());
        }

        // CREATE
        public IActionResult Create()
        {
            var marcaModelo = _context.MarcaModelos.OrderBy(i => i.DescMarcaModelo).ToList();
            marcaModelo.Insert(0, new MarcaModelo() { MarcaModeloID = 0, DescMarcaModelo = "Selecione Marca/Modelo" });
            ViewBag.MarcaModelos = marcaModelo;

            var cliente = _context.Clientes.OrderBy(i => i.NomeCliente).ToList();
            cliente.Insert(0, new Cliente() { ClienteID = 0, NomeCliente = "Selecione um Cliente" });
            ViewBag.Clientes = cliente;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Placa, Ano, MarcaModeloID, ClienteID")] Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(carro);
        }

        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            if (carro == null)
            {
                return NotFound();
            }
            ViewBag.MarcaModelos = new SelectList(_context.MarcaModelos.OrderBy(b => b.DescMarcaModelo), "MarcaModeloID", "DescMarcaModelo");

            ViewBag.Clientes = new SelectList(_context.Clientes.OrderBy(b => b.NomeCliente), "ClienteID", "NomeCliente");
            
            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("CarroID, Placa, Ano, MarcaModeloID, ClienteID")] Carro carro)
        {
            if (id != carro.CarroID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.CarroID))
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
            return View(carro);
        }
        private bool CarroExists(long? id)
        {
            return _context.Carros.Any(e => e.CarroID == id);
        }

        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Clientes.Where(i => carro.ClienteID == i.ClienteID).Load();
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Clientes.Where(i => carro.ClienteID == i.ClienteID).Load();
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var carro = await _context.Carros.SingleOrDefaultAsync(m => m.CarroID == id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

