using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDNS.Models
{
    public class Path
    {
        public int PathID { get; set; }
        public string Name { get; set; }
        public string Dir { get; set; }
        public int Position { get; set; }
    }

}