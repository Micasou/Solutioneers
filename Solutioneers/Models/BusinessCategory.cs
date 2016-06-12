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
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }

        public IEnumerable<BusinessChannel> BusinessChannels { get; set; }
    }
}