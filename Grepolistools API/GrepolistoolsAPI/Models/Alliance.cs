using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrepolistoolsAPI.Models
{
    public class Alliance
    {
        #region props
        [Required]
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Towns { get; set; }
        public int Rank { get; set; }

        public World World { get; private set; }

        public int PointsAttacking { get; set; }
        public int PointsDefending { get; set; }

        public DateTime Date { get; private set; }

        public ICollection<Player> players { get; set; }
        #endregion

    }
}