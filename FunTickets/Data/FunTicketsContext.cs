using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FunTickets.Models;

namespace FunTickets.Data
{
    public class FunTicketsContext : DbContext
    {
        internal object Activites;
        public FunTicketsContext(DbContextOptions<FunTicketsContext> options)
            : base(options)
        {
        }
        // DbSet for the Activite model, representing the Events table in the database
        public DbSet<FunTickets.Models.Activite> Event { get; set; } = default!; 
        public DbSet<FunTickets.Models.Category> Category { get; set; } = default!;

    }
}
