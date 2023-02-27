using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class GiveFeedback
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Feedback Subject")]
        public string feedback_subject { get; set; }

        [Display(Name = "Feedback Detail")]
        public string feedback_detail { get; set; }

        [Display(Name ="Owner Email")]
        public string owner_email { get; set; }
        
        [Display(Name ="House no")]
        public int houseno { get; set; }
    }
}
