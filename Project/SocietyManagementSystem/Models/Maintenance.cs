using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Maintenance
    {
        [Key]
        public int Id { get; set; } 

        [Display(Name ="Member")]
        public string Member_name  { get; set; }

        [Display(Name ="Member mail")]
        public string Member_mail { get; set; }

        [Display(Name ="House no")]
        public int house_no { get; set; }

        [Display(Name ="Water Charge")]
        public int water_charge { get; set; }

        [Display(Name ="Eelectricity Charge")]
        public int electricity_charge { get; set; }

        [Display(Name ="Parking Charge")]
        public int Parking_charge { get; set; }

        [Display(Name ="Service Charge")]
        public int service_charge { get; set; }

        [Display(Name="Area Charge")]
        public int housetype_charge { get; set; }

        [Display(Name ="Total Amount")]
        public int Total_Amount { get; set; }

        [Display(Name ="Status")]
        public int status { get; set; }

        [Display(Name ="Maintenance Date")]
        public DateTime Maintenance_date { get; set; }

        [Display(Name ="Due Date")]
        public DateTime Due_Date { get; set; }

        [Display(Name ="Sending Status")]
        public int sending_status { get; set; }



    }
}
