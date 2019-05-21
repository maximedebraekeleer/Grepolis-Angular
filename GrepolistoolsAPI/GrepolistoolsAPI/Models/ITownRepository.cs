using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface ITownRepository
    {
        IEnumerable<Town> GetAll(String server, int world);
        IEnumerable<Town> GetById(int id, String server, int world);
        Town GetByIdDate(int id, String server, int world, String date);
        IEnumerable<Town> GetFromPlayer(int player, String server, int world);
        int TownCount(String server, int world = -1);
    }
}
