using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Email field can not be empty")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please enter valid email")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field can not be empty")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
