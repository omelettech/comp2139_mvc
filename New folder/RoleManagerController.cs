using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace comp2139_mvc.Controllers
{
    //[Authorize(Roles="SuperAdmin, Admin")] class level or action level
    // this annotation can be applied to individual actions
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager; 
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
        
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRoles(string roleName)
        {
            if (roleName == null)
            {
                return View(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
    }
}
