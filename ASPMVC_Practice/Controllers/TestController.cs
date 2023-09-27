using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Components;
using Type = System.Type;
using Image = System.Drawing.Image;
using System.IO;

namespace ASPMVC_Practice.Controllers
{
    public class TestController : BaseController<TestController>
    {
        public TestController(ILogger<TestController> logger) : base(logger) { }
 
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Test()
        {
            Image ab = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, "1234");
         
            Bitmap bitmap = new Bitmap(ab);
            byte[] result = null;

            using(MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                result = stream.ToArray();
                ViewData["img"] = Convert.ToBase64String(result);
            }

            return View();
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
