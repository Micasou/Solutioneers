using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class HoursOfOperation
    {
        [Key]
        public int HoursOfOperationID { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        [MaxLength(50)]
        public string TimeOpen { get; set; }

        [ForeignKey("Location")]//foriegn key must be same name as the virtual type
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}