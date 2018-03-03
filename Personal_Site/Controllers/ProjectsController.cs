using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Personal_Site.Models;

namespace Personal_Site.Controllers
{
    public class ProjectsController : Controller
    {
        
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Projects
        public ActionResult Index()
        {
            var projects = GetProjects();
            return View(projects);
        }

        public ActionResult Details(int? id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return new HttpNotFoundResult();
            }
            return View(project);
        }

        private ApplicationDbContext _context;

        private IEnumerable<Project> GetProjects()
        {
            var projects = _context.Projects.OrderByDescending(p => p.Date);
            return projects;
        }
    }
}