
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

            services.AddControllersWithViews();
            services.AddMvc();

            //services.AddDbContext<Contexto>(options =>
            //       options.UseSqlServer(
            //           Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<Data.ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<Data.ApplicationDbContext>().AddDefaultTokenProviders();
            
            services.AddRazorPages();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddSession();

            /*  services.Configure<DataProtectionTokenProviderOptions>(o => o.TokenLifespan = TimeSpan.FromMinutes(1))*/
            ;
            //services.ConfigureApplicationCookie(options => 
            //{
                
               
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromSeconds(60);
            //    options.LoginPath = "/Cuenta/Login";
            //    options.LogoutPath = "/Cuenta/Logout";
               
            //    options.SlidingExpiration = true;


            //});

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
