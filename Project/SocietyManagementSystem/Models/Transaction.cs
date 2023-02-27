using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Transaction
    {
        [Key]
        [Display(Name = "Transaction Id")]
        public int Id { get; set; }

        [Display(Name ="Maintenance Id")]
        public int Maintenance_id { get; set; }

        [Display(Name ="Charge Id")]
        public int Charge_id { get; set; }

        [Display(Name ="Transaction Name")]
        public string transaction_name { get; set; }

        [Display(Name ="House no")]
        public int house_no { get; set; }

        [Display(Name ="Member Name")]
        public string member_name { get; set; }

        [Display(Name = "Member Email")]
        public string member_email { get; set; }

        [Display(Name = "Amount")]
        public int transaction_amount { get; set; }

        [Display(Name = "Date")]
        public DateTime transaction_date { get; set; }

    }
}
