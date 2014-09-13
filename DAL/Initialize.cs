using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectForDNS.Models;
using ProjectForDNS.DAL;

namespace ProjectForDNS.DAL
{
    public class Initialize : DropCreateDatabaseIfModelChanges<DBForDNSContext>
    {
        protected override void Seed(DBForDNSContext context)
        {
            var file = new List<File> 
            { 
                new File { Name = "AbstractContainer.js"},
                new File { Name = "ButtonGroup.js"},
                new File { Name = "Container.js"},
                new File { Name = "DockingContainer.js"},
                new File { Name = "Monitor.js"},
                new File { Name = "Viewport.js"}
            };
            file.ForEach(s => context.Files.Add(s));
            context.SaveChanges();

            var path = new List<Path> 
            { 
                new Path { Name = "Ext JS", Position = 1 },
                new Path { Name = "class", Position = 2 },
                new Path { Name = "container", Position = 3 },
                new Path { Name = "chart", Position = 4 },
                new Path { Name = "data", Position = 5 },
                new Path { Name = "dd", Position = 6 },
                new Path { Name = "diag", Position = 7 }
            };
            path.ForEach(s => context.Paths.Add(s));
            context.SaveChanges();

            var path_file = new List<PathFile> 
            { 
                new PathFile { PathID = 3, FileID = 1, Position = 1 },
                new PathFile { PathID = 3, FileID = 2, Position = 2 },
                new PathFile { PathID = 3, FileID = 3, Position = 3 },
                new PathFile { PathID = 3, FileID = 4, Position = 4 },
                new PathFile { PathID = 3, FileID = 5, Position = 5 },
                new PathFile { PathID = 3, FileID = 6, Position = 6 }

            };
            path_file.ForEach(s => context.PathFiles.Add(s));
            context.SaveChanges();


            var path_path = new List<PathPath> 
            { 
                new PathPath { FatherID = 1, SonID = 2, Position = 1 },
                new PathPath { FatherID = 1, SonID = 3, Position = 2 },
                new PathPath { FatherID = 1, SonID = 5, Position = 3 },
                new PathPath { FatherID = 1, SonID = 6, Position = 4 },
                new PathPath { FatherID = 1, SonID = 7, Position = 5 },
                new PathPath { FatherID = 3, SonID = 4, Position = 7 }

            };
            path_path.ForEach(s => context.PathPaths.Add(s));
            context.SaveChanges();
        }
    }
}