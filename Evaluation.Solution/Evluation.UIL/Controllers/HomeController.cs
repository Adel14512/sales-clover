using Evaluation.UIL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Evaluation.UIL.Controllers
{
    //[Authorize(Policy = "LoggedIn")]
    //[Route("Home")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private string strMssg = string.Empty;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //[Route("Index/")]
        public IActionResult Index()
        {
            if (TempData["message"] != null)
                ViewBag.Message = TempData["message"].ToString();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[Authorize]
        public async Task<IActionResult> Logout2()
        {
            //_logger.LogInformation("User {Name} logged out at {Time}.",
            //    User.Identity.Name, DateTime.UtcNow);
            //var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            //if (session == null)
            //    return RedirectToAction("Index", "Login");
            #region snippet1
            //Global.IsCookieValidated = string.Empty;
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Session.Clear();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Response.Cookies.Remove(".AspNetCore.Cookies");
            //foreach (var cookieKey in Request.Cookies.Keys)
            //{
            //    Response.Cookies.Delete(cookieKey);
            //}
            #endregion
            return View();
            //return RedirectToAction("Logout2", "Home");
            //return RedirectToPage("/SignedOut");
            //return Redirect("/Home/SignedOut");
        }

        //public IActionResult Logout2()
        //{
        //     return View("SignedOut");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[Authorize]
        public async Task<IActionResult> SessionTimeOut()
        {
            //Global.IsCookieValidated = string.Empty;           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Session.Clear();
            //_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
            //strMssg = "TimeOut";
            TempData["message"] = "Session has expired";
            return RedirectToAction("Index");
            //return RedirectToAction("Index", "Home", new { message = "TimeOut" });
        }

        public async Task<IActionResult> Logout()
        {
            var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            if (session == null)
                return RedirectToAction("Index", "Login");
            //Global.IsCookieValidated = string.Empty;           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Session.Clear();
            //_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
            //return View();
            //return RedirectToAction("Index", "Home","Logout");
            //TempData["TempModel"] = "Logout";
            //return Url.Action("Index", new {message = "Logout" });
            TempData["message"] = "You have successfully logged out";
            //strMssg = "Logout";
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult LoginStatus()
        {
            //strMssg = "Logged";
            TempData["message"] = "You are already logged in";
            return RedirectToAction("Index");
            //return View();
        }
    }
}
