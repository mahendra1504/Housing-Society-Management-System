using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Charges
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Charge name can not be empty")]
        [Display(Name ="Charge Name")]
        public string charge_name { get; set; }

        [Required(ErrorMessage ="Charge amount can not be empty")]
        [Display(Name ="Charge Amount")]
        public int charge_amount { get; set; }

        public DateTime charge_Date { get; set; }
    }
}
