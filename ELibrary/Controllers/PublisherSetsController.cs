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
    public class PublisherSetsController : Controller
    {
        private readonly LibraryContext _context;

        public PublisherSetsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: PublisherSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.PublisherSet.ToListAsync());
        }

        // GET: PublisherSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisherSet = await _context.PublisherSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publisherSet == null)
            {
                return NotFound();
            }

            return View(publisherSet);
        }

        // GET: PublisherSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PublisherSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PublisherSet publisherSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisherSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publisherSet);
        }

        // GET: PublisherSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisherSet = await _context.PublisherSet.FindAsync(id);
            if (publisherSet == null)
            {
                return NotFound();
            }
            return View(publisherSet);
        }

        // POST: PublisherSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PublisherSet publisherSet)
        {
            if (id != publisherSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisherSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherSetExists(publisherSet.Id))
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
            return View(publisherSet);
        }

        // GET: PublisherSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisherSet = await _context.PublisherSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publisherSet == null)
            {
                return NotFound();
            }

            return View(publisherSet);
        }

        // POST: PublisherSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherSet = await _context.PublisherSet.FindAsync(id);
            _context.PublisherSet.Remove(publisherSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherSetExists(int id)
        {
            return _context.PublisherSet.Any(e => e.Id == id);
        }
    }
}
