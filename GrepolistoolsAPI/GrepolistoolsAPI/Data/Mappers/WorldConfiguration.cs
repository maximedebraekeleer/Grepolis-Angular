using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class WorldConfiguration : IEntityTypeConfiguration<World>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<World> builder)
        {
            builder.ToTable("World");

            builder.HasKey(w => new { w.Id,
                w.Server_Name 
            });

            builder.Property(w => w.Name).IsRequired(true);
            builder.Property(w => w.isOpen).HasDefaultValue(true);
            builder.Property(w => w.closingDate).IsRequired(false);

            builder.HasMany(w => w.players).WithOne(p => p.World).HasForeignKey(p => new { p.World_Id, p.Server_Name });
            builder.HasMany(w => w.alliances).WithOne(a => a.World).HasForeignKey(a => new { a.World_Id, a.Server_Name });
            builder.HasMany(w => w.towns).WithOne(t => t.World).HasForeignKey(t => new { t.World_Id, t.Server_Name });
            builder.HasMany(w => w.conquers).WithOne(c => c.World).HasForeignKey(c => new { c.World_Id, c.Server_Name });

            builder.HasOne(w => w.Server).WithMany(s => s.Worlds).HasForeignKey(w => w.Server_Name).OnDelete(DeleteBehavior.Restrict);
        }
    }
}