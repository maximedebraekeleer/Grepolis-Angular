using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrepolistoolsAPI.DTOs
{
    public class RegisterDTO : LoginDTO
    {

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [Compare("Password")]
        [RegularExpression(".{8,}", ErrorMessage = "Passwords must be at least 8 characters")]
        public String PasswordConfirmation { get; set; }
    }
}
