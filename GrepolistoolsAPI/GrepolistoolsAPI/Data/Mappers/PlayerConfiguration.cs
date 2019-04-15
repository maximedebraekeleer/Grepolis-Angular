using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasKey(p => new { p.Id, p.World, p.Date });

            builder.HasOne(p => p.Alliance).WithMany(a => a.players).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.World).WithMany(w => w.players).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.towns).WithOne(t => t.Player).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.PointsDefending).WithOne(p => p.Player).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.PointsAttacking).WithOne(p => p.Player).OnDelete(DeleteBehavior.Cascade);

        }
    }
}