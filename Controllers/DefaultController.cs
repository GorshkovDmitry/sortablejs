using ProjectForDNS.DAL;
using ProjectForDNS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForDNS.Controllers
{
    public class DefaultController : Controller
    {
        private DBForDNSContext db = new DBForDNSContext();

        // GET: Default
        public ActionResult Index() 
        {
            var pathfiles = db.PathFiles.Include("File").Include("Path").OrderBy(f => f.Position).ToList();
            var pathpaths = db.PathPaths.Include("Father").Include("Son").OrderBy(i => i.Position).ToList();
            var paths = db.Paths.OrderBy(f => f.Position).ToList();
            
            return View(Tuple.Create(pathfiles, pathpaths, paths));
        }

        public ActionResult UpdatePositionFile(string[] positionsfile)
        {
            var modifiedOrder = new List<int>(GetModifiedArrayIndexes(positionsfile));
            var files = db.PathFiles.ToList();
            var sortedPositions = db.PathFiles.OrderBy(f => f.Position).Select(f => f.Position).ToList();

            FeatureService.SortFiles(files, modifiedOrder, sortedPositions);

            db.SaveChanges();

            return new EmptyResult();
        }

        public ActionResult UpdatePositionPath(string[] positionspath)
        {
             var modifiedOrder = new List<int>(GetModifiedArrayIndexes(positionspath));
             var paths = db.Paths.ToList();
             var sortedPositions = db.Paths.OrderBy(f => f.Position).Select(f => f.Position).ToList();

             FeatureService.SortPaths(paths, modifiedOrder, sortedPositions);


            db.SaveChanges();

            return new EmptyResult();
        }

        private IEnumerable<int> GetModifiedArrayIndexes(IEnumerable<string> positions)
        {
            foreach (var position in positions)
                yield return Convert.ToInt32(position.Substring(position.IndexOf('_') + 1));
        }

        public static class FeatureService
        {
            public static void SortFiles(ICollection<PathFile> files, IList<int> modifiedOrder, IList<int> originalPositions)
            {
                for (var i = 0; i < files.Count; i++)
                {
                    var file = files.FirstOrDefault(h => h.FileID == modifiedOrder[i]);
                        file.Position = originalPositions[i];
                    
                }
            }

            public static void SortPaths(ICollection<Path> paths, IList<int> modifiedOrder, IList<int> originalPositions)
            {
                for (var i = 0; i < paths.Count; i++)
                {
                    var path = paths.FirstOrDefault(h => h.PathID == modifiedOrder[i]);
                    
                    //Проверка - когда в папку заносим другую папку, то ничего не делать
                    if (path != null)
                    {
                        path.Position = originalPositions[i];
                    }
                }
            }
        }
    }
}