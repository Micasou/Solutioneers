﻿using Solutioneers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [Required]
        [MaxLength(75, ErrorMessageResourceName ="The max length of a street is 75 characters")]
        public string StreetAddress1 { get; set; }
        
        [MaxLength(75, ErrorMessageResourceName = "The max length of a street is 75 characters")]
        public string StreetAddress2 { get; set; }

        [Required]
        [RegularExpression(@"(^(?!0{5})(\d{5})(?!-?0{4})(-?\d{4})?$)", ErrorMessage = "Improperly formatted zip code.  It must be entered as nnnnn or nnnnn-nnnnn.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50, ErrorMessageResourceName = "The max length of a city name is 50 characters")]
        public string City { get; set; }

        [Required]
        public State State { get; set; }

        [Required(ErrorMessage = "Mobile no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }


        public string website { get; set; }

        public IEnumerable<HoursOfOperation> HoursOfOperation { get; set; }

        /**********************************************GET IMAGES IN ASAP*************************************************/

        [ForeignKey("Company")]//foriegn key must be same name as the virtual type
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}