using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IPlayerTrackerRepository
    {
        IEnumerable<PlayerTracker> GetFromUser(String Username);
        void Add(PlayerTracker tracker);
        void SaveChanges();
        PlayerTracker GetTracker(string user, int player, string server, int world);
    }
}
