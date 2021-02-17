
using AsopaabiOnline.Modelo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AsopaabiOnline.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using AsopaabiOnline.UI.Services;
using AsopaabiOnline.UI.Models;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AsopaabiOnline.UI
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

            services.AddControllersWithViews().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddMvc();




            //services.AddDbContext<Contexto>(options =>
            //       options.UseSqlServer(
            //           Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<Data.ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options => {
                options.SignIn.RequireConfirmedAccount = false;

                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireDigit = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

                options.User.RequireUniqueEmail = true;
               
               

            }).AddEntityFrameworkStores<Data.ApplicationDbContext>().AddDefaultTokenProviders();
            
            services.AddRazorPages();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
               });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Inicio/Error");
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    
                    pattern: "{controller=Cuenta}/{action=Login}/{id?}");
            });
        }
    }
}
