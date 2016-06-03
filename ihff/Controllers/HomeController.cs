using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ihff.Models;
using ihff.Controllers;

namespace ihff.Controllers
{
    public class HomeController : Controller
    {
        private IHomeRepository homeRes = new DbHomeRepository();

        public ActionResult Index()
        {
            List<HomeModel> home = new List<HomeModel>();
            home = homeRes.GetSuggested();
            return View(home);
        }

        public ActionResult Disclaimer()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult SiteMap()
        {
            return View();
        }
    }
}
