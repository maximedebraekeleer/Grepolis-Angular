using GrepolistoolsAPI.Data.Mappers;
using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data
{
    public class GrepolistoolsContext : DbContext
    {

        #region dbsets

        public DbSet<Server> Servers { get; set; }
        public DbSet<World> Worlds { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Conquer> Conquers { get; set; }

        #endregion

        public GrepolistoolsContext(DbContextOptions<GrepolistoolsContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ServerConfiguration());
            builder.ApplyConfiguration(new WorldConfiguration());
            builder.ApplyConfiguration(new AllianceConfiguration());
            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new TownConfiguration());
            builder.ApplyConfiguration(new ConquerConfiguration());
        }


    }
}
