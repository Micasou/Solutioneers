using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutioneers.Models
{
    interface ChannelInterface
    {
        int ChannelID { get; set; } //Channel ID
        string Description { get; set; }
        DateTime CreationDate { get; set; } //when the channel was created
    }
}
