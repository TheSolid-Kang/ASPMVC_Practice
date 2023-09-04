using Engine._01.DBMgr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace ASPMVC_Practice.Controllers
{
    //[Area("Test1")]
    public class TestController1 : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public TestController1(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
