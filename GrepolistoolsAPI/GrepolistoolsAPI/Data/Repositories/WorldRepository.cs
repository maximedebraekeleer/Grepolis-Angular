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

        private readonly GrepolistoolsContext _context;
        private readonly DbSet<World> _worlds;
        public WorldRepository(GrepolistoolsContext dbcontext)
        {
            _context = dbcontext;
            _worlds = dbcontext.Worlds;
        }

        public IEnumerable<World> GetAll()
        {
            return _worlds;
        }

        public World GetById(int id, String server)
        {
            return _worlds.SingleOrDefault(w => w.Id == id && w.Server_Name == server);
        }

    }
}
