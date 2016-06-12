using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutioneers.Models
{
    interface CategoryInterface
    {
        [Key]
         int CategoryID { get; set; } //Group ID
        [Required]
        [MaxLength(30)]
        string Title { get; set; }
    }
}
