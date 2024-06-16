using Evaluation.UIL.Consume.Api;
using Evaluation.UIL.Models;
using Evaluation.UIL.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Evaluation.UIL.Controllers
{
    public class LoginController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(string returnUrl = null)
        {
            var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            if (session != null)
                return RedirectToAction("LoginStatus", "Home");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult Authenticate(UserCredViewModel userCredViewModel, string returnUrl = null)
        {
            UserCredReq userCredReq = new();
            userCredReq.UserCredDto = new()
            {
                Password = userCredViewModel.Password,
                UserName = userCredViewModel.UserName
            };

            if (ModelState.IsValid)
            {
                var userResp = ApiService.CheckUserCred(userCredReq);
                if (userResp != null && userResp.UserDto.Count == 1)
                {
                    //ViewBag.Message = "Success";
                    ////ViewBag.ReturnUrl = "";
                    //ModelState.Clear();
                    //return View("Index");
                    //Global.IsCookieValidated = "loggedin";
                    _httpContextAccessor.HttpContext.Session.SetString("UserName", userCredViewModel.UserName);
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userCredViewModel.UserName),
                        new Claim(ClaimTypes.Email, "anet@test.com"),
                        new Claim(ClaimTypes.Role,"Admin")
                    };

                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    HttpContext.SignInAsync(userPrincipal);
                    //HttpContext.SignInAsync(userPrincipal,
                    //    new AuthenticationProperties
                    //    {
                    //        IsPersistent = true,
                    //        ExpiresUtc = DateTime.UtcNow.AddSeconds(10)

                    //    });
                    //return RedirectToAction("Index", "Home");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ViewBag.Message = "Failure";
                    ModelState.Clear();
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
            {
                TempData["message"] = "You have successfully logged in";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
