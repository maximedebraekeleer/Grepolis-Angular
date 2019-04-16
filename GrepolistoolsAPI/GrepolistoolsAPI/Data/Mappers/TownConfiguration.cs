using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Town");

            builder.HasKey(t => new { t.Id,
                t.World_Id, t.Server_Name, 
                t.Date });

            builder.HasOne(t => t.World).WithMany(w => w.towns).HasForeignKey(w => new { w.World_Id, w.Server_Name }).OnDelete(DeleteBehavior.Restrict);
        }
    }
}