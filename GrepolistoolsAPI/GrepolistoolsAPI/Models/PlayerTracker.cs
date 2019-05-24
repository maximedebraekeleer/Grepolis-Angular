using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public class PlayerTracker
    {
        public int Player_Id { get; set; }
        public String Username { get; set; }
        public int World_Id { get; set; }
        public String Server_Name { get; set; }
    }
}
