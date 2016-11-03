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

        public ActionResult Projects(bool forceRefresh = false)
        {
            Main.Models.GithubUser user = new GithubUser(Server.MapPath("~/") + "App_Data\\", forceRefresh);
            return View(user);
        }

        public ActionResult ProjectDetail(string projectName)
        {//todo implement exception handling for all views.
            Main.Models.GithubUser user = new GithubUser(Server.MapPath("~/") + "App_Data\\");
            try
            {
                return View(user.GetRepo(projectName));
            }
            catch (ArgumentException e)
            {
                return View("SomethingFuckedUp", (object)e.Message);
            }
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ProjectPage(string projectName)
        {

            return View("projects/" + projectName);
        }
    }
}