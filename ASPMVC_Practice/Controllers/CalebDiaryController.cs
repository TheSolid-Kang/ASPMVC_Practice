using ASPMVC_Practice.Models;
using Engine._01.DBMgr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ASPMVC_Practice.Controllers
{
    public class CalebDiaryController : BaseController<CalebDiaryController>
    {
        public CalebDiaryController(ILogger<CalebDiaryController> logger) : base(logger)
        {
        }

        // GET: CalebDiaryController
        public IActionResult Index()
        {
            using (var dbMgr = new MSSQL_Mgr())
            {
                StringBuilder strBuil = new StringBuilder();
                strBuil.Append("SELECT * FROM _TCDiary ");
                strBuil.Append("WHERE 1=1 ");
                strBuil.Append("AND Record LIKE N'%희원%' ");
                var _TCDiarys = dbMgr.SelectList<_TCDiary>(MSSQL_Mgr.DB_CONNECTION.CALEB, strBuil.ToString());

                //ViewData["DinamicGraph"] = "data: { labels: ['7월', '8월', '9월', '10월', '11월', '12월'], datasets: [{ label: '언급횟수', data: [111, 65, 90, 120, 80, 95], backgroundColor: ['rgba(121, 55, 218, 0.8)'],borderColor: ['rgba(121, 55, 218, 1)'],borderWidth: 1}]";

                ViewData["_TCDiarys"] = _TCDiarys;
                ViewData["TEMPDATA"] = "111, 65, 90, 120, 80, 95,111, 65, 90, 120, 80, 95";
                ViewData["Keyword"] = "Keyword";
            }
            return View();
        }

        // GET: CalebDiaryController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CalebDiaryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalebDiaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalebDiaryController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalebDiaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalebDiaryController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalebDiaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
