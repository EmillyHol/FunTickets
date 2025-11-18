
using FunTickets.Data;
using FunTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FunTickets.Controllers
{
    [Authorize]
    public class ActivitesController : Controller
    {
        private readonly FunTicketsContext _context;
        private readonly IWebHostEnvironment _environment;

        public ActivitesController(FunTicketsContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            
        }

        // GET: Activites
        public async Task<IActionResult> Index()
        {
            var funTicketsContext = _context.Activites.Include(a => a.Category);
            return View(await funTicketsContext.ToListAsync());


        }

        // GET: Activites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites
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
        public async Task<IActionResult> Create([Bind("ActiviteId,ActiviteName,Location,Description,CategoryId,ActivityDateTime,Owner,FormFile")] Activite activite)
        {
            if (ModelState.IsValid)
            {
                // Set CreatedAt automatically
                activite.CreatedAt = DateTime.Now;

                //handle file upload (opcional)
                if (activite.FormFile != null)
                {
                    // Generate a unique file name with Guid
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(activite.FormFile.FileName);


                    // Store the filename in the database
                    activite.ImageFilename = fileName;

                    // Define the path to save the file
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);


                    // Save the file to the specified path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await activite.FormFile.CopyToAsync(stream);
                    }

                }
                _context.Add(activite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"Home"); // Redirect to Home index after creation

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

            var activite = await _context.Activites.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ActiviteId,ActiviteName,Location,Description,CategoryId,ActivityDateTime,Owner,FormFile")] Activite activite)
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
                    var existing = await _context.Activites.FindAsync(id);
                    if (existing == null)
                        return NotFound();

                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                     
                    // Ensure the directory exists
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    if (activite.FormFile != null && activite.FormFile.Length > 0)
                    {
                        // Generate a unique filename (keep original extension)
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(activite.FormFile.FileName);

                        // Define full path where file will be saved
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Save the file to the folder
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await activite.FormFile.CopyToAsync(stream);
                        }

                        // Delete the old image if one exists
                        if (!string.IsNullOrEmpty(existing.ImageFilename))
                        {
                            string oldFilePath = Path.Combine(uploadsFolder, existing.ImageFilename);
                            if (System.IO.File.Exists(oldFilePath))
                                System.IO.File.Delete(oldFilePath);
                        }

                        // Store the new filename in the database
                        existing.ImageFilename = uniqueFileName;
                    }
                    // Update only editable fields
                        existing.ActiviteName = activite.ActiviteName;
                        existing.Location = activite.Location;
                        existing.Description = activite.Description;
                        existing.FormFile = activite.FormFile;
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
                return RedirectToAction(nameof(Index), "Home");
            }
          

            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", activite.CategoryId);
            return RedirectToAction(nameof(Index), "Home");
        }
       

        // GET: Activites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);
            if (activite == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        // POST: Activites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activite = await _context.Activites.FindAsync(id);
            if (activite != null)
            {
                _context.Activites.Remove(activite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool ActiviteExists(int id)
        {
            return _context.Activites.Any(e => e.ActiviteId == id);
        }
    }
}
