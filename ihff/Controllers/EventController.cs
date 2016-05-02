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
            IEnumerable<Film> allFilms = filmrep.GetAllfilms();
            return View(allFilms);
        }

        //Show FilmInformation
        public ActionResult ShowFilmInformation()
        {
            return View();
        }

        //Restaurants
        //Show all restaurants
        public ActionResult ShowRestaurants()
        {
            return View();
        }

        public ActionResult ShowRestaurantInformation()
        {
            return View();
        }


        //Specials
        //Show all specials and filters
        public ActionResult showSpecials()
        {
            return View();
        }

        //Show special information
        public ActionResult ShowSpecialInformation()
        {
            return View();
        }

        //City
        //Show Information about Haarlem
        public ActionResult ShowCity()
        {
            return View();
        }

        // show well known sights
        public ActionResult ShowSights()
        {
            return View();
        }

    }
}
