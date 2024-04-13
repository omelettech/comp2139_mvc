using Microsoft.EntityFrameworkCore;
using comp2139_mvc.Areas.ProjectManagement.Models;
using comp2139_mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace comp2139_mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> Tasks { get; set; }
		public DbSet<ProjectComment> Comments { get; set; }
	}
}
