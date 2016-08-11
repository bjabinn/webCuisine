using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RssLibrary;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var ch = new RssFeader("https://channel9.msdn.com/feeds/rss").GetWholeChannel();
            return View("Index", ch);
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}