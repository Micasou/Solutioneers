﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    /*
     * Only admins will have access to this model, so we will not create resitrctions on it for now.
     */
    public class GroupModel
    {
        [Key]
        public virtual int GID { get; set; } //Group ID
        public virtual string Title { get; set; } // Title of the group
        public virtual string Description { get; set; } //Description of types of problems + solutions that will be found here.
    }
}