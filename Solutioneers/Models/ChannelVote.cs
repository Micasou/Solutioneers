using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class ChannelVote
    {
            [Key]
            [ForeignKey("Solution")]
            public int UserID { get; set; } //User ID is attached to this, can only contain one
            public bool upVote { get; set; } //If true user voted up, if not, user voted down
            public Channel Channel { get; set; }  
    }
}