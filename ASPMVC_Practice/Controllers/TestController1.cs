using Engine._01.DBMgr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;

namespace ASPMVC_Practice.Controllers
{
    public class TestController1 : BaseController<TestController1>
    {
        public TestController1(ILogger<TestController1> logger) : base(logger) { }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test1()
        {
            var mgr = new MSSQL_Mgr();
            var ds = mgr.GetDataSet(MSSQL_Mgr.DB_CONNECTION.MATERIAL, "SELECT * FROM _TMMMaster");

            Console.WriteLine("");

            return View();
        }
    }
}
