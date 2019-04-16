using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrepolistoolsAPI.Models
{
    public class World
    {
        #region props
        [Required]
        public int Id { get; private set; }
        [Required]
        public Server Server { get; private set; }
        public string Server_Name { get; private set; }
        [Required]
        public string Name { get; private set; }
        public bool isOpen { get; set; }
        [Required]
        public bool isDomination { get; set; }
        public DateTime lastModified { get; set; }
        public DateTime? closingDate { get; set; }

        public ICollection<Town> towns { get; private set; }
        public ICollection<Player> players { get; private set; }
        public ICollection<Alliance> alliances { get; private set; }
        public ICollection<Conquer> conquers { get; private set; }
        #endregion


    }
}