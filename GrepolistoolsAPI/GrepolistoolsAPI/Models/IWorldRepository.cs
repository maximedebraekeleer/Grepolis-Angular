using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IWorldRepository
    {
        IEnumerable<World> GetAll();
        World GetById(String server, int id);
        int GetPlayerCount(String server, int id);
        int GetAllianceCount(String server, int id);


    }
}
