using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEWS_SITE.Models;

namespace NEWS_SITE.Controllers
{
    public class CatogeriesController : Controller
    {
        private readonly NewsContext _context;

        public CatogeriesController(NewsContext context)
        {
            _context = context;
        }

        // GET: Catogeries
        public async Task<IActionResult> Index()
        {
            return View(await _context.catogeries.ToListAsync());
        }

        // GET: Catogeries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogery = await _context.catogeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catogery == null)
            {
                return NotFound();
            }

            return View(catogery);
        }

        // GET: Catogeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catogeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Catogery catogery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catogery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catogery);
        }

        // GET: Catogeries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogery = await _context.catogeries.FindAsync(id);
            if (catogery == null)
            {
                return NotFound();
            }
            return View(catogery);
        }

        // POST: Catogeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Catogery catogery)
        {
            if (id != catogery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catogery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatogeryExists(catogery.Id))
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
            return View(catogery);
        }

        // GET: Catogeries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogery = await _context.catogeries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catogery == null)
            {
                return NotFound();
            }

            return View(catogery);
        }

        // POST: Catogeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catogery = await _context.catogeries.FindAsync(id);
            _context.catogeries.Remove(catogery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatogeryExists(int id)
        {
            return _context.catogeries.Any(e => e.Id == id);
        }
    }
}
