using System;
using System.Collections.Generic;
using Solutioneers.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class BusinessChannel : ChannelInterface
    {
        [Key]
        public int ChannelID { get; set; } //Channel ID

        [ForeignKey("Category")]//foriegn key must be same name as the virtual type
        public virtual int CategoryID { get; set; }
        public virtual Category Category { get; set; } //Category this channel belongs too,public virtual Category Category { get; set; } //Category this channel belongs too,

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]    // sets max length to 255
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; } //when the channel was created
    }
}