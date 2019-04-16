using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Mappers
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Server");

            builder.HasKey(s => s.Name);

            builder.Property(s => s.Name).HasMaxLength(2);
            //builder.HasMany(s => s.Worlds).WithOne(w => w.Server).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
