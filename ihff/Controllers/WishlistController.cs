using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Controllers;
using ihff.Models;

namespace ihff.Controllers
{
    public class WishlistController : Controller
    {
        //repositorys
        private IEventRepository eventrep = new DbEventRepository();

        //lists
        List<WLEventModel> wishlist = new List<WLEventModel>();

        public ActionResult Index()
        {
            return View();
        }

        //show Wishlist withouth parameter
        public ActionResult ShowWishlist()
        {
            EventWishList order = new EventWishList();
            var orderWishlist = new Tuple<List<WLEventModel>, EventWishList>(wishlist, order);
            return View(orderWishlist);
        }

        //show Wishlist by selecting an event
        public ActionResult MakeWishlist(WLEventModel show)
        {
            List<DayTimeLocationModel> allShows = eventrep.GetAllShowings(show.Id);
            show.DayTimeLocation = allShows[show.Showing];
            Session["WishlistSession"] = wishlist;
            wishlist.Add(show);
            EventWishList order = new EventWishList();
            var orderWishlist = new Tuple<List<WLEventModel>, EventWishList>(wishlist, order);
            return View(orderWishlist);
        }

        //Set wishlist over to Order
        [HttpPost]
        public ActionResult MakeWishlist(EventWishList wishlist)
        {
            return RedirectToAction("ShowOrder", "Order", wishlist);
        }

    }
}
