using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class Player_DefConfiguration : IEntityTypeConfiguration<Player_Def>
    {
        public void Configure(EntityTypeBuilder<Player_Def> builder)
        {
            builder.ToTable("Player_Def");
        }
    }
}
