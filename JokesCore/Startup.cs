using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using JokesCore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using JokesCore.service;

namespace JokesCore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["JokesCore"]));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();

            var mailkit = Configuration.GetSection("Email").Get<MailKitOptions>();
            services.AddTransient<IEmailSender, EmailSender>(i =>
                new EmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]
                )
            );
            services.AddMvc();

        }
        public async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            IdentityResult result;

            //rollen aanmaken
            string[] rollen = { "Admin", "Gebruiker"};

            foreach (string item in rollen)
            {
                if (!await roleManager.RoleExistsAsync(item))
                {
                    result = await roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(serviceProvider).Wait();
        }
    }
}
