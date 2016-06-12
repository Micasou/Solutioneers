using Solutioneers.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class IdeaComment : CommentInterface
    {
        [Key]
        public int CommentID { get; set; }
        //Controller must handle this
        public string UserID { get; set; }

        [Required]
        [MaxLength(500)]
        public string UserComment { get; set; }
        //set time in the controller method to post to the DB
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created

        [ForeignKey("BusinessChannel")]//foriegn key must be same name as the virtual type
        public int BusinessChannelID { get; set; }
        public virtual BusinessChannel BusinessChannel { get; set; }
    }
}