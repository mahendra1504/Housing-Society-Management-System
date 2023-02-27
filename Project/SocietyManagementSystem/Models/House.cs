using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocietyManagementSystem.Models
{
    [Table("Houses")]
    public class House
    {
        [Key]
        public int house_no { get; set; }
        public string house_type { get; set; }
        public string block { get; set; }
        public int allocatioin_status { get; set; }
    }
}
