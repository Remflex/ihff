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

        [HttpPost]
        public ActionResult ShowWishlist(EventWishList wishlist)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ShowOrder", "Order", wishlist);
            }
            return RedirectToAction("Index", "Home");
        }

        //show Wishlist by selecting an event
        public ActionResult MakeWishlist(WLEventModel show)
        {
            List<DayTimeLocationModel> allShows = eventrep.GetAllShowings(show.Id);
            show.DayTimeLocation = allShows[show.Showing];
            //Als session bestaat, maak hem niet opnieuw aan.
            if (Session != null & Session["WishlistSession"] != null)
            {
                wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            }
            else
            {
                Session["WishlistSession"] = wishlist;
            }
            wishlist.Add(show);
            this.Session["WishlistSession"] = wishlist;
            EventWishList order = new EventWishList();
            var orderWishlist = new Tuple<List<WLEventModel>, EventWishList>(wishlist, order);
            return View(orderWishlist);
        }

        [HttpPost]
        public ActionResult MakeWishlist(EventWishList wishlist)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ShowOrder", "Order", wishlist);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
