using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDNS.Models
{
    public class PathPath
    {
        public int Id { get; set; }
        public int FatherID { get; set; }
        public int SonID { get; set; }
        public int Position { get; set; }

        public virtual Path Father { get; set; }
        public virtual Path Son { get; set; }
    }
}