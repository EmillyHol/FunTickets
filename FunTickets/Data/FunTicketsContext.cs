using FunTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace FunTickets.Data
{
    public class FunTicketsContext : DbContext
    {
        public FunTicketsContext(DbContextOptions<FunTicketsContext> options)
            : base(options)
        {
        }

        // DbSet for the Activite model, representing the Events table in the database
        public DbSet<Activite> Activites { get; set; } = default!; 
        public DbSet<Category> Categories { get; set; } = default!;

    }
}
