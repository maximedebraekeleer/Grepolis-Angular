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

            builder.HasKey(p => new { p.Id, p.World_Id, p.Server_Name,
                p.Date });


            builder.HasOne(p => p.World).WithMany(w => w.players).HasForeignKey(w => new { w.World_Id, w.Server_Name }).OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(p => p.PointsDefending).OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne(p => p.PointsAttacking).OnDelete(DeleteBehavior.Cascade);

        }
    }
}