using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Services.Implementations;
using OnlineShop.Application.Services.Interfaces;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.AppDbContext;
using OnlineShop.Persistence.Repositories;

namespace Project_OnlineShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(
            //    @"Data source=DESKTOP-73VTHTD;Initial Catalog=ShopProject;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;"));

            builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDbContext")));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService , UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}