using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CreditReport.Data;
using CreditReport.Models;
using CreditReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using CreditReport.Authorization;
using CreditReport.Data.PersonalInformation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CreditReport
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //}
        // This method gets called by the runtime. Use this method to add services to the container.
        #region ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 2;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            // services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            // If you don't want the cookie to be automatically authenticated and assigned to HttpContext.User, 
            // remove the CookieAuthenticationDefaults.AuthenticationScheme parameter passed to AddAuthentication.
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //        .AddCookie(options =>
            //        {
            //            options.LoginPath = "/Account/LogIn";
            //            options.LogoutPath = "/Account/Logout";
            //        });
            //If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
            //services.AddAuthentication()
            //        .AddFacebook(options =>
            //        {
            //            options.AppId = Configuration["auth:facebook:appid"];
            //            options.AppSecret = Configuration["auth:facebook:appsecret"];
            //        });


            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            #region snippet_SSL 
            //var skipSSL = Configuration.GetValue<bool>("LocalTest:skipSSL");
            //// requires using Microsoft.AspNetCore.Mvc;
            //services.Configure<MvcOptions>(options =>
            //{
            //    // Set LocalTest:skipSSL to true to skip SSL requrement in 
            //    // debug mode. This is useful when not using Visual Studio.
            //    if (_hostingEnv.IsDevelopment() && !skipSSL)
            //    {
            //        options.Filters.Add(new RequireHttpsAttribute());
            //    }
            //});
            #endregion

             #region snippet_defaultPolicy
            //// requires: using Microsoft.AspNetCore.Authorization;
            ////           using Microsoft.AspNetCore.Mvc.Authorization;
            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));
            //});
             #endregion           

             #region AuthorizationHandlers
            //// Authorization handlers.
            //services.AddScoped<IAuthorizationHandler,
            //                      ContactIsOwnerAuthorizationHandler>();

            //services.AddSingleton<IAuthorizationHandler,
            //                      AdministratorsAuthorizationHandler>();

            //services.AddSingleton<IAuthorizationHandler,
            //                      ContactManagerAuthorizationHandler>();
             #endregion

            services.AddMvc();
        }
        #endregion


        //private IHostingEnvironment _hostingEnv;

        //public Startup(IHostingEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

        //    if (env.IsDevelopment())
        //    {
        //        // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
        //        builder.AddUserSecrets<Startup>();
        //    }

        //    builder.AddEnvironmentVariables();
        //    Configuration = builder.Build();

        //    _hostingEnv = env;
        //}

       // public IConfigurationRoot Configuration { get; }

       

        #region Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           // app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //// Set password with the Secret Manager tool.
            //// dotnet user-secrets set SeedUserPW <pw>
            //var testUserPw = "Q!w2e3r4"; // Configuration["SeedUserPW"];

            //if (String.IsNullOrEmpty(testUserPw))
            //{
            //    throw new System.Exception("Use secrets manager to set SeedUserPW \n" +
            //                               "dotnet user-secrets set SeedUserPW <pw>");
            //}

            //try
            //{
            //    SeedData.Initialize(app.ApplicationServices, "Q!w2e3r4").Wait();
            //}
            //catch(Exception ex)
            //{
            //    throw new System.Exception("You need to update the DB "
            //        + "\nPM > Update-Database " + "\n or \n" +
            //          "> dotnet ef database update"
            //          + "\nIf that doesn't work, comment out SeedData and "
            //          + "register a new user");
            //}
            #endregion
        }
    }
}
