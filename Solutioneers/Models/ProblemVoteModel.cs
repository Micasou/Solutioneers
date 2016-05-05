using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class ProblemVoteModel
    {
        [Key]
        public int UID { get; set; }
        public int PID { get; set; }
        public Boolean upVote { get; set; }
        public virtual ProblemModel Problem { get; set; }
    }
}