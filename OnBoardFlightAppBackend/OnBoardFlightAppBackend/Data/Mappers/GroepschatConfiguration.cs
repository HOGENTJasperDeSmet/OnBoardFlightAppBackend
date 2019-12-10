using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlightAppBackend.Data.Mappers
{
    public class GroepschatConfiguration : IEntityTypeConfiguration<Groepschat>
    {
        public void Configure(EntityTypeBuilder<Groepschat> builder)
        {
            builder.ToTable("Groepschat");
            builder.HasKey(g => g.Id);
            builder.HasMany(g => g.Passagiers).WithOne(p => p.Groepschat).HasForeignKey(g => g.GroepschatId);
        }
    }
}
