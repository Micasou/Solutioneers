using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class SolutionVote
    {
           
            [Key]
            public int VoteID { get; set; }
            public int UserID { get; set; } //User ID is attached to this, can only contain one
        
            public bool upVote { get; set; } //If true user voted up, if not, user voted down

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime CreationDate { get; set; } //when the channel was created
                                                       //We must do custom data annotations to limit this number to 3 at any given time

            [ForeignKey("Solution")]//foriegn key must be same name as the virtual type
            public int SolutionID { get; set; }
            public Solution Solution { get; set; }  
    }
}