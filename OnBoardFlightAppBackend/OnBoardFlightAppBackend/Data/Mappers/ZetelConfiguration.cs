using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class ZetelConfiguration : IEntityTypeConfiguration<Zetel>
    {
        public void Configure(EntityTypeBuilder<Zetel> builder)
        {
            builder.ToTable("Zetel");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Rij);
            builder.Property(f => f.Klasse);
            builder.Property(f => f.Stoel);
            builder.HasOne(a => a.Passagier).WithOne().HasForeignKey<Zetel>(c => c.PassagierKey);
        }
    }
}
