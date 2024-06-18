using Evaluation.CAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Evaluation.CAL.Wrapper;
using NLog;
using System.IO;

namespace Evaluation.SAL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {            
            _Configuration = configuration;
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/Nlog.Config"));
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _Configuration["Jwt:Issuer"],
            ValidAudience = _Configuration["Jwt:Issuer"],            
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]))
        };
    });
            services.AddSingleton<ILoggerManager, LoggerManager>(); 
            services.AddMvc();
            services.AddControllers();            
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clover.SAL", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            services.Configure<ApiBehaviorOptions>(options =>

            {
                options.SuppressModelStateInvalidFilter = true;

            });
            //Global.ConnString =
            //_Configuration.GetSection("ConnectionStrings").GetSection("BloggingDatabase").Value;

            Global.ConnString =
                _Configuration.GetValue<string>("ConnectionStrings:BloggingDatabase");
            Global.ConnStringV2 =
                _Configuration.GetValue<string>("ConnectionStrings:BloggingDatabaseV2");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

            if (env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clover.SAL v1"));

                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom                    
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clover.APIs v1");
                    //c.RoutePrefix = "";
                    //c.SwaggerEndpoint("/rest/v1/api-docs/swagger.json", "Clover.SAL v1");
                });
            }
            //var builder = WebApplication.CreateBuilder(args);
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint(
            //      "/swagger/help/swagger.json", "Fiver.Api Help Endpoint");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
