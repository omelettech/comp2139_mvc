<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using comp2139_mvc.Areas.ProjectManagement.Models;
=======
﻿using comp2139_mvc.Models;
using Microsoft.EntityFrameworkCore;
>>>>>>> 09bbd9f7b5e1e87e27e0cc734f0076ab72fc8d81
namespace comp2139_mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
<<<<<<< HEAD
        
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectTask> Tasks { get; set; }
		public DbSet<ProjectComment> Comments { get; set; }
	}
=======
        public DbSet<Project> Projects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {




    }
}
>>>>>>> 09bbd9f7b5e1e87e27e0cc734f0076ab72fc8d81
}
