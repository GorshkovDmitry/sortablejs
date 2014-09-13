using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForDNS.Models
{
    public class PathFile
    {
        public int Id { get; set; }
        public int PathID { get; set; }
        public int FileID { get; set; }
        public int Position { get; set; }

        public virtual Path Path { get; set; }    
        public virtual File File { get; set; }

    }

}