using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoShare.Models
{
    public class Parent
    {
        public Photo photomodel { get; set; }
        public Comment commentmodel { get; set; }
    }
}