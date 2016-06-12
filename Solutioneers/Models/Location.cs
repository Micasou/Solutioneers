using Solutioneers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Location
    {
        [Required]
        [MaxLength(100)]
        public string StreetAddress { get; set; }
        [Required]
        public short ZipCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        public State State { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}