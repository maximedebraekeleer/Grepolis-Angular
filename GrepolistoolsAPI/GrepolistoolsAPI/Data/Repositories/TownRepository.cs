using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class TownRepository : ITownRepository
    {

        private readonly GrepolistoolsContext _context;
        private readonly DbSet<Town> _towns;
        private readonly DateTime recent = (DateTime.Now.Hour <= 1 ? DateTime.Today.AddDays(-1) : DateTime.Today);

        public TownRepository(GrepolistoolsContext context)
        {
            _context = context;
            _towns = context.Towns;
        }

        public IEnumerable<Town> GetAll(String server, int world)
        {
            return _towns.Where(t => t.Server_Name == server && t.World_Id == world && t.Date == recent).AsNoTracking().ToList();
        }

        public IEnumerable<Town> GetById(int id, String server, int world)
        {
            return _towns.Where(t => t.Id == id && t.Server_Name == server && t.World_Id == world).AsNoTracking().ToList();
        }

        public Town GetByIdDate(int id, String server, int world, String date)
        {
            return _towns.SingleOrDefault(t => t.Id == id && t.Server_Name == server && t.World_Id == world && t.Date == DateTime.Parse(date));
        }

        public IEnumerable<Town> GetFromPlayer(int player, String server, int world)
        {
            return _towns.Where(t => t.Player_Id == player && t.Server_Name == server && t.World_Id == world && t.Date == recent).AsNoTracking().ToList();
        }

    }
}
