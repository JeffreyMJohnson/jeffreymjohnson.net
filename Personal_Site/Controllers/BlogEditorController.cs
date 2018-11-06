using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Personal_Site.Models;

namespace Personal_Site.Controllers
{
    public class BlogEditorController : Controller
    {
        private IDbContext _dbContext;

        public BlogEditorController() :this(new ApplicationDbContext()){}

        public BlogEditorController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [RequireHttps]
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var blogs = _dbContext.BlogPosts.ToList();
            return View(blogs);
        }

        [RequireHttps]
        [Authorize]
        [HttpGet]
        public JsonResult GetBlogPost(int id = 0)
        {
            if (id == 0) return null;

            var blog = _dbContext.BlogPosts.FirstOrDefault(p => p.Id == id);

            return Json(blog, JsonRequestBehavior.AllowGet);
        }

        [RequireHttps]
        [Authorize]
        [HttpPost]
        public JsonResult SaveBlogPost(BlogPost blogPost)
        {
            //check if new record
            var success = false;
            if (blogPost.Id == 0)
            {
                blogPost.Id = null;
                blogPost.Date = DateTime.Now;

                _dbContext.BlogPosts.Add(blogPost);
                _dbContext.SaveChanges();
                success = true;
            }
            else
            {
                var post = _dbContext.BlogPosts.FirstOrDefault(p => p.Id == blogPost.Id);
                if (post != null)
                {
                    post.Title = blogPost.Title;
                    post.Summary = blogPost.Summary;
                    post.Body = blogPost.Body;

                    _dbContext.SaveChanges();
                    success = true;
                }
            }
            return Json(new {success = success});
        }


    }
}