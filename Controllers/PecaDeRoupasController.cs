using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaDS2Denner.Data;
using ProvaDS2Denner.Models;

namespace ProvaDS2Denner.Controllers
{
    public class PecaDeRoupasController : Controller
    {
        private readonly ProvaDS2DennerContext _context;

        public PecaDeRoupasController(ProvaDS2DennerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Enviar([Bind("RoupaId,Nome,Quantidade")] PecaDeRoupa pecaDeRoupa)
        {
            Confeccao confeccao = new Confeccao(pecaDeRoupa);
            _context.Update(confeccao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PecaDeRoupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PecaDeRoupa.ToListAsync());
        }

        // GET: PecaDeRoupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecaDeRoupa = await _context.PecaDeRoupa
                .FirstOrDefaultAsync(m => m.PecaDeRoupaId == id);
            if (pecaDeRoupa == null)
            {
                return NotFound();
            }

            return View(pecaDeRoupa);
        }

        // GET: PecaDeRoupas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PecaDeRoupas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PecaDeRoupaId,TipoDeRoupa,Quantidade")] PecaDeRoupa pecaDeRoupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pecaDeRoupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pecaDeRoupa);
        }

        // GET: PecaDeRoupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecaDeRoupa = await _context.PecaDeRoupa.FindAsync(id);
            if (pecaDeRoupa == null)
            {
                return NotFound();
            }
            return View(pecaDeRoupa);
        }

        // POST: PecaDeRoupas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PecaDeRoupaId,TipoDeRoupa,Quantidade")] PecaDeRoupa pecaDeRoupa)
        {
            if (id != pecaDeRoupa.PecaDeRoupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pecaDeRoupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PecaDeRoupaExists(pecaDeRoupa.PecaDeRoupaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if(pecaDeRoupa.Quantidade == 0)
                {
                    return RedirectToAction("Enviar", pecaDeRoupa);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pecaDeRoupa);
        }

        // GET: PecaDeRoupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pecaDeRoupa = await _context.PecaDeRoupa
                .FirstOrDefaultAsync(m => m.PecaDeRoupaId == id);
            if (pecaDeRoupa == null)
            {
                return NotFound();
            }

            return View(pecaDeRoupa);
        }

        // POST: PecaDeRoupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pecaDeRoupa = await _context.PecaDeRoupa.FindAsync(id);
            _context.PecaDeRoupa.Remove(pecaDeRoupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PecaDeRoupaExists(int id)
        {
            return _context.PecaDeRoupa.Any(e => e.PecaDeRoupaId == id);
        }
    }
}
