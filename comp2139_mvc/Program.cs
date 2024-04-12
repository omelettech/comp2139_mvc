using comp2139_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace comp2139_mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //migration = cloning an existing database
            builder.Services.AddControllersWithViews();
<<<<<<< HEAD

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

=======
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            
            );
>>>>>>> 09bbd9f7b5e1e87e27e0cc734f0076ab72fc8d81
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapAreaControllerRoute(
                name: "ProjectManagement",
                areaName: "ProjectManagement",
                pattern: "{area:exists}/{controller=Project}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "comment",
                pattern: "{controller=ProjectComment}/{action=GetComment}/{id?}");


            app.Run();
        }
        
    }
}
