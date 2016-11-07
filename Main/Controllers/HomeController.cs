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
            return View();
        }

        public ActionResult ProjectDetail(string projectName)
        {
            Main.Models.GithubUser user = new GithubUser();
            try
            {
                //just return the readme as string now.
                return View((object)Main.Models.GithubUser.GetReadMeHTML(projectName));
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