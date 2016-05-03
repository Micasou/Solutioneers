using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class VoteModels
    {
        public class VoteSolution
        {
            [Key]
            public int UID { get; set; } //User ID is attached to this, can only contain one.
            public int SID { get; set; }
            public Boolean upVote { get; set; } //If true user voted up, if not, user voted down
            public SolutionModel Solution { get; set; }
        }
        public class VoteProblem
        {
            [Key]
            public int UID { get; set; }
            public int PID { get; set; }
            public Boolean upVote { get; set; }
            public virtual ProblemModel Problem { get; set; }
        }
    }
}