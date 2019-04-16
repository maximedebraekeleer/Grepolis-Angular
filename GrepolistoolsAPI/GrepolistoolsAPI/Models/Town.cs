using System;
using System.Collections.Generic;

namespace GrepolistoolsAPI.Models
{
    public class Town
    {
        public int Id { get; private set; }
        public World World { get; private set; }
        public int World_Id { get; private set; }
        public string Server_Name { get; private set; }
        public int Player_Id { get; set; }
        public string Name { get; set; }
        public int Coord_X { get; private set; }
        public int Coord_Y { get; private set; }
        public int Points { get; set; }
        public DateTime Date { get; private set; }
    }
}