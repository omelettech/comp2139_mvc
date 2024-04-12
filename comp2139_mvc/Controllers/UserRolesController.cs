using comp2139_mvc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace comp2139_mvc.Controllers
{
	[Authorize(Roles ="SuperAdmin,Admin")]
	public class UserRolesController : Controller
	{
		public readonly RoleManager<IdentityRole> _roleManager;
		public readonly UserManager<IdentityUser> _userManager;
		//TODO: application user

		public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}
		private async Task<List<string>> GetUserRolseAsync(ApplicationUser user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}

		public async IActionResult Index()
		{
			var users = await _userManager.Users.ToListAsync();
			var UserRolesViewModel = new List<UserRoleViewModel>();
			foreach (var user in users)
			{
				var thisViewModel = new UserRoleViewModel();
				thisViewModel.UserId = user.Id;
				thisViewModel.FirstName=user.FirstName
				thisViewModel.LastName = user.LastName;
				thisViewModel.Email = user.Email;
				thisViewModel.Roles = await GetUserRolseAsync(user);
				UserRolesViewModel.Add(thisViewModel);

			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Manage(string userId)
		{
			ViewBag.userId = userId;
			var user = await _userManager.FindByNameAsync(userId);
			if(user == null)
			{
				ViewBag.ErrorMessage = $"User id not found";
				return View("NotFound");
			}
			ViewBag.UserName = user.UserName;
			var model = new List<UserRoleViewModel>();
			foreach(var role in _roleManager.Roles)
			{
				var userRolesViewModel = new ManageUserRoleViewModel
				{
					RoleId = role.Id,
					RoleName = role.Name
				};
				if(await _userManager.IsInRoleAsync(user, role.Name))
				{
					userRolesViewModel.Selected=true;
				}
				else
				{
					userRolesViewModel.Selected = false;
				}
				model.Add(userRolesViewModel);
			}
			return View(model);
		}
	}
}
