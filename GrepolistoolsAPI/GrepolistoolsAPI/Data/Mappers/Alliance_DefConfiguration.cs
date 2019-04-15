using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class Alliance_DefConfiguration : IEntityTypeConfiguration<Alliance_Def>
    {
        public void Configure(EntityTypeBuilder<Alliance_Def> builder)
        {
            builder.ToTable("Alliance_Def");

            builder.HasKey(a => a.Alliance);
            builder.HasOne(a => a.Alliance).WithOne(a => a.PointsDefending);

        }
    }
}
