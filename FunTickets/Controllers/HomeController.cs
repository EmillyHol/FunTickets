using FunTickets.Data;
using FunTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace FunTickets.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FunTicketsContext _context;

        public HomeController(ILogger<HomeController> logger, FunTicketsContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        // HOME PAGE (List all Activites)
        public async Task<IActionResult> Index()
        {
            var activites = await _context.Activites
                .OrderByDescending(m => m.CreatedAt) // make sure your model has "CreatedAt"
                .Include(p => p.Category)
                .ToListAsync();

            return View(activites);
        }

        // DETAILS PAGE (Show one Activite)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activite = await _context.Activites
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ActiviteId == id);

            if (activite == null)
            {
                return NotFound();
            }

            return View(activite);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
