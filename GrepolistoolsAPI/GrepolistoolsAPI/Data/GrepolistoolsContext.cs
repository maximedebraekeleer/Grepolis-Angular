using GrepolistoolsAPI.Data.Mappers;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrepolistoolsAPI.Data
{
    public class GrepolistoolsContext : IdentityDbContext
    {

        #region dbsets

        public DbSet<Server> Servers { get; set; }
        public DbSet<World> Worlds { get; set; }
        public DbSet<Alliance> Alliances { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Conquer> Conquers { get; set; }
        public DbSet<User> GrepoUsers { get; set; }

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
            builder.ApplyConfiguration(new Alliance_AttConfiguration());
            builder.ApplyConfiguration(new Alliance_DefConfiguration());
            builder.ApplyConfiguration(new Player_AttConfiguration());
            builder.ApplyConfiguration(new Player_DefConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }


    }
}
