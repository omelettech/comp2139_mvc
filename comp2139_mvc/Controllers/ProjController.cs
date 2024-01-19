using comp2139_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace comp2139_mvc.Controllers
{
    public class ProjController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var projects = new List<Project>()
            {
                new Project { ProjId=1,ProjName="Super",Description="" }


            };
            return View(projects);
            //returns the list of projects to the view index.cshtml so it can use the projects list to dynamically create the page
        }
    }
}
