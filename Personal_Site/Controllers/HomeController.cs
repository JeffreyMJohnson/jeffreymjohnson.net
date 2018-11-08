using Personal_Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Markdig;

namespace Personal_Site.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = null;

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
            var posts = _context.BlogPosts.OrderByDescending(p => p.Date).ToList();
            ConvertBlogPostMarkdownToHtml(ref posts);
            return View(posts);
        }

        private void ConvertBlogPostMarkdownToHtml(ref List<BlogPost> posts)
        {
            foreach (var blogPost in posts)
            {
                var body = blogPost.Body;
                var bodyAsHtml = Markdown.ToHtml(body);
                blogPost.Body = bodyAsHtml;
            }
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

        public ActionResult CreateBlog()
        {
            return View();
        }

        
    }
}