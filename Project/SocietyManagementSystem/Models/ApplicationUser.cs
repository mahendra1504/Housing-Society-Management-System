using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Member_Type { get; set; }
        public string Mobileno { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Total_Members { get; set; }
        public int House_no { get; set; }
        public int approve_status { get; set; }
        public int vechiles { get; set; }
    }
}
