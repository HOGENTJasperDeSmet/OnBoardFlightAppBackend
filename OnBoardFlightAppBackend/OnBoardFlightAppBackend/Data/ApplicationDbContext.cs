using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using On_board_flight_app_backend.Data.Mappers;
using On_board_flight_app_backend.Models;
using OnBoardFlightAppBackend.Data.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public DbSet<Vlucht> Flights { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Zetel> Zetels { get; set; }
        public DbSet<Passagier> Passagiers { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<BestellingTK> BestellingTKs { get; set; }
        public DbSet<BestellingOptie> BestellingOpties { get; set; }
        public DbSet<Groepschat> Groepschatten { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BestellingConfiguration());
            builder.ApplyConfiguration(new BestellingTKConfiguration());
            builder.ApplyConfiguration(new PassagierConfiguration());
            builder.ApplyConfiguration(new ZetelConfiguration());
            builder.ApplyConfiguration(new GroepschatConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
