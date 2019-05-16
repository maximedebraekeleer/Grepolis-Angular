using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public interface IUserRepository
    {
        User GetBy(string username);
        void AddUser(User user);
        void SaveChanges();
    }
}
