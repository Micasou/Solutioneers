using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; } //Group ID

        [Required]
        [MaxLength(30)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(256)]    // sets max length to 255
        public string Description { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public virtual ICollection<BusinessCategory> BusinessCategories { get; set; } //entity framework manages the foriegn keys for us
    }

   

}