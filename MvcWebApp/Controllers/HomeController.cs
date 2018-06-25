using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        [VirtualDom]
        public ActionResult Index()
        {
            return View();
        }

        [VirtualDom]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [VirtualDom]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}