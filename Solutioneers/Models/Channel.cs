using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Channel
    {
        [Key]
        public int ChannelID { get; set; } //Channel ID

        [ForeignKey("Category")]//foriegn key must be same name as the virtual type
        public virtual int CategoryID { get; set; }
        public virtual Category Category { get; set; } //Category this channel belongs too,public virtual Category Category { get; set; } //Category this channel belongs too,

        public string UserID { get; set; } //User ID that created the channel

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        

        public virtual ICollection<ChannelVote> Votes { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; } //entity framework manages the foriegn keys for us all solututions in the channel 
        public virtual ICollection<Problem> Problems { get; set; } //all problems in the channel
        
    }
}