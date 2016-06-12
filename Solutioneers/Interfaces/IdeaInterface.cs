using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solutioneers.Interfaces
{
    public interface IdeaInterface
    {
        int SolutionID { get; set; }
        string UserID { get; set; } //User IDo
        DateTime CreationDate { get; set; } //when the channel was created
        string Title { get; set; }
        string Description { get; set; }
    }
}