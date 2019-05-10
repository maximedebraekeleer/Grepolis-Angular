using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private readonly DbSet<Server> _servers;
        private readonly GrepolistoolsContext _context;

        public ServerRepository(GrepolistoolsContext gContext)
        {
            _context = gContext;
            _servers = gContext.Servers;

        }

        public IEnumerable<Server> GetAll()
        {
            return _servers.AsNoTracking().ToList();
        }

        public Server GetServer(String name)
        {
            return _context.Servers.Include(s => s.Worlds).SingleOrDefault(s => s.Name == name);
        }

    }
}
