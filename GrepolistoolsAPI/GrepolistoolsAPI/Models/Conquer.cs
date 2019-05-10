using System;

namespace GrepolistoolsAPI.Models
{
    public class Conquer
    {
        public DateTime Date { get; private set; }
        public int Town_Id { get; private set; }
        public World World { get; set; }
        public int World_Id { get; private set; }
        public string Server_Name { get; private set; }
        public int OldOwner { get; private set; }
        public int NewOwner { get; private set; }
        public int OldAlliance { get; private set; }
        public int NewAlliance { get; private set; }
        public int Points { get; private set; }
    }
}