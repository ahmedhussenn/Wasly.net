using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Wasly.context;
using Wasly.net.Services;

namespace Wasly.net
{
    public class Startup
    {
        public IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddMvc();

          services.AddDbContext<appcontext>(optionsAction =>
        optionsAction.UseSqlServer(_configuration.GetConnectionString("connectionstring")));
           services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<appcontext>();

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = "891001289007-5ogelub651k467a70lvpqap41oqq8bel.apps.googleusercontent.com";
                googleOptions.ClientSecret = "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";
            });

            services.AddSession(c =>
            {
                c.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed.


            });
            //    services.AddSingleton<IEmpsRepos, StudentRepos>(); //the longest one created only one
            //   services.AddScoped<IEmpsRepos, StudentRepos>();
            // services.AddTransient<IEmpsRepos, StudentRepos>();//each time one will be create
            // services.AddScoped<IEmpsRepos, StudentRepos>();//one created per client request   
            services.AddScoped<OrderRepos>();
            services.AddScoped<ClientRepos>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure middleware pipeline
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Other middleware configurations
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });

            /*
                        app.Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync(" MiddleWare 1");
                            await next.Invoke();
                            await context.Response.WriteAsync(" MiddleWare 1 \n" ); 
                        });

                        app.Use(async (context, next) =>
                        {
                            await context.Response.WriteAsync(" MiddleWare 2\n");
                            await next.Invoke();
                            await context.Response.WriteAsync(" MiddleWare 2");
                        });

                        app.Run(async (context) =>
                        {
                            await context.Response.WriteAsync(" Terminated\n ");

                        });
            */

        }
    }
}
