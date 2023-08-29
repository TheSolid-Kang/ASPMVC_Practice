using Engine._01.DBMgr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace ASPMVC_Practice.Controllers
{
    //[Area("Test1")]
    public class TestController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test1()
        {
            var mgr = new MSSQL_Mgr();
            return View();
        }
    }
}
