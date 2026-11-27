using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestServiceAndelEnergi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        /// <summary>
        /// Checks query results and returns the corresponding HTTP action result.
        /// </summary>
        /// <param name="query">The function that retrieves the customer events.</param>
        /// <returns>A not-found result for null results, a no-content result for empty results,
        /// or an OK result containing the customer events.</returns>
        // I call on Func because I want to pass a function that returns IEnumerable<CustomerEvent>
        // as a parameter, rather than the result of the function itself.
        private ActionResult<IEnumerable<CustomerEvent>> CheckContent(Func<IEnumerable<CustomerEvent>> query)
        {
            var content = query();
            if (content is null) return NotFound();
            if (content.Count() == 0) return NoContent();
            else return Ok(content);
        }

        private bool IsValid(CustomerEvent customerEvent)
        {
            // always have date be at the start of the month. this is a business rule.
            if (customerEvent.DateOfEvent.Day != 1) return false;
            if (customerEvent.CustomerTypeId == 0) return false;
            if (customerEvent.ProductAreaId == 0) return false;
            if (customerEvent.SalesChannelId == 0) return false;

            return true;
        }
        #endregion

        #region CRUD methods
        // No Put or Delete functionality needed for REST services. CustomerEvent is a
        // statistical thing. this is a business rule.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<CustomerEvent>> GetAllCustomerEvents()
        {
            var content = _db.GetAll();
            if (content.Count == 0) return NoContent();
            else return Ok(content);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerEvent> Get(int id)
        {
            var content = _db.GetById(id);
            if (content == null) return NotFound();
            else return Ok(content);
        }

        [HttpGet("customertype/{customerType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerEvent>> GetByCustomerType(string customerType)
        {
            return CheckContent(() => _db.GetByCustomerType(customerType));
        }

        [HttpGet("eventtype/{eventType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerEvent>> GetByEventType(string eventType)
        {
            return CheckContent(() => _db.GetByEventType(eventType));
        }

        [HttpGet("month/{month}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerEvent>> GetByMonth(DateTime month)
        {
            return CheckContent(() => _db.GetByDate(month));
        }

        [HttpGet("reason/{reason}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerEvent>> GetByReason(string reason)
        {
            return CheckContent(() => _db.GetByReason(reason));
        }

        [HttpGet("saleschannel/{salesChannel}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CustomerEvent>> GetByChannel(string salesChannel)
        {
            return CheckContent(() => _db.GetBySalesChannel(salesChannel));
        }

        // needs to notify if the specified parameters are violated when inserting
        // needs to notify if the object was accepted
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerEvent> Create([FromBody] CustomerEvent customerEvent)
        {
            // custom validation check
            if (!IsValid(customerEvent)) return BadRequest();

            var insertedObject = _db.Insert(customerEvent);
            string uri = Url.RouteUrl(RouteData.Values) + "/" + insertedObject;
            return Created(uri, insertedObject);
        }

        // GET: CustomerEventController/Create
        // Create is changed to ViewPost
        // opens the Create page and returns the view of posted content
        // if validation fails, it returns the view with the submitted
        // model so the user can correct the errors
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: CustomerEventController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
