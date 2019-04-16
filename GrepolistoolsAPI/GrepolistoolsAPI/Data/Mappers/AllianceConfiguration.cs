using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class AllianceConfiguration : IEntityTypeConfiguration<Alliance>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Alliance> builder)
        {
            builder.ToTable("Alliance");

            builder.HasKey(a => new { a.Id,
                a.World_Id, a.Server_Name,
                a.Date });

            builder.HasOne(a => a.World).WithMany(w => w.alliances).HasForeignKey(a => new { a.World_Id, a.Server_Name }).OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(a => a.PointsAttacking).OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne(a => a.PointsDefending).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
