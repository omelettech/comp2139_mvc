using comp2139_mvc.Models;
using Microsoft.EntityFrameworkCore;
namespace comp2139_mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {




    }
}
}
