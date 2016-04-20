using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class VoteModels
    {
        public class ProblemVoteModel
        {
            [Key]
            public virtual int PID { get; set; }
            [Key]
            public virtual int UID { get; set; }
        }
        public class SolutionVoteModel
        {
            [Key]
            public virtual int SID { get; set; }
            [Key]
            public virtual int UID { get; set; }
        }
    }
}