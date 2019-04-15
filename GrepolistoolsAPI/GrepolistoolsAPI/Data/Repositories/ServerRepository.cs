using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class ServerRepository
    {
        private readonly DbSet<Server> _servers;
        GrepolistoolsContext _gContext;

        public ServerRepository(GrepolistoolsContext gContext)
        {
            _gContext = gContext;
            _servers = gContext.Servers;
        }

    }
}
