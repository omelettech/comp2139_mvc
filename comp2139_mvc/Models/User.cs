using Microsoft.AspNetCore.Identity;

namespace comp2139_mvc.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }
		public IList<string>? RoleNames { get; set; } = null;
	}
}
