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
    public class AuthorPublishersController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorPublishersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: AuthorPublishers
        public async Task<IActionResult> Index()
        {
            var libraryContext = _context.AuthorPublisher.Include(a => a.Author).Include(a => a.Publisher);
            return View(await libraryContext.ToListAsync());
        }

        // GET: AuthorPublishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorPublisher = await _context.AuthorPublisher
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorPublisher == null)
            {
                return NotFound();
            }

            return View(authorPublisher);
        }

        // GET: AuthorPublishers/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.AuthorSet, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.PublisherSet, "Id", "Name");
            return View();
        }

        // POST: AuthorPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,PublisherId")] AuthorPublisher authorPublisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorPublisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorSet, "Id", "Name", authorPublisher.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.PublisherSet, "Id", "Name", authorPublisher.PublisherId);
            return View(authorPublisher);
        }

        // GET: AuthorPublishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorPublisher = await _context.AuthorPublisher.FindAsync(id);
            if (authorPublisher == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.AuthorSet, "Id", "Name", authorPublisher.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.PublisherSet, "Id", "Name", authorPublisher.PublisherId);
            return View(authorPublisher);
        }

        // POST: AuthorPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorId,PublisherId")] AuthorPublisher authorPublisher)
        {
            if (id != authorPublisher.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorPublisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorPublisherExists(authorPublisher.AuthorId))
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
            ViewData["AuthorId"] = new SelectList(_context.AuthorSet, "Id", "Name", authorPublisher.AuthorId);
            ViewData["PublisherId"] = new SelectList(_context.PublisherSet, "Id", "Name", authorPublisher.PublisherId);
            return View(authorPublisher);
        }

        // GET: AuthorPublishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorPublisher = await _context.AuthorPublisher
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (authorPublisher == null)
            {
                return NotFound();
            }

            return View(authorPublisher);
        }

        // POST: AuthorPublishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorPublisher = await _context.AuthorPublisher.FindAsync(id);
            _context.AuthorPublisher.Remove(authorPublisher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorPublisherExists(int id)
        {
            return _context.AuthorPublisher.Any(e => e.AuthorId == id);
        }
    }
}
