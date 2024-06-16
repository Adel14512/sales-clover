using Evaluation.UI.Consume.Api;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Response;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Evaluation.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApiService _apiService;
        private readonly IUserApi _userApi;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        public LoginController(IHttpContextAccessor httpContextAccessor, IApiService apiService, IUserApi userApi, IConfiguration configuration, IMemoryCache cache)
        {
            _httpContextAccessor = httpContextAccessor;
            _apiService = apiService;
            _userApi = userApi;
            _configuration = configuration;
            _cache = cache;
        }

        public IActionResult Index(string returnUrl = null)
        {
            var session = _httpContextAccessor.HttpContext.Session.Get("UserName");
            if (session != null)
                return RedirectToAction("LoginStatus", "Home");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(UserCredViewModel userCredViewModel, CancellationToken ct, string returnUrl = null)
        {
            //UserCredResp result;
            //result = new()
            //{
            //    WebResponseCommon = new()
            //    {
            //        SuccessIndicator = "Success",
            //        ReturnCode = StatusCodes.Status200OK.ToString(),
            //        ReturnMessage = "Enquiry Succeeded",
            //        CorrelationId = Guid.NewGuid().ToString()
            //    },
            //    User = new()
            //    {
            //        EmailAdress = "EmailAdressTest",
            //        FirstName = "FirstNameTest",
            //        LastName = "LastNameTest",
            //        LoginStatus = "LoginStatusTest",
            //        RoleDescription = "RoleDescriptionTest",
            //        RoleId = -1,
            //        UserId = -1,
            //        UserName = "UserNameTest"
            //    }
            //};
            var result = await _userApi.Login(userCredViewModel, ct);
            UserCredReq userCredReq = new();
            userCredReq.UserCredDto = new()
            {
                Password = userCredViewModel.Password,
                UserName = userCredViewModel.UserName
            };

            if (ModelState.IsValid)
            {
                //var userResp = _apiService.CheckUserCred(userCredReq);
                // if (userResp != null && userResp.UserDto.Count == 1)
                // {
                //ViewBag.Message = "Success";
                ////ViewBag.ReturnUrl = "";
                //ModelState.Clear();
                //return View("Index");
                //Global.IsCookieValidated = "loggedin";
                _httpContextAccessor.HttpContext.Session.SetString("UserEmail", result.User.EmailAdress);
                _httpContextAccessor.HttpContext.Session.SetString("UserFullName", result.User.FirstName + " " + result.User.LastName);
                var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, userCredViewModel.UserName),
                        new Claim(ClaimTypes.Email, userCredViewModel.UserName),
                        new Claim(ClaimTypes.Role,"Admin"),
                        new Claim(ClaimTypes.NameIdentifier,result.WebResponseCommon.CorrelationId)
                    };
                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("peter123"));

                // Create a signing credential using the new key
                //  var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //var token = new JwtSecurityToken(
                //      issuer: "your_issuer",
                //      audience: "your_audience",
                //                    claims: userClaims,
                //      expires: DateTime.UtcNow.AddDays(1),
                //      signingCredentials: signingCredentials
                //    );

                //// Serialize the JWT token to a string
                //var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenKeys:IssuerSigningKey"]));

                var token = new JwtSecurityToken(_configuration["JsonWebTokenKeys:ValidIssuer"],
                    _configuration["JsonWebTokenKeys:ValidAudience"],
                    expires: DateTime.Now.AddDays(1),
                    claims: userClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                var options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(token.ValidTo);
                _cache.Set("TOKEN", tokenstring, options);
                return Ok(new { token = tokenstring });
                return Ok(null);
                //}
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
