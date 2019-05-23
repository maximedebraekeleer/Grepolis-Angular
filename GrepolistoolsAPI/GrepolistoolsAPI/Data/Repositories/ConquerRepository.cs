using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class ConquerRepository : IConquerRepository
    {
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<Conquer> _conquers;

        public ConquerRepository(GrepolistoolsContext context)
        {
            _context = context;
            _conquers = context.Conquers;
        }

        //public IEnumerable<Conquer> GetLastConquers(int amount, String server, int world)
        //{
        //    return _conquers.Count();
        //}

        public IEnumerable<Conquer> GetFromTown(int town, String server, int world)
        {
            return _conquers.Where(c => c.Town_Id == town && c.Server_Name == server && c.World_Id == world);
        }

        public IEnumerable<Conquer> GetFromPlayer(int player, String server, int world)
        {
            return _conquers.Where(c => c.NewOwner == player || c.OldOwner == player && c.Server_Name == server && c.World_Id == world).AsNoTracking().ToList();
        }

        public IEnumerable<Conquer> GetFromAlliance(int alliance, String server, int world)
        {
            return _conquers.Where(c => c.NewAlliance == alliance || c.OldAlliance == alliance && c.Server_Name == server && c.World_Id == world);
        }

        public int[] GetConquersAndLossesFromPlayer(int player, String server, int world)
        {
            int[] result = new int[2];
            result[0] = _conquers.Distinct().Where(c => c.NewOwner == player && c.Server_Name == server && c.World_Id == world).AsNoTracking().Count();
            result[1] = _conquers.Distinct().Where(c => c.OldOwner == player && c.Server_Name == server && c.World_Id == world).AsNoTracking().Count();
            return result;
        }

    }
}
