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
        private IOrderRepository orderrep = new DbOrderRepository();

        //lists
        List<WLEventModel> wishlist = new List<WLEventModel>();
        
        public ActionResult Index()
        {
            return View();
        }
        
        //show Wishlist without parameter
        public ActionResult ShowWishlist()
        {
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            if (wishlist == null)
                return RedirectToAction("GetWishlist", "Wishlist");
            else
                return View(wishlist);
        }

        [HttpPost]
        public ActionResult ShowWishlist(EventWishList wishlist)
        {
            if (Session != null & Session["WishlistSession"] != null)
            {
                return RedirectToAction("ShowOrder", "Order");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //show Wishlist by selecting an event
        public ActionResult MakeWishlist(WLEventModel show)
        {
            if (show.Type == "Film")
            {
                List<DayTimeLocationModel> allShows = eventrep.GetAllShowings(show.Id);
                show.DayTimeLocation = allShows[show.Showing];
            }
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
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult MakeWishlist(EventWishList wishlist)
        {
            if (Session != null & Session["WishlistSession"] != null)
            {
                return RedirectToAction("ShowOrder", "Order");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult SavedWishlist(Order newOrder)
        {
            var tuple = new Tuple<List<WLEventModel>, Order>(wishlist, newOrder);
            return View(tuple);
        }

        [HttpPost]
        public ActionResult SavedWishlist()
        {
            if (Session != null & Session["WishlistSession"] != null)
            {
                return RedirectToAction("ShowOrder", "Order");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult GetWishlist()
        {
            Order newOrder = new Order();
            var tuple = new Tuple<List<WLEventModel>, Order>(wishlist, newOrder);
            return View(tuple);
        }

        [HttpPost]
        public ActionResult GetWishlist(Order order)
        {
            wishlist = orderrep.GetWishlist(order);
            this.Session["WishlistSession"] = wishlist;
            Order newOrder = new Order();
            return RedirectToAction("ShowWishlist", "Wishlist");
        }

        public ActionResult SaveWishlist()
        {
            double totaal = 0;
            string codeergeval;
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;

            foreach (WLEventModel wl in wishlist)
            {
                totaal = totaal + wl.Price;
            }
            Order savedOrder = new Order();
            savedOrder.OrderType = "WishList";
            savedOrder.TotalPrice = totaal;
            orderrep.OrderToDatabase(wishlist, savedOrder, out codeergeval);
            savedOrder.Code = codeergeval;
            return RedirectToAction("SavedWishlist", "Wishlist", savedOrder);
        }

        public ActionResult DeleteWishlistItem(WLEventModel remove)
        {
            List<WLEventModel> list = this.Session["WishlistSession"] as List<WLEventModel>;
            var item = list.First(x => x.Id == remove.Id);
            list.Remove(item);
            this.Session["WishlistSession"] = list;

            return RedirectToAction("ShowWishlist", "Wishlist");
        }
    }
}
