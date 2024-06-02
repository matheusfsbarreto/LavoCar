using LavoCar.Conexao;
using LavoCar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        //CONNECTION
        private readonly IESContext _context;

        public FuncionarioController(IESContext context)
        {
            this._context = context;
        }

        // INDEX
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.OrderBy(n => n.NomeFuncionario).ToListAsync());
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeFuncionario, EndFuncionario, FoneFuncionario")] Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(funcionario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(funcionario);
        }

        // EDIT
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("FuncionarioID, NomeFuncionario, EndFuncionario, FoneFuncionario ")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioID))
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
            return View(funcionario);
        }
        private bool FuncionarioExists(long? id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioID == id);
        }

        //DETAILS
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        //DELETE
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioID == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var funcionario = await _context.Funcionarios.SingleOrDefaultAsync(m => m.FuncionarioID == id);
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
