using BlazorRecipeApp.Areas.Identity;
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
using BlazorRecipeApp.Mm.Identity.Models;
using BlazorRecipeApp.Mm.Identity.Services;
using BlazorRecipeApp.Mm.MealPlans.Services;
using BlazorRecipeApp.Mm.Recipes.Services;
using BlazorRecipeApp.Mm.Shared.Data;
using BlazorRecipeApp.Mm.Shared.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;

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
            services.AddCors(options =>
            {
                options.AddPolicy("All", builder => 
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
                
            // DbContext and factory
            // Local
            //services.AddDbContextFactory<ApplicationDbContext>(options => options
            //    .UseMySql(Configuration.GetConnectionString("LocalMySQL"),
            //        new MySqlServerVersion(new Version(8, 0, 25)))
            //    .EnableSensitiveDataLogging(true)
            //);

            //services.AddDbContext<ApplicationDbContext>(options => options
            //    .UseMySql(Configuration.GetConnectionString("LocalMySQL"),
            //        new MySqlServerVersion(new Version(8, 0, 25)))
            //    .EnableSensitiveDataLogging());

            //    // Simply
            services.AddDbContextFactory<ApplicationDbContext>(options => options
                .UseMySql(Configuration.GetConnectionString("SimplyMmDb"),
                    new MySqlServerVersion(new Version(5, 7)))
                .EnableSensitiveDataLogging(true)
            );

            services.AddDbContext<ApplicationDbContext>(options => options
                .UseMySql(Configuration.GetConnectionString("SimplyMmDb"),
                    new MySqlServerVersion(new Version(5, 7)))
                .EnableSensitiveDataLogging());



            // Services for MenuMaker functions
            services.AddTransient<IRecipeService, EfRecipeServiceV1>();
            services.AddTransient<IMenuService, EfMenuServiceV1>();
            services.AddTransient<IUserService, MmUserService>();
            services.AddTransient<IMenuFactory, MenuFactory>();


            // Identity services
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
            
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "MMCookie";
                options.Cookie.HttpOnly = false;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            //services.AddTransient(sp => new HttpClient(){BaseAddress = new Uri("https://localhost:5001/") });
            
            services.AddTransient(sp => new HttpClient() { BaseAddress = new Uri("https://blazormenumaker.azurewebsites.net/") });


            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<MmAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<MmAuthenticationStateProvider>());
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
            app.UseCors();
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
