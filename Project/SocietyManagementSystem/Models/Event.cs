using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Event name can not be empty")]
        [Display(Name="Event Name")]
        public string event_name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Event Date can not be empty")]
        [Display(Name = "Event Date")]
        public DateTime event_date { get; set; }

        [Required(ErrorMessage = "Event Start Time can not be empty")]
        [Display(Name ="Event Start Time")]
        public TimeSpan event_startime { get; set; }

        [Required(ErrorMessage = "Event End Time can not be empty")]
        [Display(Name = "Event End Time")]
        public TimeSpan event_endtime { get; set; }

        [Required(ErrorMessage = "Event Detail can not be empty")]
        [Display(Name = "Event Detail")]
        public string event_detail { get; set; }

        [Required(ErrorMessage = "Event Venue can not be empty")]
        [Display(Name = "Event Venue")]
        public string event_venue{ get; set; }
    }
}
