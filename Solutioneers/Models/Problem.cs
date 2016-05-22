using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Problem
    {
        /// <summary>
        /// Two keys indicates composite key.
        /// The below things in brackets "[]" are Data annotations, restricts/limits what variable can do.
        /// Please see here for additional info: "https://msdn.microsoft.com/en-us/data/jj591583.aspx".
        /// </summary>
        [Key]
        public virtual int ProblemID { get; set; } //Problem ID

        public int UserID { get; set; } //User ID, the one who posted it.
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Channel")]//foriegn key must be same name as the virtual type
        public int ChannelID { get; set; }
        public virtual Channel Channel { get; set; } //channel that this problem is attached to  

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        public virtual ICollection<Solution> Solutions { get; set; } //entity framework manages the foriegn keys for us
        public virtual ICollection<ProblemVote> Votes { get; set; } //entity framework manages the foriegn keys for us

    }
}