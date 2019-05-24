using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class PlayerTrackerRepository
    {
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<PlayerTracker> _tracker;

        public PlayerTrackerRepository(GrepolistoolsContext context)
        {
            _context = context;
            _tracker = context.PlayerTracker;
        }

        public IEnumerable<PlayerTracker> GetFromUser(String username)
        {
            return _tracker.Where(t => t.Username == username);
        }

        public PlayerTracker GetTracker(string user, int player, string server, int world)
        {
            return _tracker.SingleOrDefault(pt => pt.Username == user && pt.Player_Id == player && pt.Server_Name == server && pt.World_Id == world);
        }

        public void Add(PlayerTracker tracker)
        {
            _tracker.Add(tracker);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
