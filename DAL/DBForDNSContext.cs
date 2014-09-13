using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 
using ProjectForDNS.Models;

namespace ProjectForDNS.DAL
{
    public class DBForDNSContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<PathFile> PathFiles { get; set; }
        public DbSet<PathPath> PathPaths { get; set; }
    }
}