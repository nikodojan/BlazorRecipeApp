using BlazorRecipeApp.Areas.Identity;
using BlazorRecipeApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRecipeApp.Services.Services;
using BlazorRecipeApp.Models;
using BlazorRecipeApp.Services.Interfaces;

namespace BlazorRecipeApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextFactory<ApplicationDbContext>(options => options
                .UseMySql(Configuration.GetConnectionString("LocalMySQL"),
                    new MySqlServerVersion(new Version(8, 0, 25)))
                .EnableSensitiveDataLogging(true)
            );

            services.AddTransient<Services.Interfaces.IRecipeService, Services.Services.EfRecipeServiceV1>();
            services.AddTransient<Services.Interfaces.IMenuService, Services.Services.EfMenuServiceV1>();

            services.AddDbContext<ApplicationDbContext>(options => options
                .UseMySql(Configuration.GetConnectionString("LocalMySQL"),
                    new MySqlServerVersion(new Version(8, 0, 25)))
                .EnableSensitiveDataLogging());

            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;

                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole<int>>()
                .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";

                // for development purposes
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddTransient(sp => new HttpClient(){BaseAddress = new Uri("https://localhost:44379/") });

            //services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<MmStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<MmStateProvider>());
            services.AddScoped<IAuthService, MmAuthService>();



            services.AddDatabaseDeveloperPageExceptionFilter();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
