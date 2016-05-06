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
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowOrder(EventWishList wishlist)
        {
            return View(wishlist);
        }

        public ActionResult ShowThanks()
        {
            return View();
        }

    }
}