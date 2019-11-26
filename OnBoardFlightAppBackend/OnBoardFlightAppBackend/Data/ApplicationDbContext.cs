using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Vlucht> Flights { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Passagier> Passagiers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        
            base.OnModelCreating(modelBuilder);
        }
    }
}
