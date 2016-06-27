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
        const string PROJECTS_PATH = "~/Views/Home/projects/";
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
            return View(PROJECTS_PATH + "MagicandMagnums.cshtml");
        }

        public ActionResult GachaTown()
        {
            return View(PROJECTS_PATH + "GachaTown.cshtml");
        }

        public ActionResult Versiworld()
        {
            return View(PROJECTS_PATH + "VersiWorld.cshtml");
        }

        public ActionResult JMath()
        {
            return View(PROJECTS_PATH + "JMath.cshtml");
        }
        public ActionResult DontQuestionIt()
        {
            return View(PROJECTS_PATH + "DontQuestionIt.cshtml");
        }
    }
}