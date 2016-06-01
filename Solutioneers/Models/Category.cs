using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    /*
     * Only admins will have access to this model, so we will not create resitrctions on it for now.
     */
    public class Category
    {
        [Key]
        public int CategoryID { get; set; } //Group ID

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        public virtual ICollection<Channel> Channels { get; set; } //entity framework manages the foriegn keys for us
    }
}