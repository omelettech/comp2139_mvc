using comp2139_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using comp2139_mvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var projects = _context.Projects.ToList();
            return View(projects);
            //returns the list of projects to the view index.cshtml so it can use the projects list to dynamically create the page
        }
        [HttpGet]
        public IActionResult Details()
        {
            var projects = _context.Projects.ToList();
            return View(projects);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if(!ModelState.IsValid)
            {
                return View(project);
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Project model = _context.Projects.Find(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Project model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(model).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View("Edit", model);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the exception or handle it as needed
                // Optionally, you can reload the entity and allow the user to resolve the conflict
                _context.Entry(model).Reload();
                ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another user. Your changes were not saved.");
                return View("Edit", model);
            }

            // If the model state is not valid, return to the form with validation errors
        }


    }
}
