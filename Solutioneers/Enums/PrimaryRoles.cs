using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Solutioneers.Enums
{
    public enum PrimaryRoles
    {
        [Description("Everyone one is enheritly an Entrepreneur. These are the people that get things done, they are eager to do whatever it takes to make it work.")]
        Entrepreneur,
        [Description("A developer is someone who specalizes in software development, ranging from websites, to apps, to desktop applications.")]
        Developer,
        [Description("Designers develop the flow of the service, software, hardware, etc.")]
        Designer,
        [Description("Marketers know what ")]
        Marketer,
        [Description("Everyone one is enheritly an Entrepreneur. These are the people that get things done, they are eager to do whatever it takes to make it work.")]
        Engineer
    }
    
}