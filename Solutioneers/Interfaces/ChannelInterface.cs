using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutioneers.Models
{
    interface ChannelInterface
    {
        string Description { get; set; }
        DateTime CreationDate { get; set; } //when the channel was created
    }
}
