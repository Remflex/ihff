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
        List<WLEventModel> thankYou = new List<WLEventModel>();
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
            string codeergeval;
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            if (ModelState.IsValid)
            {
                newOrder.OrderType = "Order";
                orderep.OrderToDatabase(wishlist, newOrder, out codeergeval);
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
            thankYou = wishlist;
            this.Session["WishlistSession"] = null;
            var thanks = new Tuple<List<WLEventModel>, Order>(thankYou, order);
            return View(thanks);
        }

    }
}