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
            //var datafile = Server.MapPath("~/foo.txt");
            //System.IO.File.WriteAllText(datafile, "wut me?");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Projects()
        {
            //Main.Models.ProjectList projects = new ProjectList(Server.MapPath("~/"));
            Main.Models.GithubUser user = new GithubUser(Server.MapPath("~/") + "App_Data\\");
            return View(Main.Models.Globals.Projects);
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