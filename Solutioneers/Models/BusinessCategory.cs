using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class BusinessCategory : CategoryInterface
    {
        [Key]
        public int BusinessCategoryID { get; set; } //Group ID

        [Required]
        [MaxLength(50, ErrorMessage = "Max Title Length is 50 characters")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Max Title Length is 500 characters")]
        public string Description { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public IEnumerable<Idea> Ideas { get; set; }
    }
}