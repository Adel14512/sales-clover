
using AutoMapper;
using Evaluation.UI.Authentication;
using Evaluation.UI.Consume.Api;
using Evaluation.UI.Cross.Cutting;
using Evaluation.UI.ErrorHandler;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IUtil;
using Evaluation.UI.Util;
using Evaluation.UI.Wrapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using System.Reflection;
using System.Text;
using SmartBreadcrumbs.Extensions;
using Global = Evaluation.UI.Util.Global;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.ControllerBusiness;

NLog.Logger logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
	
	var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages()
                        .AddSessionStateTempDataProvider();
    builder.Services.AddControllersWithViews();
    builder.Services.AddAutoMapper(typeof(Program).Assembly);
    //add JWT and Authentication
    builder.Services.AddAuthentication(
            options => options.DefaultScheme = GlobalWords.CustomAuth)
            .AddScheme<Evaluation.UI.Authentication.AuthenticationOptions, CustomAuthenticationHandler>(
                 "Custom", options => { });
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowMyOrigin",
            builder => builder.WithOrigins("https://localhost:44352")
            .AllowAnyHeader()
            .AllowAnyMethod());
    });
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = "Custom";
    }).AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
		{
			LifetimeValidator = CustomLifetimeValidator,
			ValidateIssuerSigningKey = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateIssuerSigningKey"]),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonWebTokenKeys:IssuerSigningKey"])),
            ValidateIssuer = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateIssuer"]),
            ValidAudience = builder.Configuration["JsonWebTokenKeys:ValidAudience"],
            ValidIssuer = builder.Configuration["JsonWebTokenKeys:ValidIssuer"],
            ValidateAudience = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateAudience"]),
            RequireExpirationTime = bool.Parse(builder.Configuration["JsonWebTokenKeys:RequireExpirationTime"]),
            ValidateLifetime = bool.Parse(builder.Configuration["JsonWebTokenKeys:ValidateLifetime"])
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                }
                return Task.CompletedTask;
            }
        };
    });
	bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters validationParameters)
	{
		if (expires != null)
		{
			// Check if the token is within the extended valid time (current time + 20 minutes)
			return DateTime.UtcNow < expires.Value.AddMinutes(20);
		}
		return false;
	}
	//logging
	builder.Services.AddControllers()
      .ConfigureApiBehaviorOptions(options =>
      {
          // To preserve the default behavior, capture the original delegate to call later.
          var builtInFactory = options.InvalidModelStateResponseFactory;

          options.InvalidModelStateResponseFactory = context =>
          {
              var logger = context.HttpContext.RequestServices
                                  .GetRequiredService<ILogger<Program>>();

              // Perform logging here.
              // ...

              // Invoke the default behavior, which produces a ValidationProblemDetails
              // response.
              // To produce a custom response, return a different implementation of 
              // IActionResult instead.
              return builtInFactory(context);
          };
      });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
    builder.Services.AddTransient<IUserApi, UserApi>();
    builder.Services.AddTransient<IBusinessLineApi, BusinessLineApi>();
    builder.Services.AddTransient<IGenderApi, GenderApi>();
    builder.Services.AddTransient<IGeneralListApi, GeneralListApi>();
    builder.Services.AddTransient<IContactApi, ContactApi>();
    builder.Services.AddTransient<IChannelApi, ChannelApi>();
    builder.Services.AddTransient<ITransactionApi, TransactionApi>();
    builder.Services.AddTransient<IConvertFromToExcel, ConvetFormToExcel>();
    builder.Services.AddTransient<IGlobal, Global>();
    builder.Services.AddTransient<ILeadApi, LeadApi>();
    builder.Services.AddTransient<ISlipApi, SlipApi>();
    builder.Services.AddTransient<ISpecialConditionApi, SpecialConditionApi>();
    builder.Services.AddTransient<IProductApi, ProductApi>();
    builder.Services.AddTransient<IConsolidationBusiness, ConsolidationBusiness>();
    builder.Services.AddTransient<ITransactionBusiness, TransactionBusiness>();
    builder.Services.AddTransient<IConsolidationApi, ConsolidationApi>();
    builder.Services.AddTransient<IComparitiveQuotationBusiness, ComparitiveQuotationBusiness>();

    builder.Services.AddTransient<IRenewalApi, RenewalApi>();
    builder.Services.AddTransient<IApiService, ApiService>();
    builder.Services.AddTransient<IHttpClientHelper, HttpClientHelper>();
    builder.Services.AddTransient<ILoggerManager, LoggerManager>();
    builder.Services.AddTransient<IDashboardApi, DashboardApi>();
    builder.Services.AddTransient<ITokenService, TokenService>();
    //builder.Services.AddSignalR(); // Add SignalR
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddSession(options =>
    {
        //options.IdleTimeout = TimeSpan.FromSeconds(10);
        options.Cookie.IsEssential = true; // make the session cookie Essential
        options.IdleTimeout = TimeSpan.FromMinutes(1);
        options.Cookie.HttpOnly = true;
    });
    //builder.Services.AddAuthentication("CookieAuth")
    //.AddCookie("CookieAuth", config =>
    //{
    //    config.Cookie.Name = "UserLoginCookie";
    //    config.LoginPath = "/Login/Index";
    //    config.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    //    config.SlidingExpiration = true;
    //});
    /// Breadcrumbs  start ///
    ///builder.Services.AddBreadcrumbs(Assembly.GetExecutingAssembly(), options =>
    ///{
    ///    options.TagName = "nav";
    //    options.TagClasses = "";
    //    options.OlClasses = "breadcrumb";
    //    options.LiClasses = "breadcrumb-item";
    //    options.ActiveLiClasses = "breadcrumb-item active";
    //});
    //builder.Services.AddMvc();
    //builder.Services.AddDistributedMemoryCache();
    /// Breadcrumbs  end ///
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseCors("AllowMyOrigin");
    app.UseHttpsRedirection();
    app.UseStaticFiles();
  

	app.UseRouting();
    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.UseStatusCodePagesWithRedirects("/login");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSession();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Login}/{action=Index}/{id?}"); // Default route to login
      //  endpoints.MapHub<SessionHub>("/sessionHub"); // Map SignalR hub
    });
    app.Run();

}
catch (Exception e)
{

    // NLog: catch setup errors
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}