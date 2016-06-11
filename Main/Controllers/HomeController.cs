using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Main.Models;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult MagicAndMagnums()
        {
            return View();
        }

        public ActionResult GachaTown()
        {
            return View();
        }

        public ActionResult Versiworld()
        {
            return View();
        }

        public ActionResult JMath()
        {
            return View();
        }
    }
}