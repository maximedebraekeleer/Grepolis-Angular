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

            //builder.OwnsMany(w => w.players, w => {

            //    w.HasForeignKey(p => new { p.World_Id, p.Server_Name });
            //    w.HasKey(p => new { p.Id, p.World_Id, p.Server_Name, p.Date });

            //});
            //builder.OwnsMany(w => w.towns, w => {

            //    w.HasForeignKey(t => new { t.World_Id, t.Server_Name });
            //    w.HasKey(t => new { t.Id, t.World_Id, t.Server_Name, t.Date });

            //});
            //builder.OwnsMany(w => w.alliances, w => {

            //    w.HasForeignKey(a => new { a.World_Id, a.Server_Name });
            //    w.HasKey(a => new { a.Id, a.World_Id, a.Server_Name, a.Date });

            //});
            //builder.OwnsMany(w => w.conquers, w => {

            //    w.HasForeignKey(c => new { c.World_Id, c.Server_Name });
            //    w.HasKey(c => new { c.Date, c.Town_Id, c.World_Id, c.Server_Name });

            //});
            builder.HasOne(w => w.Server).WithMany(s => s.Worlds).HasForeignKey(w => w.Server_Name).OnDelete(DeleteBehavior.Restrict);
        }
    }
}