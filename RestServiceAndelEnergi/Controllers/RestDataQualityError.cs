using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceAndelEnergi.Controllers
{
    public class RestDataQualityError : Controller
    {
        // GET: RestDataQualityError
        public ActionResult Index()
        {
            return View();
        }

        // GET: RestDataQualityError/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RestDataQualityError/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestDataQualityError/Create
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

        // GET: RestDataQualityError/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestDataQualityError/Edit/5
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

        // GET: RestDataQualityError/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RestDataQualityError/Delete/5
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
