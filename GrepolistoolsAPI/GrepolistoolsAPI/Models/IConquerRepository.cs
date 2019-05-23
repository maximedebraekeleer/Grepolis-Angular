using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IConquerRepository
    {
        IEnumerable<Conquer> GetFromTown(int id, String server, int world);
        IEnumerable<Conquer> GetFromPlayer(int player, String server, int world);
        IEnumerable<Conquer> GetFromAlliance(int alliance, String server, int world);
        int[] GetConquersAndLossesFromPlayer(int player, String server, int world);
    }
}
