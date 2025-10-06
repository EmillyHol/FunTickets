using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunTickets.Data;
using FunTickets.Models;

namespace FunTickets.Controllers
{
    public class ActivitesController : Controller
    {
        private readonly FunTicketsContext _context;

        public ActivitesController(FunTicketsContext context)
        {
            _context = context;
        }

        // GET: Activites
        public async Task<IActionResult> Index()
        {
            var funTicketsContext = _context.Event.Include(a => a.Category);
            return View(await funTicketsContext.ToListAsync());


        }

        // GET: Activites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Event
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // GET: Activites/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: Activites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActiviteId,ActiviteName,Location,Description,CategoryId,EventDateTime,Owner")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                // Set CreatedAt automatically
                activite.CreatedAt = DateTime.Now;

                _context.Add(activite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", activite.CategoryId);
            return View(activite);
        }

        // GET: Activites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Event.FindAsync(id);
            if (activite == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", activite.CategoryId);
            return View(activite);
        }

        // POST: Activites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActiviteId,ActiviteName,Location,Description,CategoryId,EventDateTime,Owner")] Activite activite)
        {
            if (id != activite.ActiviteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Get the existing entity (tracked by EF)
                    var existing = await _context.Event.FindAsync(id);
                    if (existing == null)
                        return NotFound();

                    // Update only editable fields
                    existing.ActiviteName = activite.ActiviteName;
                    existing.Location = activite.Location;
                    existing.Description = activite.Description;
                    existing.CategoryId = activite.CategoryId;
                    existing.ActivityDateTime = activite.ActivityDateTime;
                    existing.Owner = activite.Owner;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiviteExists(activite.ActiviteId))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", activite.CategoryId);
            return View(activite);
        }

        // GET: Activites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Event
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activite = await _context.Event.FindAsync(id);
            if (activite != null)
            {
                _context.Event.Remove(activite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiviteExists(int id)
        {
            return _context.Event.Any(e => e.ActiviteId == id);
        }
    }
}
