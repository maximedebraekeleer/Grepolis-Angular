using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IWorldRepository
    {
        IEnumerable<World> GetAll();
        IEnumerable<World> GetAllFromServer(String server);
        World GetById(String server, int id);
        int WorldCount(String server);


    }
}
