using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class Alliance_AttConfiguration : IEntityTypeConfiguration<Alliance_Att>
    {
        public void Configure(EntityTypeBuilder<Alliance_Att> builder)
        {
            builder.ToTable("Alliance_Att");

            builder.HasOne(a => a.Alliance).WithOne(a => a.PointsAttacking);
        }
    }
}
