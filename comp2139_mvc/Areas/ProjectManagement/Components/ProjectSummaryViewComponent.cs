using comp2139_mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using comp2139_mvc.Areas.ProjectManagement.Models;

namespace comp2139_mvc.Areas.ProjectManagement.Components
{
    public class ProjectSummaryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ProjectSummaryViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
		public async Task<IViewComponentResult> InvokeAsync(int projectId)
		{
			var project = await _context.Projects.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.ProjectId == projectId);

			if (project == null)
			{
				return Content("Project Not Found.");
			}

			return View(project);
		}

	}

}
