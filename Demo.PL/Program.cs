using Demo.BLL.Services;
using Demo.DAL.Data;
using Demo.DAL.Data.Repository.Claess;
using Demo.DAL.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services [any method that use DI]
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<AppDbContext>(); // allow DI for AppDbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // used to inforce using the https protocol if the user used the http protocol
            app.UseStaticFiles(); // used to allow using the static files like the css and js files located in wwwroot

            app.UseRouting(); // used to set up the routing in the application. to match incoming HTTP requests to corresponding route 

            app.UseAuthorization(); // Adds the authorization middleware, which ensures that access to resources is restricted based on user permissions or roles.

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
