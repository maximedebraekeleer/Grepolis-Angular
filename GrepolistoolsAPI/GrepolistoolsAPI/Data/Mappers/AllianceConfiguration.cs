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

            builder.HasKey(a => new { a.Id, a.World, a.Date });

            builder.Property(a => a.Name).IsRequired(false);

            builder.HasMany(a => a.players).WithOne(p => p.Alliance).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.World).WithMany(w => w.alliances).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.PointsAttacking).WithOne(a => a.Alliance).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
