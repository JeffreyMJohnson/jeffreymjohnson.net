using System.Web.Mvc;

namespace Personal_Site.Controllers
{
    public class BlogEditorController : Controller
    {
        [RequireHttps]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}