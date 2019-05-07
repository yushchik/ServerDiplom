using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApplication4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //services.AddDefaultIdentity<User>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

             services.AddIdentity<User, IdentityRole>()
             //services.AddDefaultIdentity<IdentityUser>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultUI()
             .AddDefaultTokenProviders();
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //private async Task CreateUserRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

        //    IdentityResult roleResult;
        //    //Adding Admin Role
        //    var roleCheck = await RoleManager.RoleExistsAsync("User");
        //    if (!roleCheck)
        //    {
        //        //create the roles and seed them to the database
        //        roleResult = await RoleManager.CreateAsync(new IdentityRole("User"));
        //    }
        //    //Assign Admin role to the main User here we have given our newly registered 
        //    //login id for Admin management
        //    //User user = await UserManager.FindByEmailAsync("PRIMAVER@MAIL.RU");
        //    //var User = new User();
        //    //await UserManager.AddToRoleAsync(user, "Admin");
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //CreateUserRoles(service).Wait();
        }

     
    }
}
