using Evaluation.UIL.Consume.Api;
using Evaluation.UIL.Models;
using Evaluation.UIL.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Evaluation.UIL.Controllers
{
    //Authorize(Policy = "LoggedIn")]
    public class RegisterController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
            //return RedirectToPage("/Test");
        }

        public IActionResult RegisterUser(UserRegisterViewMdel userRegisterViewMdel)
        {
            UserRegisterReq userRegisterReq = new();
            userRegisterReq.UserRegisterDto = new()
            {
                EmailAdress = userRegisterViewMdel.EmailAdress,
                FirstName = userRegisterViewMdel.FirstName,
                LastName = userRegisterViewMdel.LastName,
                Password = userRegisterViewMdel.Password,
                RoleId = 3,
                UserName = userRegisterViewMdel.UserName
            };

            if (ModelState.IsValid)
            {
                var userResp = ApiService.RegisterUser(userRegisterReq);
                if (userResp != null && userResp.UserDto.Count == 1)
                {
                    //ViewBag.Message = "You are successfully registered";
                    //ViewBag.ReturnUrl = "";
                    ModelState.Clear();
                    TempData["message"] = "User successfully created";
                    return RedirectToAction("Index", "Home");
                    //return View("Index");
                }
                else
                {
                    ViewBag.Message = "Not successfully registered";
                    ModelState.Clear();
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        public JsonResult IsAlreadySigned(string userName)
        {
            return Json(IsUserAvailable(userName));
        }
        public bool IsUserAvailable(string userName)
        {
            UserSignedReq userSignedReq = new();
            userSignedReq.UserSignedDto = new()
            {
                UserName = userName
            };

            var userResp = ApiService.IsUserAvailable(userSignedReq);
            if (userResp != null && userResp.UserDto.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public JsonResult IsCurrentPwdCorrect(string currentPassword)
        {
            var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            if (session == null)
                return Json(true);

            return Json(IsPwdExist(currentPassword));
        }

        public bool IsPwdExist(string currentPassword)
        {
            //var userName = HttpContext.User.Claims.FirstOrDefault().Value;

            UserCredReq userCredReq = new();
            userCredReq.UserCredDto = new()
            {
                Password = currentPassword,
                UserName = HttpContext.User.Claims.FirstOrDefault().Value
            };

            var userResp = ApiService.CheckUserCred(userCredReq);
            if (userResp != null && userResp.UserDto.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ChangePassword()
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Login");

            //}
            return View();
        }

        public IActionResult UpdatePassword(UserChangePwdModel userChangePwdModel)
        {
            //if (Global.IsCookieValidated == "loggedout")
            //{
            //    return RedirectToAction("SessionTimeOut", "Home");
            //}

            //string cookieValueFromReq = Request.Cookies["authcookie"];
            //string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["authcookie"];
            //if (!Global.IsCookieValidated)
            //{
            //    return RedirectToAction("Index", "Login");
            //}
            //Global.IsCookieValidated = false;

            //HttpCookie cookie = HttpContext.Current.Request.Cookies["authcookie"];
            //if (cookie != null)
            //{
            //    string val = (!String.IsNullOrEmpty(keyName)) ? cookie["authcookie"] : cookie.Value;
            //    if (!String.IsNullOrEmpty(val)) return Uri.UnescapeDataString(val);
            //}
            //return null;

            //string cookie = Request.Cookies["authcookie"];

            UserChangePasswordReq userChangePasswordReq = new();
            userChangePasswordReq.UserChangePasswordDto = new()
            {
                NewPassword = userChangePwdModel.NewPassword,
                UserName = HttpContext.User.Claims.FirstOrDefault().Value
            };

            if (ModelState.IsValid)
            {
                var userResp = ApiService.UpdateUserPassword(userChangePasswordReq);
                if (userResp != null && userResp.UserDto.Count == 1)
                {
                    //ViewBag.Message = "Success";
                    //ViewBag.ReturnUrl = "";
                    ModelState.Clear();
                    TempData["message"] = "Password successfully changed";
                    return RedirectToAction("Index", "Home");
                    ///return View("ChangePassword");
                }
                else
                {
                    ViewBag.Message = "Failure";
                    ModelState.Clear();
                    return View("ChangePassword");
                }
            }
            else
            {
                return View("ChangePassword");
            }
        }
    }
}
