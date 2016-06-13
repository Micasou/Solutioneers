using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; } //Group ID

        public string UserID { get; set; }
        [Required]
        [DisplayName("Company Name")]
        [MaxLength(50, ErrorMessage = "Max Title Length is 50 characters")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Max Title Length is 500 characters")]
        public string Description { get; set; }

        public IEnumerable<Location> Locations { get; set; }
        public virtual ICollection<BusinessCategory> BusinessCategories { get; set; } //entity framework manages the foriegn keys for us
    }

   

}