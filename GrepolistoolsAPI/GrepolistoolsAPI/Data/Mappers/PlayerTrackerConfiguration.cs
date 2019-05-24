using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class PlayerTrackerConfiguration : IEntityTypeConfiguration<PlayerTracker>
    {
        public void Configure(EntityTypeBuilder<PlayerTracker> builder)
        {
            builder.HasKey(p => new { p.Username, p.Player_Id, p.Server_Name, p.World_Id });
            builder.Property(p => p.Server_Name).HasMaxLength(2);
        }
    }
}
