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
        private IFilmRepository filmrep = new DbFilmRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllEvents()
        {
            return View();
        }

        //Films
        //Show all films and filters
        public ActionResult ShowFilms()
        {
            IEnumerable<Film> allFilms = filmrep.ShowAllfilms();
            return View(allFilms);
        }

        //Show FilmInformation
        public ActionResult ShowFilmInformation()
        {
            return View();
        }

        //City
        //Show Information about Haarlem
        public ActionResult ShowCity()
        {
            return View();
        }

    }
}
