using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarlInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Get Your Cheap Insurance";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Call us at 555-5555";

            return View();
        }
    }
}