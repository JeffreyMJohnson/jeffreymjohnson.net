using Personal_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personal_Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var posts = GetBlogPosts();
            return View(posts);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ApplicationDbContext _context = null;

        private IEnumerable<BlogPost> GetBlogPosts()
        {
            var posts = _context.BlogPosts;
            return posts;
        }
    }
}