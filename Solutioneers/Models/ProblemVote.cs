using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class ProblemVote
    {
      
        [Key]
        public int VoteID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("Problem")]//foriegn key must be same name as the virtual type
        public virtual int ProblemID { get; set; }
        public virtual Problem Problem { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        public bool upVote { get; set; } //true if voted up
     
    }
}