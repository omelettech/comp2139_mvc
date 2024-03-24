using comp2139_mvc.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comp2139_mvc.Areas.ProjectManagement.Controllers
{
	[Area("ProjectManagement")]
	[Route("[area]/[controller]/[action]")]
	public class TaskController : Controller
	{
		private readonly ApplicationDbContext _context;

		public TaskController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpGet("Index/{projectId:int}")]
		public async Task<IActionResult> Index(int? projectId)
		{
			// return result set 
			var taskQuery = _context.Tasks.AsQueryable();

			if (projectId.HasValue)
			{
				taskQuery = taskQuery.Where(t => t.projectId == projectId.Value);
			}

			var tasks = await taskQuery.ToListAsync();
			ViewBag.ProjectId = projectId;
			return View(tasks);

		}

		// GET: TaskController/Details/5
		[HttpGet("Project")]
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: TaskController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TaskController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TaskController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TaskController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TaskController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: TaskController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
