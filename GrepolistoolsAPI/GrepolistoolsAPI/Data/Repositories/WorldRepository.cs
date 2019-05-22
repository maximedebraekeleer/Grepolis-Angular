using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class WorldRepository : IWorldRepository
    {
        private readonly DateTime recent = (DateTime.Now.Hour <= 1 ? DateTime.Today.AddDays(-1) : DateTime.Today);
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<World> _worlds;
        public WorldRepository(GrepolistoolsContext dbcontext)
        {
            _context = dbcontext;
            _worlds = dbcontext.Worlds;
        }

        public IEnumerable<World> GetAll()
        {
            return _worlds.AsNoTracking().ToList();
        }

        public IEnumerable<World> GetAllFromServer(String server)
        {
            return _worlds.AsNoTracking().Where(w => w.Server_Name == server).ToList();
        }

        public World GetById(String server, int id)
        {
            return _worlds.SingleOrDefault(w => w.Id == id && w.Server_Name == server);
        }

        public int WorldCount(String server)
        {
            return _worlds.Distinct().AsNoTracking().Where(w => w.Server_Name == server).Count();
        }

    }
}
