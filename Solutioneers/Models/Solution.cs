using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Solution
    {
        /// <summary>
        /// Two keys indicates composite key.
        /// The below things in brackets "[]" are Data annotations, restricts/limits what variable can do.
        /// Please see here for additional info: "https://msdn.microsoft.com/en-us/data/jj591583.aspx".
        /// </summary>
        [Key]
        public int SolutionID { get; set; }

        public string UserID { get; set; } //User ID

        [ForeignKey("Problem")]//foriegn key must be same name as the virtual type
        public int? ProblemID { get; set; } //Problem ID ### the ? indicates this foriegn ID is nullable
        public virtual Problem Problem { get; set; } //problem this solutioner is attached to

        [ForeignKey("Channel")]//foriegn key must be same name as the virtual type
        public int ChannelID { get; set; } //we have the ChannelID set here because a solution cannot exist w/o a channel
        public virtual Channel Channel { get; set; } //channel that this problem is attached to  

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }


        public virtual ICollection<SolutionVote> Votes { get; set; }
    }
}