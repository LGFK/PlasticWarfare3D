using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using PLASTIC_WARFARE_PROJ.Areas.Identity.Data;
using PLASTIC_WARFARE_PROJ.DbContextData;
using PLASTIC_WARFARE_PROJ.Repos;
using PLASTIC_WARFARE_PROJ.Services;
using System.Configuration;

namespace PLASTIC_WARFARE_PROJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString1 = builder.Configuration.GetConnectionString("IdentityConnection") ?? throw new InvalidOperationException("Connection string 'Plastic_Warfare_IdentityConnection' not found.");
            
            builder.Services.AddDbContext<Plastic_Warfare_Identity>(options => options.UseSqlServer(connectionString1));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Plastic_Warfare_Identity>();
            var connectionString2 = builder.Configuration.GetConnectionString("OrdersDataConnection") ?? throw new InvalidOperationException("Connection string 'OrdersDataConnection' not found.");

            builder.Services.AddDbContext<MainDataContext>(options => options.UseSqlServer(connectionString2));
            builder.Services.AddScoped<IPlasticWarfareRepo,PlasticWarfareRepo>( );
            // Add services to the container.
            builder.Services.AddTransient<IEmailSender, EmailSender>(i =>
                                new EmailSender(
                                builder.Configuration["Email:SmtpServer"],
                                builder.Configuration.GetValue<int>("Email:SmtpPort"),
                                builder.Configuration["Email:SmtpUser"],
                                builder.Configuration["Email:SmtpPass"]
        )
            );
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}