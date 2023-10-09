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
            //1. 데이터 INSERT 방법
            using(var db = new TestDbContext())
            {
                //var _TFUsers = db._TFUser.ToList();
                db._TFUser.Add(new _TFUser() { ChurchSeq = 1, ResidID= "david", UserName="나종한" ,Empid="0691", IsAdministrator="1", IsSaved="0" , LastUserSeq= 0, LastDateTime=DateTime.Now }); 

                db.SaveChanges();

                Console.Write("확인");                
            }
            */
            //2. 데이터 UPDATE 방법
            using(var db = new TestDbContext())
            {
                //1번 방법: 행 하나만 업데이트
                //  Find()로 찾는다.
                var _tFUser = db._TFUser.Find(2); 
                //key가 4개인 경우 4개를 다 넣어야 오류가 안 난다. 
                //find는 하나만 가져오기 때문임.
                _tFUser.Empid = "0691";
                db.SaveChanges();

                //2번 방법: 여러행 업데이트
                //  Where()로 찾는다.

                //db.SaveChanges();
            }
            string str = "안녕하세요.";
            ViewBag.str = str;


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