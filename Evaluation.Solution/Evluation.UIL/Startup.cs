using Evaluation.UIL.Controllers;
using Evaluation.UIL.Cross.Cutting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Evaluation.UIL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Global.ConnString =
            //_Configuration.GetValue<string>("ConnectionStrings:BloggingDatabase");
            Global.WebApiBaseUrl =
           _Configuration.GetValue<string>("WebAPIBaseUrl");

            services.AddRazorPages(options =>
            {
                //options.Conventions.AuthorizePage("/Test");
                //options.Conventions.AuthorizePage("/SignedOut");
                //options.Conventions.AuthorizePage("/AccessDenied");
                // options.Conventions.AuthorizePage("/Register/ChangePassword");
            });

            #region snippet1
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index/";
                    //options.LogoutPath = "";
                    options.Cookie.HttpOnly = true;
                    //        //...
                    //        //options.ExpireTimeSpan = TimeSpan.FromDays(7);
                    options.Cookie.Name = "authcookie";
                    //        options.Cookie.SameSite = SameSiteMode.Strict;
                    //        //options.CookieManager.
                    options.ExpireTimeSpan = TimeSpan.FromSeconds(40);
                    //options.Cookie.Expiration = TimeSpan.FromSeconds(40);
                    //options.LogoutPath = "/Home/Logout";
                    options.AccessDeniedPath = "/AccessDenied";

                    options.Events = new CookieAuthenticationEvents()
                    {
                        OnSigningIn = async context =>
                          {
                              await Task.CompletedTask;
                          },

                        OnSignedIn = async context =>
                        {
                            await Task.CompletedTask;
                        },

                        OnValidatePrincipal = async context =>
                        {
                            await Task.CompletedTask;
                            // context.Options.
                        }

                    };
                    //        //options.Cookie.Expiration = TimeSpan.FromSeconds(10);
                    //        //options.s
                });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(40);
            });
            #endregion
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(RequestAuthenticationFilter));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = "authcookie";
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //    options.

            //});

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.LoginPath = "/Identity/Account/Login";
            //    options.SlidingExpiration = true;
            //    options.
            //});

            //    services.AddRazorPages()
            //.AddMvcOptions(options => options.Filters.Add(new AuthorizeFilter("MyCustomPolicy")));

            //    // Configure the custom policy
            //    services.AddAuthorization(options =>
            //    {
            //        options.AddPolicy("MyCustomPolicy",
            //            policyBuilder => policyBuilder.RequireClaim("SomeClaim"));
            //    });
            //ADD AUTHORIZATION POLICY END
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            //SET REDIRECTION BASED ON AUTHORIZATION POLICY START



            app.UseAuthorization();
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                   name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
