using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Solutioneers.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; } //unique to each pair of people
        public string FromID { get; set; }
        public string ToID { get; set; }

        public string message { get; set; }

        public DateTime TimeMessageSent { get; set; }

    }
}