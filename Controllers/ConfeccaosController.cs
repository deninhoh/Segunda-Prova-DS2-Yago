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
    public class ConfeccaosController : Controller
    {
        private readonly ProvaDS2DennerContext _context;

        public ConfeccaosController(ProvaDS2DennerContext context)
        {
            _context = context;
        }

        // GET: Confeccaos
        public async Task<IActionResult> Index()
        {
            var provaDS2DennerContext = _context.Confeccao.Include(c => c.PecaDeRoupa);
            return View(await provaDS2DennerContext.ToListAsync());
        }

        // GET: Confeccaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccao = await _context.Confeccao
                .Include(c => c.PecaDeRoupa)
                .FirstOrDefaultAsync(m => m.ConfeccaoId == id);
            if (confeccao == null)
            {
                return NotFound();
            }

            return View(confeccao);
        }

        // GET: Confeccaos/Create
        public IActionResult Create()
        {
            ViewData["PecaDeRoupaId"] = new SelectList(_context.PecaDeRoupa, "PecaDeRoupaId", "PecaDeRoupaId");
            return View();
        }

        // POST: Confeccaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfeccaoId,PecaDeRoupaId,Data")] Confeccao confeccao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confeccao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PecaDeRoupaId"] = new SelectList(_context.PecaDeRoupa, "PecaDeRoupaId", "PecaDeRoupaId", confeccao.PecaDeRoupaId);
            return View(confeccao);
        }

        // GET: Confeccaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccao = await _context.Confeccao.FindAsync(id);
            if (confeccao == null)
            {
                return NotFound();
            }
            ViewData["PecaDeRoupaId"] = new SelectList(_context.PecaDeRoupa, "PecaDeRoupaId", "PecaDeRoupaId", confeccao.PecaDeRoupaId);
            return View(confeccao);
        }

        // POST: Confeccaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfeccaoId,PecaDeRoupaId,Data")] Confeccao confeccao)
        {
            if (id != confeccao.ConfeccaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confeccao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfeccaoExists(confeccao.ConfeccaoId))
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
            ViewData["PecaDeRoupaId"] = new SelectList(_context.PecaDeRoupa, "PecaDeRoupaId", "PecaDeRoupaId", confeccao.PecaDeRoupaId);
            return View(confeccao);
        }

        // GET: Confeccaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confeccao = await _context.Confeccao
                .Include(c => c.PecaDeRoupa)
                .FirstOrDefaultAsync(m => m.ConfeccaoId == id);
            if (confeccao == null)
            {
                return NotFound();
            }

            return View(confeccao);
        }

        // POST: Confeccaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confeccao = await _context.Confeccao.FindAsync(id);
            _context.Confeccao.Remove(confeccao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfeccaoExists(int id)
        {
            return _context.Confeccao.Any(e => e.ConfeccaoId == id);
        }
    }
}
