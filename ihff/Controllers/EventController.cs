using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;
using ihff.Controllers;

namespace ihff.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        //All actions are done via eventrepository
        private IEventRepository eventrep = new DbEventRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllEvents()
        {
            IEnumerable<Event> allEvents = eventrep.GetAllEvents();
            return View(allEvents);
        }

    }
}
