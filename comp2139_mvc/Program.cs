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
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
