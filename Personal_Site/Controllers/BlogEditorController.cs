using System.Linq;
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

        

    }
}