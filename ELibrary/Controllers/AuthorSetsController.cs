using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELibrary.Models;

namespace ELibrary.Controllers
{
    public class AuthorSetsController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorSetsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: AuthorSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthorSet.ToListAsync());
        }

        // GET: AuthorSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorSet = await _context.AuthorSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorSet == null)
            {
                return NotFound();
            }

            return View(authorSet);
        }

        // GET: AuthorSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AuthorSet authorSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authorSet);
        }

        // GET: AuthorSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorSet = await _context.AuthorSet.FindAsync(id);
            if (authorSet == null)
            {
                return NotFound();
            }
            return View(authorSet);
        }

        // POST: AuthorSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AuthorSet authorSet)
        {
            if (id != authorSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorSetExists(authorSet.Id))
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
            return View(authorSet);
        }

        // GET: AuthorSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorSet = await _context.AuthorSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authorSet == null)
            {
                return NotFound();
            }

            return View(authorSet);
        }

        // POST: AuthorSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorSet = await _context.AuthorSet.FindAsync(id);
            _context.AuthorSet.Remove(authorSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorSetExists(int id)
        {
            return _context.AuthorSet.Any(e => e.Id == id);
        }
    }
}
