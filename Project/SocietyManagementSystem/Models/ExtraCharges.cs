using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class ExtraCharges
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="House no can not be empty")]
        [Display(Name ="House no")]
        public int house_no { get; set; }

        [Required(ErrorMessage ="Charge Type can not be empty")]
        [Display(Name ="Charge Type")]
        public string charge_type { get; set; }

        [Required(ErrorMessage ="Charge Amount can not be empty")]
        [Display(Name ="Charge Amount")]
        public int Amount { get; set; }

        [Display(Name ="Charge Date")]
        public DateTime Charge_date { get; set; }
        public int status { get; set; }
    }
}
