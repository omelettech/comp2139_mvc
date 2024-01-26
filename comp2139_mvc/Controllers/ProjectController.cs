using comp2139_mvc.Data;
using comp2139_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace comp2139_mvc.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Index()
        {

            var projects=_context.Projects;


            return View(projects);
            //returns the list of projects to the view index.cshtml so it can use the projects list to dynamically create the page
        }
    }
}
