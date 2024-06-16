using Evaluation.UI.Models;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;

namespace Evaluation.UI.Controllers
{
  //  [Breadcrumb]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[Breadcrumb(GlobalWords.BreadCrumbTitle)]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public IActionResult Index()
        {
            return View();
        }
       // [Breadcrumb(GlobalWords.BreadCrumbTitle)]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}