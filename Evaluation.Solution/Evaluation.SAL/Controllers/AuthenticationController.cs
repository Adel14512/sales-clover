using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public IConfiguration _Configuration { get; }
        //public AuthController(ILoggerManager logger)
        //{
        //    _logger = logger;
        //}
        public AuthenticationController(IConfiguration configuration, ILoggerManager logger)
        {
            _Configuration = configuration;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult TokenKey([FromBody] AuthReq authReq)
        {
            AuthResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                Token = new TokenDto()
            };

            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Error";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = authReq == null ? Guid.NewGuid().ToString() :
                        authReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        authReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        authReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        authReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(authReq.WebRequestCommon.CorrelationId, authReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint TokenKey is started");
                _logger.LogDebug(JsonConvert.SerializeObject(authReq));
                resp.Token = InstManagerAccessPoint.GetNewAccessPoint().TokenKey(authReq.Auth);

                if (resp != null)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Token.Reserved1 != null ? resp.Token.Reserved1 : "Token key generated";
                    resp.WebResponseCommon.ReturnCode = resp.Token.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = authReq.WebRequestCommon.CorrelationId;
                    if (resp.Token.Reserved1 != null)
                        resp.Token = new TokenDto();
                }
                if (resp != null && resp.Token.AccessToken != null)
                {
                    //AuthDto _authDto = new()
                    //{
                    //    ClientId = "clover-client",
                    //    Scope = "api:service",
                    //    Client_Secret = "clover-secret",
                    //    Grant_Type = "client_credentials"
                    //};
                    resp.Token.AccessToken = GenerateTokenKey(authReq.Auth);
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint TokenKey is completed");
                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = authReq.WebRequestCommon.CorrelationId;
                resp.Token = new TokenDto();
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }

            // gettoken 
            //var userLogin = new UserLogin()
            //{
            //    Password = "MyPass_w0rd",
            //    UserName = "jason_admin"
            //};
            //var user = Authenticate(userLogin);
            //if (user != null)
            //{
            //    var token = Generate(user);
            //    return Ok(token);
            //}
            //return NotFound("");

        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(o => o.UserName.ToLower() ==
            userLogin.UserName.ToLower() && o.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
        private string GenerateTokenKey(AuthDto authDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , authDto.ClientId),
                new Claim(ClaimTypes.Email, authDto.Scope),
                new Claim(ClaimTypes.GivenName, authDto.Client_Secret),
                new Claim(ClaimTypes.Surname, authDto.Grant_Type)
                //new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_Configuration["Jwt:Issuer"],
                _Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
