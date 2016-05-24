using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;
using ihff.Controllers;

namespace ihff.Controllers
{
    public class OrderController : Controller
    {
        List<WLEventModel> wishlist = new List<WLEventModel>();
        private IOrderRepository orderep = new DbOrderRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowOrder()
        {
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            Order newOrder = new Order();
            var order = new Tuple<List<WLEventModel>, Order>(wishlist, newOrder);
            return View(order);
        }

        [HttpPost]
        public ActionResult ShowOrder(Order newOrder)
        {
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            if (ModelState.IsValid)
            {
                //orderep.OrderToDatabase(wishlist, newOrder);
                wishlist = null;
                return RedirectToAction("ShowThanks", newOrder);
                
            }
            else
            {
                wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
                var order = new Tuple<List<WLEventModel>, Order>(wishlist, newOrder);
                return View(order);
            }
            }

        public ActionResult ShowThanks(Order order)
        {
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            var thanks = new Tuple<List<WLEventModel>, Order>(wishlist, order);
            return View(thanks);
        }

    }
}