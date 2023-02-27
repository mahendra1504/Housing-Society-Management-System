using Microsoft.AspNetCore.Identity;
using SocietyManagementSystem.CustomeValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Registration : IdentityUser
    {
        [Key]
        public string Id { get; set; }
      //  [RegularExpression("A-Za-z",ErrorMessage ="Firstname accept only alphabets")]
        [Required(ErrorMessage ="Firstname can not be empty")]
        [Display(Name ="Firstname")]
        public string Firstname { get; set; }

       // [RegularExpression("A-Za-z", ErrorMessage = "Lastname accept only alphabets")]
        [Required(ErrorMessage = "Lastname  can not be empty")]
        [Display(Name="Lastname")]
        public string Lastname  { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please Enter valid email")]
        [Display(Name ="Email")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobileno can not be empty")]
        [Display(Name ="Mobileno")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Please enter valid phone number")]
        [Phone(ErrorMessage ="Please enter valid mobile number")]
        public string Mobileno { get; set; }

        [CustomeValidationAtribute(ErrorMessage ="Member should be above 18")]
        [Display(Name="Date Of Birth")]
        [Required(ErrorMessage ="Date Of Birth can not be empty")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Total Members can not be empty")]
        [Display(Name ="Total Members")]
        public int Total_Members { get; set; }

        [Display(Name ="Member Type")]
        public string MemberType { get; set; }

        [Display(Name ="House no")]
        public int house_no { get; set; }
        public int House_no { get; internal set; }
        [Required(ErrorMessage = "Password can not be empty")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword",ErrorMessage ="Password and Confirm Password are not same")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can not be empty")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Vechiles can not be empty")]
        [Display(Name ="Number of Vechiles")]
        public int vechiles { get; set; }
        public DateTime DateOfBirth { get; internal set; }
    }
}
