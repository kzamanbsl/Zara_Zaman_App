using app.Infrastructure;
using app.Infrastructure.Auth;
using app.Infrastructure.Repository;
using app.Services;
using app.WebApp.Handlers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // var config = new  IConfiguration();

            builder.Services.AddServiceModel(builder.Configuration);
            builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            builder.Services.AddScoped<IWorkContext, WorkContextsService>();
            builder.Services.AddTransient<IAssignMenus, AssignMenus>();

            builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            builder.Services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<InventoryDbContext>().AddDefaultTokenProviders();        
            builder.Services.ConfigureApplicationCookie(
            options =>
            {
                //options.LoginPath = new PathString("/Home/Index");
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.LogoutPath = new PathString("/Account/Logout");
                options.Cookie.Name = "My.Cookie";
                //options.Cookie.Expiration = TimeSpan.FromDays(1);
            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.IOTimeout = TimeSpan.FromDays(1);                
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddRazorPages();
            builder.Services.AddMemoryCache();
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");            
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
            app.Run();
        }
    }
}