using Solutioneers.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Idea : IdeaInterface
    {
        [Key]
        public int SolutionID { get; set; }
        public string UserID { get; set; } //User ID

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
        //We must do custom data annotations to limit this number to 3 at any given time

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        [ForeignKey("BusinessChannel")]//foriegn key must be same name as the virtual type
        public int ChannelID { get; set; }
        public virtual BusinessChannel BusinessChannel { get; set; }

        public virtual ICollection<IdeaVote> IdeaVotes { get; set; }
    }
}