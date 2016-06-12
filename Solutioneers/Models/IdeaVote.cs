using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class IdeaVote : VoteInterface
    {
        [Key]
        public int VoteID { get; set; }
        public string UserID { get; set; }
        public bool upVote { get; set; } //If true user voted up, if not, user voted down

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created

        [ForeignKey("Idea")]//foriegn key must be same name as the virtual type
        public int SolutionID { get; set; }
        public virtual Idea Idea { get; set; }
    }
}