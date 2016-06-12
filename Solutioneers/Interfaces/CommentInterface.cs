using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solutioneers.Interfaces
{
    public interface CommentInterface
    {
        int CommentID { get; set; }
        string UserID { get; set; }
        string UserComment { get; set; }
        DateTime CreationDate { get; set; } //when the channel was created
        //once image data structure is ready, store that one here
    }
}