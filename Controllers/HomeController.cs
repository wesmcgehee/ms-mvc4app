using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "\"One should not pursue goals that are easily achieved. One must develop an instinct for what one can just barely achieve through one's greatest efforts.\"  —Albert Einstein.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What about what?  What's it to ya?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
