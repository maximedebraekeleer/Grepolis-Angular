using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {

        private readonly DateTime recent = (DateTime.Now.Hour <= 1 ? DateTime.Today.AddDays(-1) : DateTime.Today);
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<Player> _players;

        public PlayerRepository(GrepolistoolsContext context)
        {
            _context = context;
            _players = context.Players;
        }

        public IEnumerable<Player> GetAll(String server, int id)
        {
            return _context.Players.Include(p => p.PointsAttacking).Include(p => p.PointsDefending).Where(p => p.Server_Name == server && p.World_Id == id && p.Date == recent).OrderBy(p => p.Rank).AsNoTracking().ToList();
        }

        public IEnumerable<Player> GetById(int id, String server, int world)
        {
            return _context.Players.Include(p => p.PointsAttacking).Include(p => p.PointsDefending).Where(p => p.Id == id && p.Server_Name == server && p.World_Id == world).AsNoTracking().ToList();
        }

        public Player GetByIdDate(int id, String server, int world, String date)
        {
            return _context.Players.Include(p => p.PointsAttacking).Include(p => p.PointsDefending).SingleOrDefault(p => p.Id == id && p.Server_Name == server && p.World_Id == world && p.Date == DateTime.Parse(date));
        }

        public IEnumerable<Player> GetTop(int top, String server, int world)
        {
            return _players.Include(p => p.PointsAttacking).Include(p => p.PointsDefending).Where(p => p.Rank <= top && p.Server_Name == server && p.World_Id == world && p.Date == recent).OrderBy(p => p.Rank).AsNoTracking().ToList();
        }

    }
}
