using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll(String server, int id);
        IEnumerable<Player> GetById(int id, String server, int world);
        IEnumerable<Player> GetByName(String name, String server, int world);
        Player GetByIdDate(int id, String server, int world, String date);
        IEnumerable<Player> GetTop(int top, String server, int world);
        int PlayerCount(String server, int world = -1);
        bool CheckPlayer(int player, String server, int world);

    }
}
