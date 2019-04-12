using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.Models
{
    public class Server
    {
        #region props

        [Required]
        public string Name { get; private set; }

        public ICollection<World> Worlds { get; private set; }

        #endregion

        #region ctor 

        public Server(string Name)
        {
            this.Name = Name;
        }

        #endregion

        #region methods

        public void AddWorld(World world) => Worlds.Add(world);

        public World GetWorld(int id) => Worlds.SingleOrDefault(w => w.Id == id);

        #endregion
    }
}
