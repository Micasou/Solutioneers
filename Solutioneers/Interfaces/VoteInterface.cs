using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutioneers.Models
{
    interface VoteInterface
    {
        string UserID { get; set; }
        bool upVote { get; set; } //If true user voted up, if not, user voted down
        DateTime CreationDate { get; set; } //when the channel was created
    }
}
