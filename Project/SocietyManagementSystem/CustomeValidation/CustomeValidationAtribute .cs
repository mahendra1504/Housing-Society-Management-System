using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SocietyManagementSystem.Models;

namespace SocietyManagementSystem.CustomeValidation
{
    public class CustomeValidationAtribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string date = value.ToString();
            DateTime dateTime = DateTime.Parse(date);
            if(DateTime.Now.Year - dateTime.Year > 18)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage??"Member must be above 18");
            }
           
        }

    }
}
