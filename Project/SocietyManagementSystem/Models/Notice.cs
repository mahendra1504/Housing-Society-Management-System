using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Notice
    {
        [Key]
        public int Id  { get; set; }
        [Required(ErrorMessage ="Notice Titile can not be empty")]
        [Display(Name ="Notice Titile")]
        public string notice_subject { get; set; }

        [Required(ErrorMessage = "Notice Detail can not be empty")]
        [Display(Name = "Notice Detail")]
        public string notice_detail { get; set; }

        [Display(Name ="Notice Date")]
        public DateTime notice_date { get; set; }
    }
}
