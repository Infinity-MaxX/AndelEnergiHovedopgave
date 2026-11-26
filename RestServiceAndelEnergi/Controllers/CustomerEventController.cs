using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceAndelEnergi.Controllers
{
    public class CustomerEventController : Controller
    {
        #region Database instance
        private ICustomerEventService _db;
        #endregion

        #region Dependency injection
        public CustomerEventController(ICustomerEventService db)
        {
            _db = db;
        }
        #endregion

        #region Helper methods
        private bool IsValid(CustomerEvent customerEvent)
        {
            if (customerEvent.DateOfEvent != DateTime.Today) return false;
            if (customerEvent.CustomerTypeId == 0) return false;
            if (customerEvent.ProductAreaId == 0) return false;
            if (customerEvent.SalesChannelId == 0) return false;

            return true;
        }
        #endregion

        #region CRUD methods
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CustomerEvent>> GetAll()
        {
            var content = _db.GetAll();
            if (content.Count == 0) return NoContent();
            else return Ok(content);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerEvent> Get(int id)
        {
            var content = _db.GetById(id);
            if (content == null) return NotFound();
            else return Ok(content);
        }

        // A generic to filter by different parametres
        //public ActionResult<IEnumerable<CustomerEvent>> GetBy<T>(ref T filter)
        //{
        //    var content = _db.
        //}

        //[HttpGet("{customerType}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<CustomerEvent>> GetByCustomerType(string customerType)
        //{
        //    var content = _db.GetByCustomerType(customerType);
        //    if (content.Count == 0) return NoContent();
        //    if (content == null) return NotFound();
        //    else return Ok(content);
        //}

        //[HttpGet("{eventType}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<CustomerEvent>> GetByEventType(string eventType)
        //{
        //    var content = _db.GetByEventType(eventType);
        //    if (content.Count == 0) return NoContent();
        //    if (content == null) return NotFound();
        //    else return Ok(content);
        //}

        //[HttpGet("{month}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<CustomerEvent>> GetByMonth(DateTime month)
        //{
        //    var content = _db.GetByDate(month);
        //    if (content.Count == 0) return NoContent();
        //    if (content == null) return NotFound();
        //    else return Ok(content);
        //}

        //[HttpGet("{reason}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<CustomerEvent>> GetByReason(string reason)
        //{
        //    var content = _db.GetByReason(reason);
        //    if (content.Count == 0) return NoContent();
        //    if (content == null) return NotFound();
        //    else return Ok(content);
        //}

        //[HttpGet("{salesChannel}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<IEnumerable<CustomerEvent>> GetByChannel(string salesChannel)
        //{
        //    var content = _db.GetBySalesChannel(salesChannel);
        //    if (content.Count == 0) return NoContent();
        //    if (content == null) return NotFound();
        //    else return Ok(content);
        //}

        // GET: CustomerEventController/Create
        // Create is changed to ViewPost
        // opens the Create page and returns the view of posted content
        // if validation fails, it returns the view with the submitted
        // model so the user can correct the errors
        public ActionResult Create()
        {
            return View();
        }

        // needs to notify if the specified parameters are violated when inserting
        // needs to notify if the object was accepted
        //public ActionResult<CustomerEvent> Create(CustomerEvent customerEvent)
        //{
        //    // custom validation check
        //    if (!IsValid(customerEvent)) return BadRequest();

        //    var insertedObject = _db.Insert(customerEvent);
        //    string uri = Url.RouteUrl(RouteData.Values) + "/" + insertedObject;
        //    return Created(uri, insertedObject);
        //}

        // POST: CustomerEventController/Create
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

        // GET: CustomerEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerEventController/Edit/5
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

        // GET: CustomerEventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerEventController/Delete/5
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

        // GET: RestCustomerEvents
        // GetAll()
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: RestCustomerEvents/Details/5
        // GetByID, GetByType, etc. requests
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}
        #endregion
    }
}
