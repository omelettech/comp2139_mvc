using comp2139_mvc.Areas.ProjectManagement.Models;
using comp2139_mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace comp2139_mvc.Areas.ProjectManagement.Controllers
{
    [Area("ProjectManagement")]

    public class ProjectCommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectCommentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetComments(int projectId)
        {
            var comments = await _context.Comments.Where(c => c.ProjectId == projectId).OrderByDescending(c => c.DatePosted).ToListAsync();

            return Json(comments);
        }


        [HttpPost]
        public async Task<IActionResult> AddComments([FromBody] ProjectComment comment)
        
        {
            
            if (ModelState.IsValid)
            {
                
                comment.DatePosted = DateTime.Now;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Comment added successfully" });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = "Invalid comment data.", error = errors });
        }
    }
}
