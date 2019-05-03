using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IServerRepository
    {
        IEnumerable<Server> GetAll();
        Server GetServer(String name);
    }
}
