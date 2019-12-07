using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data.Mappers
{
    public class BestellingTKConfiguration : IEntityTypeConfiguration<BestellingTK>
    {
        public void Configure(EntityTypeBuilder<BestellingTK> builder)
        {
            builder.ToTable("BestellingTK");
            builder.HasKey(f => new { f.BestellingId, f.BestellingOptieId });
        }
    }
}
