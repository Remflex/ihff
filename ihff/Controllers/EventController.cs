
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

        //All actions are done via eventrepository
        private IEventRepository eventrep = new DbEventRepository();
        private IFilmRepository filmrep = new DbFilmRepository();
        private IRestaurantRepository resrep = new DbRestaurantRepository();
        private ISpecialRepository specrep = new DbSpecialRepository();
        private ISightRepository sightrep = new DbSightRepository();

        //Lists
        List<FilmInformationModel> films = new List<FilmInformationModel>();
        List<RestaurantInformatieModel> restaurants = new List<RestaurantInformatieModel>();
        List<SpecialInformationModel> specials = new List<SpecialInformationModel>();

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
            IEnumerable<Film> allFilms = filmrep.GetAllFilms();
            IEnumerable<FilmModel> dayFilms = filmrep.GetDayFilms();
            IEnumerable<Film> topFilms = filmrep.GetTopFilms();
            var films = new Tuple<IEnumerable<Film>, IEnumerable<FilmModel>, IEnumerable<Film>>(allFilms, dayFilms, topFilms);
            return View(films);
        }

        //Show FilmInformation
        public ActionResult ShowFilmInformation(int filmId)
        {
            FilmInformationModel film = filmrep.GetFilmInformation(filmId);
            films.Add(film);
            WLEventModel Show = new WLEventModel();
            var allModels = new Tuple<List<FilmInformationModel>, WLEventModel>(films, Show);
            return View(allModels);
        }

        [HttpPost]
        public ActionResult ShowFilmInformation(WLEventModel show)
        {
            if(ModelState.IsValid)
            {
                show.Price = show.Quantity * 7.50f;
                show.Type = "Film";
                return RedirectToAction("MakeWishlist", "Wishlist", show);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowFilmLocations()
        {
            return View();
        }

        //Restaurants
        //Show all restaurants
        public ActionResult ShowRestaurants()
        {
            IEnumerable<Restaurant> allRestaurants = resrep.GetAllRestaurants();

            return View(allRestaurants);
        }

        public ActionResult ShowRestaurantInformation(int restaurantId)
        {
            RestaurantInformatieModel restaurant = resrep.GetRestaurantInformation(restaurantId);
            restaurants.Add(restaurant);
            WLEventModel show = new WLEventModel();
            var allModels = new Tuple<List<RestaurantInformatieModel>, WLEventModel>(restaurants, show);
            return View(allModels);
        }

        [HttpPost]
        public ActionResult ShowRestaurantInformation(WLEventModel show)
        {
            if (ModelState.IsValid)
            {
                show.Type = "Restaurant";
                show.Price = 10;
                return RedirectToAction("MakeWishlist", "Wishlist", show);
            }
            return RedirectToAction("Index", "Home");
        }


        //Specials
        //Show all specials and filters
        public ActionResult showSpecials()
        {
            IEnumerable<Special> allSpecials = specrep.GetAllSpecials();
            IEnumerable<SpecialModel> DaySpecials = specrep.GetDaySpecials();
            var specials = new Tuple<IEnumerable<Special>,IEnumerable<SpecialModel>>(allSpecials,DaySpecials);
            return View(specials);
        }

        //Show special information
        public ActionResult ShowSpecialInformation(int specialId)
        {
            SpecialInformationModel special = specrep.GetSpecialInformation(specialId);
            specials.Add(special);
            WLEventModel show = new WLEventModel();
            var allModels = new Tuple<List<SpecialInformationModel>, WLEventModel>(specials, show);
            return View(allModels);
        }

        [HttpPost]
        public ActionResult ShowSpecialInformation(WLEventModel show)
        {
            if (ModelState.IsValid)
            {
                show.Type = "Special";
                return RedirectToAction("MakeWishlist", "Wishlist", show);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowSpecialLocations()
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
            IEnumerable<Sight> allSights = sightrep.GetAllSights();
            return View(allSights);
        }

    }
}
