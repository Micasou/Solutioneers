using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int UserID { get; set; } //User ID 

        public int? ProblemID { get; set; } //Problem ID ### the ? indicates this foriegn ID is nullable
        public virtual Problem Problem { get; set; } //problem this solutioner is attached to
        public virtual Channel Channel { get; set; } //channel that this problem is attached to  


        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        public virtual ICollection<SolutionVote> Votes { get; set; }
    }
}