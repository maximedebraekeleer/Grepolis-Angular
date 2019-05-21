using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IAllianceRepository
    {
        IEnumerable<Alliance> GetAll(String server, int world);
        IEnumerable<Alliance> GetById(int id, String server, int world);
        Alliance GetByIdDate(int id, String server, int world, String date);
        IEnumerable<Alliance> GetTop(int top, String server, int world);
        int AllianceCount(String server, int world = -1);
    }
}
