using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class AllianceRepository
    {
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<Alliance> _alliances;

        public AllianceRepository(GrepolistoolsContext context)
        {
            _context = context;
            _alliances = context.Alliances;
        }

        public GetAll(String server, int world)
        {

        }


    }
}
