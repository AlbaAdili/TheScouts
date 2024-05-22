using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheScouts.Data;
using TheScouts.Models;
using TheScouts.Repositories;
using TheScouts.Services;
namespace TheScouts;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IPositionRepository, PositionRepository>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();
        builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
        builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();

        builder.Services.AddScoped<IPositionService, PositionService>();
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IApplicationService, ApplicationService>();
        builder.Services.AddScoped<INewsletterService, NewsletterService>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}