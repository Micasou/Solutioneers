using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class ProblemVote
    {
        [Key]
        public int VoteID { get; set; }
        public int UserID { get; set; }
        
        public bool upVote { get; set; }
        public virtual Problem Problem { get; set; }
    }
}