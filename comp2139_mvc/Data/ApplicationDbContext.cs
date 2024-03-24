using Microsoft.EntityFrameworkCore;
using comp2139_mvc.Areas.ProjectManagement.Models;
namespace comp2139_mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> Tasks { get; set; }
		public DbSet<ProjectComment> Comments { get; set; }
	}
}
