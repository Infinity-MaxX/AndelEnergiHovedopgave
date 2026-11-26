using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceAndelEnergi.Controllers
{
    public class DataQualityErrorController : Controller
    {
        // GET: DataQualityErrorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DataQualityErrorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataQualityErrorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataQualityErrorController/Create
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

        // GET: DataQualityErrorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataQualityErrorController/Edit/5
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

        // GET: DataQualityErrorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataQualityErrorController/Delete/5
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
