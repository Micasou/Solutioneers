using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class VoteModels
    {
            [Key]
            public virtual int UID { get; set; } //User ID is attached to this, can only contain one.
            public virtual Boolean upVote { get; set; } //If true user voted up, if not, user voted down
    }
}