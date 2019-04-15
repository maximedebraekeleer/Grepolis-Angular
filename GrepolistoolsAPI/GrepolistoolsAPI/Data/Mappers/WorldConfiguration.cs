using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class WorldConfiguration : IEntityTypeConfiguration<World>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<World> builder)
        {
            builder.ToTable("World");

            builder.HasKey(w => new { w.Id, w.Server });

            builder.Property(w => w.Name).IsRequired(true);
            builder.Property(w => w.isOpen).HasDefaultValue(true);
            builder.Property(w => w.closingDate).IsRequired(false);

            builder.HasMany(w => w.alliances).WithOne(a => a.World).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(w => w.players).WithOne(p => p.World).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(w => w.towns).WithOne(t => t.World).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(w => w.conquers).WithOne(c => c.World).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(w => w.Server).WithMany(s => s.Worlds).OnDelete(DeleteBehavior.Restrict);
        }
    }
}