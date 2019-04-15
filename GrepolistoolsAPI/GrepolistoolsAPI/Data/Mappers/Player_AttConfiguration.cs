using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class Player_AttConfiguration : IEntityTypeConfiguration<Player_Att>
    {
        public void Configure(EntityTypeBuilder<Player_Att> builder)
        {
            builder.ToTable("Player_Att");

            builder.HasKey(p => p.Player);
            builder.HasOne(p => p.Player).WithOne(p => p.PointsAttacking);
        }
    }
}
