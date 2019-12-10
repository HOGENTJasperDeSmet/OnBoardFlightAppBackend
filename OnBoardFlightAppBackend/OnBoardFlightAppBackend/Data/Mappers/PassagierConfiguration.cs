using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using On_board_flight_app_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_board_flight_app_backend.Data
{
    public class PassagierConfiguration : IEntityTypeConfiguration<Passagier>
    {
        public void Configure(EntityTypeBuilder<Passagier> builder)
        {
            builder.ToTable("Passagier");
            builder.HasKey(f => f.Id);
        }
    }
}
