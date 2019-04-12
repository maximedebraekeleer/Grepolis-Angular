using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrepolistoolsAPI.Data.Mappers
{
    internal class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Town");

            builder.HasKey(t => new { t.Id, t.World, t.Date });

            builder.HasOne(t => t.Player).WithMany(p => p.towns).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.World).WithMany(w => w.towns).OnDelete(DeleteBehavior.Restrict);
        }
    }
}