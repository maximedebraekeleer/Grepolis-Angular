using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class ConquerConfiguration : IEntityTypeConfiguration<Conquer>
    {
        public void Configure(EntityTypeBuilder<Conquer> builder)
        {
            builder.ToTable("Conquer");

            builder.HasKey(c => new {
                c.Town_Id, c.World_Id, c.Server_Name, 
                c.Date
            });

            builder.Property(c => c.NewAlliance).IsRequired(false);
            builder.Property(c => c.OldAlliance).IsRequired(false);
            builder.Property(c => c.OldOwner).IsRequired(false);

            builder.HasOne(c => c.World).WithMany(w => w.conquers).HasForeignKey(c => new { c.World_Id, c.Server_Name });
        }
    }
}