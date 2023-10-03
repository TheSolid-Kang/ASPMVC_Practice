using ASPMVC_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Engine._01.DBMgr;
using ASPMVC_Practice.Migration;
using Engine._08.CFileMgr;
using System.Text;

namespace ASPMVC_Practice.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger) : base(logger) { }

        public IActionResult Index()
        {
            /*
            using(var db = new TestDbContext())
            {
                var BibleList = db._TFBible.ToList();
                foreach(var Bible in BibleList)
                {
                    Console.WriteLine(Bible.Testament);
                }
            }
            */
            
            /*
            using (var dbMgr = new MSSQL_Mgr())
            {
                StringBuilder strBuil = new StringBuilder();
                strBuil.AppendLine("SELECT * FROM _TFBible" 
                    + " WHERE Testament = N'잠' AND Chapter >= 30");
                var list = dbMgr.SelectList<BibleModel>(MSSQL_Mgr.DB_CONNECTION.TWO_MITES, strBuil.ToString());
                list.ForEach(element => {
                    System.Diagnostics.Debug.WriteLine($"{element.Testament} {element.Chapter.ToString()} : {element.Verse.ToString()}  {element.Descript}");
                });

            }
            */



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test1()
        {
            var mgr = new MSSQL_Mgr();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}