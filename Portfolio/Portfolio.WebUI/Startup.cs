using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Application.Modules.IndexModules.IndexUser;
using Portfolio.Domain.Models.DataContext;
using Portfolio.Domain.Models.Entities.Membership;
using System;
using System.Linq;

namespace Portfolio.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            });


            services.AddRouting(cfg => cfg.LowercaseUrls = true);

            services.AddDbContext<PortfolioDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("cString"));
            }).AddIdentity<PortfolioUser, PortfolioRole>()
                .AddEntityFrameworkStores<PortfolioDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequiredLength = 3;

                cfg.User.RequireUniqueEmail = true;

                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);
            });

            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/signin.html";
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "Portfolio";
            });

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<UserManager<PortfolioUser>>();
            services.AddScoped<RoleManager<PortfolioRole>>();
            services.AddScoped<SignInManager<PortfolioUser>>();

            services.AddTransient<IndexList>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            var asmbls = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Portfolio")).ToArray();
            services.AddMediatR(asmbls);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("Portfolio") && context.Request.RouteValues.TryGetValue("area", out object area)
                && area.ToString().ToLower().Equals("admin")
                )
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    if (attr == null)
                    {
                        context.Response.Redirect("/admin/signin.html");
                        await context.Response.CompleteAsync();
                    }
                }
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.SeedMembership();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin-signIn", "admin/signin.html",
             defaults: new
             {
                 controller = "Account",
                 area = "Admin",
                 action = "login"
             }
             );
                endpoints.MapControllerRoute("admin-signout", "admin/signout.html",
               defaults: new
               {
                   controller = "Account",
                   area = "Admin",
                   action = "login"
               }
               );
                endpoints.MapControllerRoute(
                    name: "default-signin",
                    pattern: "signin.html",
                    defaults: new
                    {
                        area = "",
                        controller = "Account",
                        action = "Signin"
                    });

                endpoints.MapControllerRoute(
                    name: "default-accessdenied",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        area = "",
                        controller = "Account",
                        action = "accessdenied"
                    });

                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );
                endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");

            });
        }
    }
}
