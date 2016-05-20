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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowOrder()
        {
            wishlist = this.Session["WishlistSession"] as List<WLEventModel>;
            return View(wishlist);
        }

        [HttpPost]
        public ActionResult ShowOrder(Order order)
        {
            // Order naar DB

            return RedirectToAction("ShowThanks");
        }

        public ActionResult ShowThanks()
        {
            return View();
        }

    }
}