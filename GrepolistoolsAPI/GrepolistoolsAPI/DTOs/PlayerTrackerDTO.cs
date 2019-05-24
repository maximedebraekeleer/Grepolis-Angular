using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.DTOs
{
    public class PlayerTrackerDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Server_Name { get; set; }
        [Required]
        public int World_Id { get; set; }

        [Required]
        public int Player_Id { get; set; }
    }
}
