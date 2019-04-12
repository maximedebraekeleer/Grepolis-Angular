using System;
using System.Collections.Generic;

namespace GrepolistoolsAPI.Models
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public Alliance Alliance { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public World World { get; private set; }
        public DateTime Date { get; private set; }

        public int PointsAttacking { get; set; }
        public int PointsDefending { get; set; }

        public ICollection<Town> towns { get; set; }


    }
}