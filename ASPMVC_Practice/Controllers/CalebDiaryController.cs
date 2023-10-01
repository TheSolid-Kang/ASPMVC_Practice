using ASPMVC_Practice.Models;
using Engine._01.DBMgr;
using Engine._02.KMP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
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
            return View();
        }
        public IActionResult SearchKeyword(string _searchKeyword)
        {
            if(string.IsNullOrEmpty(_searchKeyword))
                return RedirectToAction(nameof(Index));//검색어 없이 검색한 경우

            List<_TCDiary> _TCDiaries = GetSearchedTCDiary(_searchKeyword);
            ViewData["_TCDiarys"] = _TCDiaries;
            //TempData["DataSet1"] = "111, 65, 90, 120, 80, 95,111, 65, 90, 120, 80, 95";
            if(_TCDiaries.Count != 0)
                TempData["DataSet1"] = GetSearchKeywordCount(_TCDiaries, _searchKeyword);
            else
                TempData["DataSet1"] = "";

            TempData["Keyword"] = _searchKeyword;
            TempData["Labels"] = "'2022.10'";

            return RedirectToAction(nameof(Index));
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


        #region 함수 정의
        private List<_TCDiary> GetSearchedTCDiary(string _searchKeyword)
        {
            List<_TCDiary> _TCDiaries = new List<_TCDiary>();
            using (var dbMgr = new MSSQL_Mgr())
            {
                StringBuilder strBuil = new StringBuilder();
                strBuil.Append("SELECT * FROM _TCDiary ");
                strBuil.Append("WHERE 1=1 ");
                strBuil.Append($"AND Record LIKE N'%{_searchKeyword}%' ");
                strBuil.Append($"ORDER BY InDate");
                _TCDiaries = dbMgr.SelectList<_TCDiary>(MSSQL_Mgr.DB_CONNECTION.CALEB, strBuil.ToString());
            }

            return _TCDiaries;
        }

        private string GetSearchKeywordCount(List<_TCDiary> _TCDiaries, string _searchKeyword)
        {
            DateTime lastDateTime = _TCDiaries.Max(e => e.InDate);
            DateTime startDateTime = lastDateTime;
            startDateTime = startDateTime.AddYears(-1);
            startDateTime = startDateTime.AddMonths(1);
            startDateTime = startDateTime.AddDays(1 - lastDateTime.Day);
            _KMP kmp =  new _KMP();

            Dictionary<DateTime, List<_TCDiary>> _mapTCDiaries = new();
            _TCDiaries.ForEach(e => {
                DateTime dateTime = e.InDate;
                dateTime = dateTime.AddMonths(1);
                dateTime = dateTime.AddDays(1 - dateTime.Day);
                //_mapTCDiaries.Add(dateTime, null);
                if (false == _mapTCDiaries.ContainsKey(dateTime))
                {
                    _mapTCDiaries[dateTime] = new List<_TCDiary>();
                }

                _mapTCDiaries[dateTime].Add(e);
            });

            string strKeywordCount = "";
            foreach(var _listTCDiary in _mapTCDiaries)
            {
                var iterable = from element in _listTCDiary.Value select element;
                int monthCnt = 0;
                foreach (var item in iterable)
                {
                    monthCnt += kmp.get_searched_address(item.Record, _searchKeyword).Count;
                }
                strKeywordCount += monthCnt.ToString() + ",";

            }
            strKeywordCount = strKeywordCount.Substring(0, strKeywordCount.Length - 1);

            System.Diagnostics.Debug.WriteLine("  ");
            return strKeywordCount;
        }

        #endregion
    }
}
