using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroPecas.Models;

namespace CadastroPecas.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        public CadastroController(Contexto context)
        {
            _context = context;
        }

        // GET: Cadastro
        public async Task<IActionResult> Index()
        {
              return _context.CadastroModel != null ? 
                          View(await _context.CadastroModel.ToListAsync()) :
                          Problem("Entity set 'Contexto.CadastroModel'  is null.");
        }

        // GET: Cadastro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadastroModel == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.CadastroModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroModel == null)
            {
                return NotFound();
            }

            return View(cadastroModel);
        }

        // GET: Cadastro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Peca")] CadastroModel cadastroModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroModel);
        }

        // GET: Cadastro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadastroModel == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.CadastroModel.FindAsync(id);
            if (cadastroModel == null)
            {
                return NotFound();
            }
            return View(cadastroModel);
        }

        // POST: Cadastro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Peca")] CadastroModel cadastroModel)
        {
            if (id != cadastroModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroModelExists(cadastroModel.Id))
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
            return View(cadastroModel);
        }

        // GET: Cadastro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadastroModel == null)
            {
                return NotFound();
            }

            var cadastroModel = await _context.CadastroModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroModel == null)
            {
                return NotFound();
            }

            return View(cadastroModel);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadastroModel == null)
            {
                return Problem("Entity set 'Contexto.CadastroModel'  is null.");
            }
            var cadastroModel = await _context.CadastroModel.FindAsync(id);
            if (cadastroModel != null)
            {
                _context.CadastroModel.Remove(cadastroModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroModelExists(int id)
        {
          return (_context.CadastroModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
