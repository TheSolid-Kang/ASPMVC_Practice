using ASPMVC_Practice.Models;
using Engine._01.DBMgr;
using Engine._02.KMP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ASPMVC_Practice.Controllers
{
    public class CalebDiaryController : BaseController<CalebDiaryController>
    {
        readonly private int PrintTxtSize = 40;

        public CalebDiaryController(ILogger<CalebDiaryController> logger) : base(logger)
        {
        }

        // GET: CalebDiaryController
        public IActionResult Index()
        {
            TempData["_TCDiaries"] = null;
            TempData["SearchKeyword"] = "";
            return View();
        }
        public IActionResult SearchKeyword(string _searchKeyword)
        {
            if (string.IsNullOrEmpty(_searchKeyword))
                return RedirectToAction(nameof(Index));//검색어 없이 검색한 경우

            TempData["ChartDatas"] = "";
            TempData["_TCDiaries"] = "";
            TempData["SearchKeyword"] = _searchKeyword;

            InsertSearchRecord(_searchKeyword);

            List<_TCDiary> _TCDiarySummaries = new();
            string[] arrColors = { "#ff0000", "#ff8c00", "#ffff00", "#008000", "#0000ff", "#4b0082", "#800080" };
            var iter = arrColors.GetEnumerator();

            Dictionary<string, List<_TCDiary>> mapTCDiaries = new();
            if (_searchKeyword.Contains(","))
            {
                foreach (var _keyword in _searchKeyword.Split(","))
                {
                    if (_keyword.Equals(""))
                        continue;
                    var keyword = _keyword.Trim();
                    List<_TCDiary> _TCDiaries = GetSearchedTCDiary(keyword);
                    mapTCDiaries.Add(keyword, _TCDiaries);
                }
            }
            else
            {
                var keyword = _searchKeyword.Trim();
                mapTCDiaries.Add(keyword, GetSearchedTCDiary(keyword));
            }
            if (mapTCDiaries.Count() < 0)
                return View(nameof(Index));

            SortedSet<string> setChartX = new SortedSet<string>();
            foreach (var _diaries in mapTCDiaries)
            {
                _diaries.Value.ForEach(e =>
                {
                    string year = e.InDate.Year.ToString();
                    string month = e.InDate.Month.ToString();
                    if (month.Length < 2) { month = "0" + month; }
                    string dateYearMonth = $"{year}.{month}";
                    setChartX.Add(dateYearMonth);
                });
            }

            string labels = "";
            foreach (var charX in setChartX)
            {
                labels += $"'{charX}', ";
            }

            if(labels == "")
                return View(nameof(Index));

            labels = labels.Substring(0, labels.Length - 1);

            // The data for our dataset
            StringBuilder strBuil = new StringBuilder(2048);
            strBuil.AppendLine($"data: {{");
            strBuil.AppendLine($"   labels: [{labels}],");
            strBuil.AppendLine($"   datasets:");
            strBuil.Append($"   [");
            _KMP kmp = new _KMP();

            int colorIdx = 0;
            foreach (var _tcdiaries in mapTCDiaries)
            {
                if (false == iter.MoveNext())
                    break;

                var keyword = _tcdiaries.Key;
                var convertedKeyword = ConvertTextColor(keyword, arrColors[colorIdx]); //색상 바꾸기
                var listDiaries = new List<_TCDiary>();
                //1. 다이어리 요약본 작성
                _tcdiaries.Value.ForEach(e => {
                    StringBuilder strBuil = new StringBuilder(4096);
                    var listIdx = kmp.get_searched_address(e.Record, keyword);
                    listIdx.ForEach(_idx => {
                        _TCDiary tCDiary = new _TCDiary(e);
                        listDiaries.Add(tCDiary);
                        string record = tCDiary.Record;
                        int startIdx = record.LastIndexOf("\n", _idx);
                        int lastIdx = record.IndexOf("\n", _idx);
                        startIdx = (startIdx < PrintTxtSize) ? 0 : startIdx - PrintTxtSize;
                        lastIdx = ((record.Length - lastIdx) < PrintTxtSize) ? record.Length - 1 : (PrintTxtSize + lastIdx - 1);
                        tCDiary.Record = record.Substring(startIdx + 1, lastIdx - startIdx);

                        tCDiary.Record = tCDiary.Record.TrimStart('\r', '\n');
                        tCDiary.Record = tCDiary.Record.TrimEnd('\r', '\n');

                        tCDiary.Record = tCDiary.Record.Replace(keyword, convertedKeyword);
                        tCDiary.Record = $"...{tCDiary.Record}...";
                    });
                });
                colorIdx++;

                _TCDiarySummaries = _TCDiarySummaries.Concat(listDiaries).ToList();
                string data = GetSearchKeywordCount(_tcdiaries.Value, setChartX, keyword);
                strBuil.AppendLine($"{{");

                strBuil.AppendLine($"   label: '{keyword}',");
                strBuil.AppendLine($"   data: [{data}],");
                strBuil.AppendLine($"   type: 'bar', // 'bar' type, 전체 타입과 같다면 생략가능    ");
                strBuil.AppendLine($"   backgroundColor: ['{iter.Current.ToString()}'],");
                strBuil.AppendLine($"   borderColor: ['{iter.Current.ToString()}']");
                strBuil.Append($"}},");
            }
            string chartDatas = strBuil.ToString();
            chartDatas = chartDatas.Substring(0, chartDatas.LastIndexOf(","));
            chartDatas += "]}";
            TempData["ChartDatas"] = chartDatas;

            _TCDiarySummaries = _TCDiarySummaries.OrderBy(e => e.InDate).ToList();
            TempData["_TCDiaries"] = _TCDiarySummaries;
            return View(nameof(Index));

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
        private void InsertSearchRecord(string _searchKeyword)
        {
            using(var  dbMgr = new MSSQL_Mgr())
            {
                string query = $"INSERT INTO _TCSearchRecord(ChurchSeq, SearchKeyword, LastUserSeq, LastDateTime ) VALUES(1,'{_searchKeyword}', 2, GETDATE());";
                dbMgr.GetDataSet(MSSQL_Mgr.DB_CONNECTION.CALEB, query);
            }

        }

        private string GetSearchKeywordCount(List<_TCDiary> _TCDiaries, SortedSet<string> _setChartX, string _searchKeyword)
        {
            _KMP kmp = new _KMP();
            Dictionary<string, List<_TCDiary>> _mapTCDiaries = new();
            foreach (var _chartX in _setChartX)
            {
                _mapTCDiaries.Add(_chartX, new List<_TCDiary>());
            }

            _TCDiaries.ForEach(e =>
            {
                string year = e.InDate.Year.ToString();
                string month = e.InDate.Month.ToString();
                if (month.Length < 2) { month = "0" + month; }
                string dateYearMonth = $"{year}.{month}";
                _mapTCDiaries[dateYearMonth].Add(e);
            });

            string strKeywordCount = "";
            foreach (var _listTCDiary in _mapTCDiaries)
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
        private string ConvertTextColor(string _text , string _color)
        {
            StringBuilder strBuil = new StringBuilder();
            strBuil.Append($"<span style=\"color:{_color}; font-weight:ariel; font-size : large;\">");
            strBuil.Append(_text);
            strBuil.Append("</span>");
            return strBuil.ToString();
        }


        #endregion
    }
}
