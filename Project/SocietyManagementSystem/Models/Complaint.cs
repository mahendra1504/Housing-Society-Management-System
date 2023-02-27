using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Complaint Subject")]
        public string complaint_subject { get; set; }

        [Display(Name ="Complaint Detail")]
        public string complaint_detail { get; set; }

        [Display(Name ="Member Mail")]
        public string Member_mail { get; set; }

        [Display(Name ="House no")]
        public int house_no { get; set; }

        [Display(Name ="Complaint Date")]
        public DateTime complaint_date { get; set; }

        [Display(Name ="Complaint Status")]
        public string complaint_status { get; set; }

        [Display(Name ="Solution")]
        public string solution { get; set; }
    }
}
