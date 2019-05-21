using GrepolistoolsAPI.Data;
using GrepolistoolsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GrepolistoolsContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(GrepolistoolsContext context)
        {
            _context = context;
            _users = context.Users;
        }

        public User GetBy(string username)
        {
            return _users.SingleOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
