using comp2139_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace comp2139_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GeneralSearch(string searchType, string searchString)
        {
            if (searchType == "Projects")

            {
                return RedirectToAction("Search", "Project", new { searchString });
            }

            else if (searchType == "Tasks")
            {
               
                int defaultProjectId = 1;
                return RedirectToAction("Search", "Task", new { projectId = defaultProjectId, searchString });
            }
            return View("Index", "Project");
        }
        public IActionResult NotFound(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }
            else
            {
                return View("Error");
            }
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
