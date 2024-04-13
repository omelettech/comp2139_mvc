using Microsoft.AspNetCore.Identity;

namespace comp2139_mvc.Models
{
	public class User : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public int UserNameChangeLimit { get; set; } = 100;
		public byte[]? ProfilePicture { get; set; }
		public IList<string>? RoleNames { get; set; } = null;
	}
}
