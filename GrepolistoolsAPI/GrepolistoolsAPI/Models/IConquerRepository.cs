using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IConquerRepository
    {
        IEnumerable<Conquer> GetFromTown(int id, string server, int world);
    }
}
