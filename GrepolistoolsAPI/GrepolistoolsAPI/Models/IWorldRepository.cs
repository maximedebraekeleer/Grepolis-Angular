using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IWorldRepository
    {
        IEnumerable<World> GetAll();
        World GetById(int id, String server);
    }
}
