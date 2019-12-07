using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Mappers
{
    public class BestellingConfiguration : IEntityTypeConfiguration<Bestelling>
    {
        public void Configure(EntityTypeBuilder<Bestelling> builder)
        {
            builder.ToTable("Bestelling");
            builder.HasKey(f => f.Id);
            builder.HasMany(f => f.BestellingTKs).WithOne();
        }
    }


}
