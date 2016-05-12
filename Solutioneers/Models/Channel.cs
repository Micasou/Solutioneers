using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Channel
    {
        [Key]
        public int ChannelID { get; set; } //Channel ID
        public int UserID { get; set; } //User ID that created the channel
        public string Title { get; set; } // Title of the channel
        public string Description { get; set; } //Description of types of problems + solutions that will be found here.

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        public virtual ICollection<Category> Categories { get; set; } //Category this channel belongs too,

        public virtual ICollection<ChannelVote> Votes { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; } //entity framework manages the foriegn keys for us all solututions in the channel 
        public virtual ICollection<Problem> Problems { get; set; } //all problems in the channel
    }
}