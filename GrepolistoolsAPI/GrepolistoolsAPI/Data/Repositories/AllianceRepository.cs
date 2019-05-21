using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class AllianceRepository : IAllianceRepository
    {
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<Alliance> _alliances;
        private readonly DateTime recent = (DateTime.Now.Hour <= 1 ? DateTime.Today.AddDays(-1) : DateTime.Today);

        public AllianceRepository(GrepolistoolsContext context)
        {
            _context = context;
            _alliances = context.Alliances;
        }

        public IEnumerable<Alliance> GetAll(String server, int world)
        {
            return _alliances.Include(a => a.PointsAttacking).Include(a => a.PointsDefending).Where(a => a.Server_Name == server && a.World_Id == world && a.Date == recent).OrderBy(a => a.Rank).AsNoTracking().ToList();
        }

        public IEnumerable<Alliance> GetById(int id, String server, int world)
        {
            return _alliances.Include(a => a.PointsAttacking).Include(a => a.PointsDefending).Where(a => a.Id == id && a.Server_Name == server && a.World_Id == world).OrderBy(a => a.Date).AsNoTracking().ToList();
        }

        public Alliance GetByIdDate(int id, String server, int world, String date)
        {
            return _alliances.Include(a => a.PointsAttacking).Include(a => a.PointsDefending).SingleOrDefault(a => a.Id == id && a.Server_Name == server && a.World_Id == world && a.Date == DateTime.Parse(date));
        }

        public IEnumerable<Alliance> GetTop(int top, String server, int world)
        {
            return _alliances.Include(a => a.PointsAttacking).Include(a => a.PointsDefending).Where(a => a.Rank <= top && a.Server_Name == server && a.World_Id == world && a.Date == recent).OrderBy(a => a.Rank).AsNoTracking().ToList();
        }

        public int AllianceCount(String server, int world = -1)
        {
            if(world == -1)
            {
                return _alliances.Distinct().AsNoTracking().Select(a => new { a.Id, a.Server_Name, a.Date }).Distinct()
                    .Where(a => a.Server_Name == server && a.Date == recent).Count();
            }
            else
            {
                return _alliances.Distinct().AsNoTracking().Select(a => new { a.Id, a.Server_Name, a.World_Id, a.Date }).Distinct()
                    .Where(a => a.Server_Name == server && a.World_Id == world && a.Date == recent).Count();
            }
        }

    }
}
